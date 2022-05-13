﻿using MapsterMapper;
using MediatR;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Application.DTO;
using TaxiDispatcher.Application.Taxi.Queries;

namespace TaxiDispatcher.Application.Taxi.Handlers
{
    public class GetTaxiByIdQueryHandler : IRequestHandler<GetTaxiByIdQuery, TaxiDto?>
    {
        private readonly ITaxiRepository _taxiRepository;
        private readonly IMapper _mapper;

        public GetTaxiByIdQueryHandler(ITaxiRepository taxiRepository, IMapper mapper)
        {
            _taxiRepository = taxiRepository;
            _mapper = mapper;
        }
        
        public async Task<TaxiDto?> Handle(GetTaxiByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Taxi? taxi = await _taxiRepository.GetTaxiById(request.Id);
            var taxiResponse = taxi != null ? _mapper.Map<TaxiDto>(taxi) : null;
            return taxiResponse;
        }
    }
}