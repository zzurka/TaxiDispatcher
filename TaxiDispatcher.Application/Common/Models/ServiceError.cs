namespace TaxiDispatcher.Application.Common.Models
{
    [Serializable]
    public class ServiceError
    {
        public ServiceError(string message, int code)
        {
            Message = message;
            Code = code;
        }

        public ServiceError() { }

        public string Message { get; } = string.Empty;
        public int Code { get; }

        public static ServiceError DefaultError => new("An exception occurred.", 100);
        public static ServiceError ModelStateError(string validationError) => new(validationError, 101);
        public static ServiceError CustomMessage(string errorMessage) => new(errorMessage, 102);
        public static ServiceError NotFound => new("The specified resource was not found.", 103);
        public static ServiceError ValidationFormat => new("Request object format is not valid.", 104);
        public static ServiceError Validation => new("One or more validation errors occurred.", 105);
        public static ServiceError TaxiNotFound(Guid id) => new($"Taxi (id: {id}) not found.", 106);
        public static ServiceError DriverTaxiNotFound(int id) => new($"Taxi for driver (id: {id}) not found.", 107);
        public static ServiceError RideNotFound(Guid id) => new($"Ride (id: {id}) not found.", 108);
        public static ServiceError NoAvailableTaxiVehicle => new("There are no available taxi vehicles.", 109);

        #region Override Equals Operator

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        /// <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object? obj)
        {
            // If parameter cannot be cast to ServiceError or is null return false.
            var error = obj as ServiceError;

            // Return true if the error codes match. False if the object we're comparing to is nul
            // or if it has a different code.
            return Code == error?.Code;
        }

        public bool Equals(ServiceError error)
        {
            // Return true if the error codes match. False if the object we're comparing to is null
            // or if it has a different code.
            return Code == error.Code;
        }

        public override int GetHashCode()
        {
            return Code;
        }

        public static bool operator ==(ServiceError? a, ServiceError? b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (a is null || b is null)
            {
                return false;
            }

            // Return true if the fields match:
            return a.Equals(b);
        }

        public static bool operator !=(ServiceError a, ServiceError b)
        {
            return !(a == b);
        }

        #endregion
    }
}
