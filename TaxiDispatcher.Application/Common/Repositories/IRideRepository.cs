using TaxiDispatcher.Domain.Entities;
using TaxiDispatcher.Domain.Enums;

namespace TaxiDispatcher.Application.Common.Repositories
{
    public interface IRideRepository
    {
        Task<Ride> CreateRide(Ride ride);
        Task<Ride?> GetRideById(Guid id);
        Task<Ride?> UpdateRideStatusByRideId(Guid id, RideStatus status);
        Task<IEnumerable<Ride>> GetRidesForTaxiId(Guid id);
        Task<IEnumerable<Ride>> GetRidesForDriverId(int id);
    }
}
