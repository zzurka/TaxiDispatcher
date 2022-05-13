using TaxiDispatcher.Domain.Common;

namespace TaxiDispatcher.Domain.Entities
{
    public class Taxi : BaseEntity
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public TaxiCompany TaxiCompany { get; set; } = null!;
        public int Location { get; set; }
    }
}
