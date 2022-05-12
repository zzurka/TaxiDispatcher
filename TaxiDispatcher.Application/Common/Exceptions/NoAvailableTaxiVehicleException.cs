namespace TaxiDispatcher.Application.Common.Exceptions
{
    public class NoAvailableTaxiVehicleException : Exception
    {
        public NoAvailableTaxiVehicleException() { }

        public NoAvailableTaxiVehicleException(string message) : base(message) { }
    }
}
