using MapsterMapper;
using TaxiDispatcher.Application.Common.Interfaces;
using TaxiDispatcher.Application.Common.Models;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Application.DTO;
using TaxiDispatcher.Application.Rides.Queries;
using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Application.Rides.Handlers
{
    public class GetRideByIdQueryHandler : IRequestHandlerWrapper<GetRideByIdQuery, RideDto>
    {
        private readonly IRideRepository _rideRepository;
        private readonly IMapper _mapper;

        public GetRideByIdQueryHandler(IRideRepository rideRepository, IMapper mapper)
        {
            _rideRepository = rideRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<RideDto>> Handle(GetRideByIdQuery request, CancellationToken cancellationToken)
        {
            Ride? ride = await _rideRepository.GetRideById(request.Id);

            return ride != null
                ? ServiceResult.Success(_mapper.Map<RideDto>(ride))
                : ServiceResult.Failed<RideDto>(ServiceError.RideNotFound(request.Id));
        }
    }
}
