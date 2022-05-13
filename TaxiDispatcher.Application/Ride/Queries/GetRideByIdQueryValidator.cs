using FluentValidation;

namespace TaxiDispatcher.Application.Ride.Queries
{
    public class GetRideByIdQueryValidator : AbstractValidator<GetRideByIdQuery>
    {
        public GetRideByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
