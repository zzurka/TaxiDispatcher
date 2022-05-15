using FluentValidation;

namespace TaxiDispatcher.Application.Rides.Commands
{
    public class RequestRideCommandValidator : AbstractValidator<RequestRideCommand>
    {
        public RequestRideCommandValidator()
        {
            RuleFor(x => x.LocationFrom).GreaterThanOrEqualTo(0).WithMessage("LocationFrom must be greater than zero");
            RuleFor(x => x.LocationTo).GreaterThanOrEqualTo(0).WithMessage("LocationTo must be greater than zero");
            RuleFor(x => x.RideType).IsInEnum().WithMessage("Available values for RideType are 0 (city) and 1 (inter city)");
            RuleFor(x => x.RideTime).Must(BeAValidDate).WithMessage("RideTime is not valid date");
        }

        private static bool BeAValidDate(string value)
        {
            return DateTime.TryParse(value, out var date) && !date.Equals(default);
        }
    }
}
