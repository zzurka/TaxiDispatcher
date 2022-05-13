using MapsterMapper;
using MediatR;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Application.DTO;
using TaxiDispatcher.Application.Ride.Commands;
using TaxiDispatcher.Domain.Enums;

namespace TaxiDispatcher.Application.Ride.Handlers
{
    public class AcceptRideCommandHandler : IRequestHandler<AcceptRideCommand, RideDto>
    {
        private readonly IRideRepository _rideRepository;
        private readonly ITaxiRepository _taxiRepository;
        private readonly IMapper _mapper;

        public AcceptRideCommandHandler(IRideRepository rideRepository, ITaxiRepository taxiRepository, IMapper mapper)
        {
            _rideRepository = rideRepository;
            _taxiRepository = taxiRepository;
            _mapper = mapper;
        }

        public async Task<RideDto> Handle(AcceptRideCommand request, CancellationToken cancellationToken)
        {
            // Update ride status
            Domain.Entities.Ride? ride = await _rideRepository.UpdateRideStatusByRideId(request.Id, RideStatus.Finished);

            if (ride == null)
            {
                throw new Exception("Ride doesn't exist!");
            }

            // Update taxi location
            await _taxiRepository.UpdateTaxiLocation(ride.Taxi.Id, ride.RideRequest.LocationTo);

            return _mapper.Map<RideDto>(ride);
        }
    }
}
