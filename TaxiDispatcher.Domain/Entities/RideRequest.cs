using TaxiDispatcher.Domain.Enums;

namespace TaxiDispatcher.Domain.Entities
{
    public class RideRequest
    {
        public RideRequest(int locationFrom, int locationTo, RideType rideType, DateTime rideTime)
        {
            LocationFrom = locationFrom;
            LocationTo = locationTo;
            RideType = rideType;
            RideTime = rideTime;
        }

        public int LocationFrom { get; }
        public int LocationTo { get; }
        public RideType RideType { get; }
        public DateTime RideTime { get; }
    }
}
