using FluentValidation;

namespace TaxiDispatcher.Application.Taxi.Queries
{
    public class GetTaxiByIdQueryValidator : AbstractValidator<GetTaxiByIdQuery>
    {
        public GetTaxiByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
