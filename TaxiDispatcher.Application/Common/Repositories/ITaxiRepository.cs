namespace TaxiDispatcher.Application.Common.Repositories
{
    public interface ITaxiRepository
    {
        Task<Domain.Entities.Taxi> CreateTaxi(Domain.Entities.Taxi taxi);
        Task<Domain.Entities.Taxi> GetTaxiById(Guid id);
        Task<IEnumerable<Domain.Entities.Taxi>> GetAllTaxis();
        Task<Domain.Entities.Taxi> GetTaxiClosestToLocation(int location);
    }
}
