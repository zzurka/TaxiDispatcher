using FluentValidation;

namespace TaxiDispatcher.Application.Ride.Commands
{
    public class RequestRideCommandValidator : AbstractValidator<RequestRideCommand>
    {
        public RequestRideCommandValidator()
        {
            RuleFor(x => x.LocationFrom).GreaterThanOrEqualTo(0).WithMessage("Location from must be greater than zero");
            RuleFor(x => x.LocationTo).GreaterThanOrEqualTo(0).WithMessage("Location to must be greater than zero");
            RuleFor(x => x.RideType).IsInEnum().WithMessage("Available values for ride type are 0 (city) and 1 (inter city)");
        }
    }
}
