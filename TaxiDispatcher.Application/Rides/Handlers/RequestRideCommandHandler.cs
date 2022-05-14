using MapsterMapper;
using TaxiDispatcher.Application.Common.Exceptions;
using TaxiDispatcher.Application.Common.Interfaces;
using TaxiDispatcher.Application.Common.Models;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Application.DTO;
using TaxiDispatcher.Application.Rides.Commands;
using TaxiDispatcher.Domain.Entities;
using TaxiDispatcher.Domain.Enums;

namespace TaxiDispatcher.Application.Rides.Handlers
{
    public class RequestRideCommandHandler : IRequestHandlerWrapper<RequestRideCommand, RideDto>
    {
        private readonly IRideRepository _rideRepository;
        private readonly ITaxiRepository _taxiRepository;
        private readonly IMapper _mapper;

        public RequestRideCommandHandler(IRideRepository rideRepository, ITaxiRepository taxiRepository, IMapper mapper)
        {
            _rideRepository = rideRepository;
            _taxiRepository = taxiRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<RideDto>> Handle(RequestRideCommand request, CancellationToken cancellationToken)
        {
            // AllTaxiLocations can be in some cache for fast access!
            IEnumerable<TaxiLocation> taxiLocations = await _taxiRepository.GetAllTaxiLocations();

            TaxiLocation closestTaxi = taxiLocations.Aggregate((x, y) => Math.Abs(x.Location - request.LocationFrom) <= Math.Abs(y.Location - request.LocationFrom) ? x : y);

            if (Math.Abs(closestTaxi.Location - request.LocationFrom) > 15)
            {
                throw new NotFoundException("There are no available taxi vehicles!");
            }
            else
            {
                RideRequest rideRequest = _mapper.Map<RideRequest>(request);
                Taxi? taxi = await _taxiRepository.GetTaxiById(closestTaxi.TaxiId);

                if (taxi == null)
                {
                    throw new NotFoundException("There are no available taxi vehicles!");
                }

                var ride = new Ride
                {
                    RideRequest = rideRequest,
                    Taxi = taxi,
                    RideStatus = RideStatus.Ordered,
                    Price = CalculatePrice(rideRequest, taxi)
                };

                var savedRide = await _rideRepository.CreateRide(ride);

                return ServiceResult.Success(_mapper.Map<RideDto>(savedRide));
            }
        }

        private static int CalculatePrice(RideRequest rideRequest, Taxi taxi)
        {
            int price = taxi.TaxiCompany.BasePrice * Math.Abs(rideRequest.LocationFrom - rideRequest.LocationTo);

            int nightRideMultiplier = rideRequest.RideTime.Hour < taxi.TaxiCompany.NightRideHoursTo || rideRequest.RideTime.Hour > taxi.TaxiCompany.NightRideHoursFrom
                ? taxi.TaxiCompany.NightRideMultiplier
                : 1;

            int rideTypeMultiplier = rideRequest.RideType == RideType.InterCity
                ? taxi.TaxiCompany.InterCityMultiplier
                : 1;

            return price * rideTypeMultiplier * nightRideMultiplier;
        }
    }
}
