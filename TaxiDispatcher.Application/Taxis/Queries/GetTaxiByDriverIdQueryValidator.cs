using FluentValidation;

namespace TaxiDispatcher.Application.Taxis.Queries
{
    public class GetTaxiByDriverIdQueryValidator : AbstractValidator<GetTaxiByDriverIdQuery>
    {
        public GetTaxiByDriverIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Driver id must be greater than 0");
        }
    }
}
