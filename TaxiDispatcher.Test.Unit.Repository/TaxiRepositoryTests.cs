using System;
using System.Diagnostics;
using TaxiDispatcher.Domain.Entities;
using TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase;
using TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase.Repositories;
using TaxiDispatcher.Test.Shared;
using Xunit;

namespace TaxiDispatcher.Test.Unit.Repository
{
    public class TaxiRepositoryTests
    {
        [Fact]
        public async void TaxiRepository_CreateTaxi()
        {
            // Arrange
            var taxi = GetSampleTaxi();

            InMemoryDbContext context = await InMemoryDbContextMock.GetDatabaseContextEmpty();
            var taxiRepository = new TaxiRepository(context);

            // Act
            await taxiRepository.CreateTaxi(taxi);

            // Assert
            Assert.Single(context.Taxis);
        }

        [Fact]
        public async void TaxiRepository_GetTaxiById()
        {
            // Arrange
            var taxi = GetSampleTaxi();

            InMemoryDbContext context = await InMemoryDbContextMock.GetDatabaseContextEmpty();
            var taxiRepository = new TaxiRepository(context);
            await taxiRepository.CreateTaxi(taxi);

            // Act
            var actual = await taxiRepository.GetTaxiById(taxi.Id);

            // Assert
            Assert.NotNull(actual);
            Debug.Assert(actual != null, nameof(actual) + " != null");
            Assert.Equal(actual.Id, taxi.Id);
        }

        [Fact]
        public async void TaxiRepository_GetTaxiByDriverId()
        {
            // Arrange
            var taxi = GetSampleTaxi();

            InMemoryDbContext context = await InMemoryDbContextMock.GetDatabaseContextEmpty();
            var taxiRepository = new TaxiRepository(context);
            await taxiRepository.CreateTaxi(taxi);

            // Act
            var actual = await taxiRepository.GetTaxiByDriverId(taxi.DriverId);

            // Assert
            Assert.NotNull(actual);
            Debug.Assert(actual != null, nameof(actual) + " != null");
            Assert.Equal(actual.DriverId, taxi.DriverId);
        }

        private static Taxi GetSampleTaxi()
        {
            return new Taxi
            {
                DriverId = 1,
                DriverName = "Pera",
                Location = 0,
                TaxiCompany = new TaxiCompany
                {
                    Id = Guid.NewGuid(),
                    Name = "Pink",
                    BasePrice = 1,
                    InterCityMultiplier = 2,
                    NightRideMultiplier = 2,
                    NightRideHoursFrom = 22,
                    NightRideHoursTo = 7
                }
            };
        }
    }
}