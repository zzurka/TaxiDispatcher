using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase
{
    public static class InMemoryDbContextSeed
    {
        public static readonly TaxiCompany Naxi = new()
        {
            Id = Guid.NewGuid(), 
            Name = "Naxi", 
            BasePrice = 10, 
            InterCityMultiplier = 2, 
            NightRideMultiplier = 2, 
            NightRideHoursFrom = 22, 
            NightRideHoursTo = 6
        };

        public static readonly TaxiCompany Alfa = new()
        {
            Id = Guid.NewGuid(), 
            Name = "Alfa", 
            BasePrice = 15,
            InterCityMultiplier = 2,
            NightRideMultiplier = 2,
            NightRideHoursFrom = 22,
            NightRideHoursTo = 6
        };

        public static readonly TaxiCompany Gold = new()
        {
            Id = Guid.NewGuid(), 
            Name = "Gold", 
            BasePrice = 13,
            InterCityMultiplier = 2,
            NightRideMultiplier = 2,
            NightRideHoursFrom = 22,
            NightRideHoursTo = 6
        };

        public static async Task SeedSampleData(InMemoryDbContext context)
        {
            if (!context.Taxis.Any())
            {
                context.Taxis.Add(new Taxi
                {
                    Id = Guid.NewGuid(), 
                    DriverId = 1, 
                    DriverName = "Predrag", 
                    TaxiCompany = Naxi, 
                    Location = 1
                });

                context.Taxis.Add(new Taxi
                {
                    Id = Guid.NewGuid(), 
                    DriverId = 2, 
                    DriverName = "Nenad", 
                    TaxiCompany = Naxi, 
                    Location = 4
                });

                context.Taxis.Add(new Taxi
                {
                    Id = Guid.NewGuid(), 
                    DriverId = 3, 
                    DriverName = "Dragan", 
                    TaxiCompany = Alfa, 
                    Location = 6
                });

                context.Taxis.Add(new Taxi
                {
                    Id = Guid.NewGuid(), 
                    DriverId = 4, 
                    DriverName = "Goran", 
                    TaxiCompany = Gold, 
                    Location = 7
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
