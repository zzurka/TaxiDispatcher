using FluentValidation;

namespace TaxiDispatcher.Application.Taxis.Queries
{
    public class GetTaxiByIdQueryValidator : AbstractValidator<GetTaxiByIdQuery>
    {
        public GetTaxiByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
