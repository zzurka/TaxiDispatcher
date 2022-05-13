﻿using MediatR;
using TaxiDispatcher.Application.DTO;

namespace TaxiDispatcher.Application.Taxi.Queries
{
    public class GetTaxiByIdQuery : IRequest<TaxiDto?>
    {
        public Guid Id { get; set; }
    }
}