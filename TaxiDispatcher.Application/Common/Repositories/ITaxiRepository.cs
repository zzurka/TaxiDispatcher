namespace TaxiDispatcher.Application.Common.Repositories
{
    public interface ITaxiRepository
    {
        Task<Domain.Entities.Taxi> CreateTaxi(Domain.Entities.Taxi taxi);
        Task<Domain.Entities.Taxi?> GetTaxiById(Guid id);
        Task<Domain.Entities.Taxi?> GetTaxiByDriverId(int id);
        Task<IEnumerable<Domain.Entities.Taxi>> GetAllTaxis();
        Task<bool> UpdateTaxiLocation(Guid id, int location);
        Task<IEnumerable<Domain.Entities.TaxiLocation>> GetAllTaxiLocations();
    }
}
