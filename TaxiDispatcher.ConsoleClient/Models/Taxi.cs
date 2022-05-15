namespace TaxiDispatcher.ConsoleClient.Models
{
    public class Taxi
    {
        public Guid Id { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; } = string.Empty;
    }
}
