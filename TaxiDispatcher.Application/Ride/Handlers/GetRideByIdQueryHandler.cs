using MapsterMapper;
using MediatR;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Application.DTO;
using TaxiDispatcher.Application.Ride.Queries;

namespace TaxiDispatcher.Application.Ride.Handlers
{
    public class GetRideByIdQueryHandler : IRequestHandler<GetRideByIdQuery, RideDto?>
    {
        private readonly IRideRepository _rideRepository;
        private readonly IMapper _mapper;

        public GetRideByIdQueryHandler(IRideRepository rideRepository, IMapper mapper)
        {
            _rideRepository = rideRepository;
            _mapper = mapper;
        }

        public async Task<RideDto?> Handle(GetRideByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Ride? ride = await _rideRepository.GetRideById(request.Id);
            var rideResponse = ride != null ? _mapper.Map<RideDto>(ride) : null;
            return rideResponse;
        }
    }
}
