namespace TaxiDispatcher.Application.Common.Exceptions
{
    public class RideNotFoundException : Exception
    {
        public RideNotFoundException() { }

        public RideNotFoundException(string message) : base(message) { }
    }
}
