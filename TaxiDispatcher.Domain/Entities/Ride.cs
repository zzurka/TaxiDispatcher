using TaxiDispatcher.Domain.Common;
using TaxiDispatcher.Domain.Enums;

namespace TaxiDispatcher.Domain.Entities
{
    public class Ride : BaseEntity
    {
        public RideRequest RideRequest { get; set; } = null!;
        public Taxi Taxi { get; set; } = null!;
        public RideStatus RideStatus { get; set; }
        public int Price { get; set; }
    }
}
