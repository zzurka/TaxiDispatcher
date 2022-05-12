using System.ComponentModel;

namespace TaxiDispatcher.Domain.Enums
{
    public enum RideType
    {
        [Description("City ride")]
        City,
        [Description("Inter city ride")]
        InterCity
    }
}
