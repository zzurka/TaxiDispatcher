using FluentValidation;

namespace TaxiDispatcher.Application.Ride.Commands
{
    public class AcceptRideCommandValidator : AbstractValidator<AcceptRideCommand>
    {
        public AcceptRideCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
