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
    public class AcceptRideCommandHandler : IRequestHandlerWrapper<AcceptRideCommand, RideDto>
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

        public async Task<ServiceResult<RideDto>> Handle(AcceptRideCommand request, CancellationToken cancellationToken)
        {
            // Update ride status
            Ride? ride = await _rideRepository.UpdateRideStatusByRideId(request.Id, RideStatus.Finished);

            if (ride == null)
            {
                throw new NotFoundException(nameof(Ride), request.Id);
            }

            // Update taxi location
            await _taxiRepository.UpdateTaxiLocation(ride.Taxi.Id, ride.RideRequest.LocationTo);

            return ServiceResult.Success(_mapper.Map<RideDto>(_mapper.Map<RideDto>(ride)));
        }
    }
}
