using Microsoft.EntityFrameworkCore;
using TaxiDispatcher.Application.Common.Exceptions;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Domain.Entities;
using TaxiDispatcher.Domain.Enums;

namespace TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase.Repositories
{
    public class RideRepository : IRideRepository
    {
        private readonly InMemoryDbContext _context;

        public RideRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<Ride> CreateRide(Ride ride)
        {
            if (ride.Id == Guid.Empty)
            {
                ride.Id = Guid.NewGuid();
            }
            Ride created = _context.Rides.Add(ride).Entity;
            await _context.SaveChangesAsync();
            return created;
        }

        public async Task<Ride> GetRideById(Guid id)
        {
            Ride? ride = await _context.Rides.FirstOrDefaultAsync(x => x.Id == id);
            return ride ?? throw new RideNotFoundException();
        }

        public async Task UpdateRideStatusByRideId(Guid id, RideStatus status)
        {
            Ride ride = await GetRideById(id);
            ride.RideStatus = status;
            _context.Entry(ride).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ride>> GetRidesForTaxiId(Guid id)
        {
            return await _context.Rides.Where(x => x.Taxi.Id == id).ToListAsync();
        }
    }
}
