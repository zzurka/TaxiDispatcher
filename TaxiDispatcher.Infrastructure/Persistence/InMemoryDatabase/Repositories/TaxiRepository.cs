using Microsoft.EntityFrameworkCore;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase.Repositories
{
    public class TaxiRepository : ITaxiRepository
    {
        private readonly InMemoryDbContext _context;

        public TaxiRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<Taxi> CreateTaxi(Taxi taxi)
        {
            if (taxi.Id == Guid.Empty)
            {
                taxi.Id = Guid.NewGuid();
            }

            Taxi created = _context.Taxis.Add(taxi).Entity;
            await _context.SaveChangesAsync();
            
            return created;
        }

        public async Task<Taxi?> GetTaxiById(Guid id)
        {
            return await _context.Taxis.Include(x => x.TaxiCompany).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Taxi?> GetTaxiByDriverId(int id)
        {
            return await _context.Taxis.Include(x => x.TaxiCompany).FirstOrDefaultAsync(x => x.DriverId == id);
        }

        public async Task<IEnumerable<Taxi>> GetAllTaxis()
        {
            return await _context.Taxis.ToListAsync();
        }

        public async Task<bool> UpdateTaxiLocation(Guid id, int location)
        {
            Taxi? taxi = await GetTaxiById(id);

            if (taxi == null)
            {
                return false;
            }

            taxi.Location = location;
            _context.Entry(taxi).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TaxiLocation>> GetAllTaxiLocations()
        {
            return await _context.Taxis.Select(x => new TaxiLocation { TaxiId = x.Id, Location = x.Location })
                                       .ToListAsync();
        }
    }
}
