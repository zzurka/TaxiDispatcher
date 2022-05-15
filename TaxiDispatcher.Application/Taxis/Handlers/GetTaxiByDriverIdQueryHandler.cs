using MapsterMapper;
using TaxiDispatcher.Application.Common.Interfaces;
using TaxiDispatcher.Application.Common.Models;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Application.DTO;
using TaxiDispatcher.Application.Taxis.Queries;

namespace TaxiDispatcher.Application.Taxis.Handlers
{
    public class GetTaxiByDriverIdQueryHandler : IRequestHandlerWrapper<GetTaxiByDriverIdQuery, TaxiDto>
    {
        private readonly ITaxiRepository _taxiRepository;
        private readonly IMapper _mapper;

        public GetTaxiByDriverIdQueryHandler(ITaxiRepository taxiRepository, IMapper mapper)
        {
            _taxiRepository = taxiRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<TaxiDto>> Handle(GetTaxiByDriverIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Taxi? taxi = await _taxiRepository.GetTaxiByDriverId(request.Id);
            
            return taxi != null 
                ? ServiceResult.Success(_mapper.Map<TaxiDto>(taxi)) 
                : ServiceResult.Failed<TaxiDto>(ServiceError.DriverTaxiNotFound(request.Id));
        }
    }
}
