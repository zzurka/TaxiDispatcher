using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Application.Repositories
{
    public interface ITaxiRepository
    {
        Taxi GetTaxiById(Guid id);
        IEnumerable<Taxi> GetAllTaxis();
        Taxi GetTaxiClosestToLocation(int location);
    }
}
