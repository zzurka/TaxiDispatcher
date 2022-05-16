using Microsoft.EntityFrameworkCore;
using TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase;

namespace TaxiDispatcher.Test.Shared
{
    public static class InMemoryDbContextMock
    {
        public static async Task<InMemoryDbContext> GetDatabaseContextEmpty()
        {
            var options = new DbContextOptionsBuilder<InMemoryDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new InMemoryDbContext(options);
            await databaseContext.Database.EnsureCreatedAsync();

            return databaseContext;
        }

        public static async Task<InMemoryDbContext> GetDatabaseContextPopulated()
        {
            InMemoryDbContext context = await GetDatabaseContextEmpty();
            await InMemoryDbContextSeed.SeedSampleData(context);
            return context;
        }
    }
}
