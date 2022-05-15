namespace TaxiDispatcher.ConsoleClient.Models
{
    public class Ride
    {
        public Guid Id { get; set; }
        public Taxi Taxi { get; set; } = null!;
        public int Price { get; set; }
    }
}
