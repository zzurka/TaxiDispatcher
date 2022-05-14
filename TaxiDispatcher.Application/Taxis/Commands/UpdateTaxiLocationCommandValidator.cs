using FluentValidation;

namespace TaxiDispatcher.Application.Taxis.Commands
{
    public class UpdateTaxiLocationCommandValidator : AbstractValidator<UpdateTaxiLocationCommand>
    {
        public UpdateTaxiLocationCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Location).GreaterThanOrEqualTo(0).WithMessage("Location to must be greater than zero");
        }
    }
}
