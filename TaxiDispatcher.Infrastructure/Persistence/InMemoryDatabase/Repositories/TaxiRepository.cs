using Microsoft.EntityFrameworkCore;
using TaxiDispatcher.Application.Common.Exceptions;
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

        public async Task<Taxi> GetTaxiById(Guid id)
        {
            Taxi? taxi = await _context.Taxis.Include(x => x.TaxiCompany).FirstOrDefaultAsync(x => x.Id == id);
            return taxi ?? throw new TaxiNotFoundException();
        }

        public async Task<IEnumerable<Taxi>> GetAllTaxis()
        {
            return await _context.Taxis.ToListAsync();
        }

        public Task<Taxi> GetTaxiClosestToLocation(int location)
        {
            throw new NotImplementedException();
        }
    }
}
