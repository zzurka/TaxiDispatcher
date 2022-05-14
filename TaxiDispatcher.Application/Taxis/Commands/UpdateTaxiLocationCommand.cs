using TaxiDispatcher.Application.Common.Interfaces;

namespace TaxiDispatcher.Application.Taxis.Commands
{
    public class UpdateTaxiLocationCommand : IRequestWrapper<bool>
    {
        public Guid Id { get; set; }
        public int Location { get; set; }
    }
}
