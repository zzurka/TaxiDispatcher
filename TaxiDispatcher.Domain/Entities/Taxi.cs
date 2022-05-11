using TaxiDispatcher.Domain.Common;

namespace TaxiDispatcher.Domain.Entities
{
    public class Taxi : BaseEntity
    {
        public Taxi(Guid id, string driverName, TaxiCompany taxiCompany, int location)
        {
            Id = id;
            DriverName = driverName;
            TaxiCompany = taxiCompany;
            Location = location;
        }

        public string DriverName { get; set; }
        public TaxiCompany TaxiCompany { get; set; }
        public int Location { get; set; }

        public int DistanceFromLocation(int location)
        {
            return Math.Abs(Location - location);
        }

        public void DriveToLocation(int location)
        {
            Location = location;
        }
    }
}
