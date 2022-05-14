using FluentValidation;

namespace TaxiDispatcher.Application.Taxis.Queries
{
    public class GetDriverEarningsQueryValidator : AbstractValidator<GetDriverEarningsQuery>
    {
        public GetDriverEarningsQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Driver id must be greater than 0");
        }
    }
}
