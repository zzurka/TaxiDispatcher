using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Application.DTO;
using TaxiDispatcher.Application.Taxi.Queries;

namespace TaxiDispatcher.Application.Taxi.Handlers
{
    public class GetTaxiByDriverIdQueryHandler : IRequestHandler<GetTaxiByDriverIdQuery, TaxiDto?>
    {
        private readonly ITaxiRepository _taxiRepository;
        private readonly IMapper _mapper;

        public GetTaxiByDriverIdQueryHandler(ITaxiRepository taxiRepository, IMapper mapper)
        {
            _taxiRepository = taxiRepository;
            _mapper = mapper;
        }

        public async Task<TaxiDto?> Handle(GetTaxiByDriverIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Taxi? taxi = await _taxiRepository.GetTaxiByDriverId(request.Id);
            var taxiResponse =  taxi != null ? _mapper.Map<TaxiDto>(taxi) : null;
            return taxiResponse;
        }
    }
}
