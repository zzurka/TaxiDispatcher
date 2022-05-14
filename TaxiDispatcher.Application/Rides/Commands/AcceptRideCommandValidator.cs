using FluentValidation;

namespace TaxiDispatcher.Application.Rides.Commands
{
    public class AcceptRideCommandValidator : AbstractValidator<AcceptRideCommand>
    {
        public AcceptRideCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
