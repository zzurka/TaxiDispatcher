using System.ComponentModel;

namespace TaxiDispatcher.Domain.Enums
{
    public enum RideStatus
    {
        [Description("Ride ordered")]
        Ordered,
        [Description("Ride finished")]
        Finished,
        [Description("Ride canceled")]
        Canceled
    }
}
