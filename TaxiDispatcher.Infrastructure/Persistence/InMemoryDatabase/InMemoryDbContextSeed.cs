using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase
{
    public static class InMemoryDbContextSeed
    {
        public static readonly TaxiCompany Naxi = new() { Id = Guid.NewGuid(), Name = "Naxi", BasePrice = 10 };
        public static readonly TaxiCompany Alfa = new() { Id = Guid.NewGuid(), Name = "Alfa", BasePrice = 15 };
        public static readonly TaxiCompany Gold = new() { Id = Guid.NewGuid(), Name = "Gold", BasePrice = 13 };

        public static async Task SeedSampleData(InMemoryDbContext context)
        {
            if (!context.Taxis.Any())
            {
                context.Taxis.Add(new Taxi { Id = Guid.Parse("D67A6C0C-10F2-4D3D-CF34-710539E73796"), DriverName = "Predrag", TaxiCompany = Naxi, Location = 1 });
                context.Taxis.Add(new Taxi { Id = Guid.Parse("6E4846B0-ED79-6E6F-F43B-6E46C29B0D8F"), DriverName = "Nenad", TaxiCompany = Naxi, Location = 4 });
                context.Taxis.Add(new Taxi { Id = Guid.Parse("AE1C67D1-D879-1673-1E40-BE951341E3C7"), DriverName = "Dragan", TaxiCompany = Alfa, Location = 6 });
                context.Taxis.Add(new Taxi { Id = Guid.Parse("3DAF89A4-B492-2419-AE94-FE1869F0DA7A"), DriverName = "Goran", TaxiCompany = Gold, Location = 7 });
            }

            await context.SaveChangesAsync();
        }
    }
}
