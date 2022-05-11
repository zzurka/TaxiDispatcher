using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Application.Repositories
{
    public interface IRideRepository
    {
        Ride CreateRide(Ride ride);
        Ride GetRideById(Guid id);
        IEnumerable<Ride> GetRidesForTaxiId(Guid id);
    }
}
