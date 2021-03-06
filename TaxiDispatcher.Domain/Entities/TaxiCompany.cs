using TaxiDispatcher.Domain.Common;

namespace TaxiDispatcher.Domain.Entities
{
    public class TaxiCompany : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int BasePrice { get; set; }
        public int InterCityMultiplier { get; set; }
        public int NightRideMultiplier { get; set; }
        public int NightRideHoursFrom { get; set; }
        public int NightRideHoursTo { get; set; }
    }
}
