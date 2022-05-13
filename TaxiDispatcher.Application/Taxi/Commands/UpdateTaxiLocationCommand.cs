using MediatR;

namespace TaxiDispatcher.Application.Taxi.Commands
{
    public class UpdateTaxiLocationCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public int Location { get; set; }
    }
}
