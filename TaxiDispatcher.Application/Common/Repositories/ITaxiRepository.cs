using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Application.Common.Repositories
{
    public interface ITaxiRepository
    {
        Task<Taxi> CreateTaxi(Taxi taxi);
        Task<Taxi?> GetTaxiById(Guid id);
        Task<Taxi?> GetTaxiByDriverId(int id);
        Task<IEnumerable<Taxi>> GetAllTaxis();
        Task<bool> UpdateTaxiLocation(Guid id, int location);
        Task<IEnumerable<TaxiLocation>> GetAllTaxiLocations();
    }
}
