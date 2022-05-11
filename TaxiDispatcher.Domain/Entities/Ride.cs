using TaxiDispatcher.Domain.Common;
using TaxiDispatcher.Domain.Enums;

namespace TaxiDispatcher.Domain.Entities
{
    public class Ride : BaseEntity
    {
        public Ride(Guid id, RideRequest rideRequest, Taxi taxi)
        {
            Id = id;
            RideRequest = rideRequest ?? throw new ArgumentNullException(nameof(rideRequest));
            Taxi = taxi ?? throw new ArgumentNullException(nameof(taxi));
        }

        public RideRequest RideRequest { get; }
        public Taxi Taxi { get; }

        public int Price
        {
            get
            {
                int price = Taxi.TaxiCompany.BasePrice * Math.Abs(RideRequest.LocationFrom - RideRequest.LocationTo);
                int nightRideMultiplier = RideRequest.RideTime.Hour is < 6 or > 22 ? 2 : 1;
                int rideTypeMultiplier = RideRequest.RideType == RideType.InterCity ? 2 : 1;
                return price * rideTypeMultiplier * nightRideMultiplier;
            }
        }
    }
}
