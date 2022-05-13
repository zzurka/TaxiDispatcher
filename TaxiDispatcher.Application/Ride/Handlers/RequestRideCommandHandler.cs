using MapsterMapper;
using MediatR;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Application.DTO;
using TaxiDispatcher.Application.Ride.Commands;
using TaxiDispatcher.Domain.Entities;
using TaxiDispatcher.Domain.Enums;

namespace TaxiDispatcher.Application.Ride.Handlers
{
    public class RequestRideCommandHandler : IRequestHandler<RequestRideCommand, RideDto>
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

        public async Task<RideDto> Handle(RequestRideCommand request, CancellationToken cancellationToken)
        {
            // AllTaxiLocations can be in some cache for fast access!
            IEnumerable<TaxiLocation> taxiLocations = await _taxiRepository.GetAllTaxiLocations();

            TaxiLocation closestTaxi = taxiLocations.Aggregate((x, y) => Math.Abs(x.Location - request.LocationFrom) <= Math.Abs(y.Location - request.LocationFrom) ? x : y);

            if (Math.Abs(closestTaxi.Location - request.LocationFrom) > 15)
            {
                throw new Exception("There are no available taxi vehicles!");
            }
            else
            {
                RideRequest rideRequest = _mapper.Map<RideRequest>(request);
                Domain.Entities.Taxi? taxi = await _taxiRepository.GetTaxiById(closestTaxi.TaxiId);

                if (taxi == null)
                {
                    throw new Exception("There are no available taxi vehicles!");
                }

                var ride = new Domain.Entities.Ride
                {
                    RideRequest = rideRequest,
                    Taxi = taxi,
                    RideStatus = RideStatus.Ordered,
                    Price = CalculatePrice(rideRequest, taxi)
                };

                var savedRide = await _rideRepository.CreateRide(ride);

                return _mapper.Map<RideDto>(savedRide);
            }
        }

        private static int CalculatePrice(RideRequest rideRequest, Domain.Entities.Taxi taxi)
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
