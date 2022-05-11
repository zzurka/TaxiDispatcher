using TaxiDispatcher.Application.Repositories;
using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase.Repositories
{
    public class RideRepository : IRideRepository
    {
        private readonly InMemoryDbContext _context;

        public RideRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public Ride CreateRide(Ride ride)
        {
            Ride created = _context.Rides.Add(ride).Entity;
            _context.SaveChanges();
            return created;
        }

        public Ride GetRideById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ride> GetRidesForTaxiId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
