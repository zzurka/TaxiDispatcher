using Microsoft.EntityFrameworkCore;
using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options) { }

        public DbSet<Taxi> Taxis { get; set; } = null!;
        public DbSet<Ride> Rides { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Taxi>().HasKey(x => x.Id);
            modelBuilder.Entity<Taxi>().HasIndex(x => x.DriverId);
            modelBuilder.Entity<TaxiCompany>().HasKey(x => x.Id);
            modelBuilder.Entity<Ride>().HasKey(x => x.Id);
            modelBuilder.Entity<RideRequest>().HasKey(x => x.Id);
        }
    }
}
