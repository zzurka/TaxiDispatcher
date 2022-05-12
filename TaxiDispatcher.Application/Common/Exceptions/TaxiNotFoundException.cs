namespace TaxiDispatcher.Application.Common.Exceptions
{
    public class TaxiNotFoundException : Exception
    {
        public TaxiNotFoundException() { }

        public TaxiNotFoundException(string message) : base(message) { }
    }
}
