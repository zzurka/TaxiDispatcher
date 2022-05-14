using FluentValidation;

namespace TaxiDispatcher.Application.Rides.Queries
{
    public class GetRideByIdQueryValidator : AbstractValidator<GetRideByIdQuery>
    {
        public GetRideByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
