using TaxiDispatcher.Domain.Enums;

namespace TaxiDispatcher.Application.Common.Repositories
{
    public interface IRideRepository
    {
        Task<Domain.Entities.Ride> CreateRide(Domain.Entities.Ride ride);
        Task<Domain.Entities.Ride?> GetRideById(Guid id);
        Task<Domain.Entities.Ride?> UpdateRideStatusByRideId(Guid id, RideStatus status);
        Task<IEnumerable<Domain.Entities.Ride>> GetRidesForTaxiId(Guid id);
        Task<IEnumerable<Domain.Entities.Ride>> GetRidesForDriverId(int id);
    }
}
