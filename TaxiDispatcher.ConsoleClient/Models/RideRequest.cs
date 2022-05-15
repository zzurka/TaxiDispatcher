namespace TaxiDispatcher.ConsoleClient.Models
{
    public class RideRequest
    {
        public int LocationFrom { get; set; }
        public int LocationTo { get; set; }
        public int RideType { get; set; }
        public DateTime RideTime { get; set; }
    }
}
