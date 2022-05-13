using TaxiDispatcher.Domain.Common;
using TaxiDispatcher.Domain.Enums;

namespace TaxiDispatcher.Domain.Entities
{
    public class RideRequest : BaseEntity
    {
        public int LocationFrom { get; set; }
        public int LocationTo { get; set; }
        public RideType RideType { get; set; }
        public DateTime RideTime { get; set; }
    }
}
