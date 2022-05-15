using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase;

namespace TaxiDispatcher.Test.Unit.Repository
{
    public static class InMemoryDbContextMock
    {
        public static async Task<InMemoryDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<InMemoryDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new InMemoryDbContext(options);
            await databaseContext.Database.EnsureCreatedAsync();

            return databaseContext;
        }
    }
}
