using TaxiDispatcher.Application.Repositories;
using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase.Repositories
{
    public class TaxiRepository : ITaxiRepository
    {
        public Taxi GetTaxiById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Taxi> GetAllTaxis()
        {
            throw new NotImplementedException();
        }

        public Taxi GetTaxiClosestToLocation(int location)
        {
            throw new NotImplementedException();
        }
    }
}
