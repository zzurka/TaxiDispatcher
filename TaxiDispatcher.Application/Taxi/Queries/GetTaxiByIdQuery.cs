using FluentValidation;
using MediatR;
using TaxiDispatcher.Application.DTOs;

namespace TaxiDispatcher.Application.Taxi.Queries
{
    public class GetTaxiByIdQuery : IRequest<TaxiDto>
    {
        public Guid Id { get; set; }
    }

    public class GetTaxiByIdQueryValidator : AbstractValidator<GetTaxiByIdQuery>
    {
        public GetTaxiByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
