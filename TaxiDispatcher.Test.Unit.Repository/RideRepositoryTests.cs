using System;
using System.Diagnostics;
using TaxiDispatcher.Domain.Entities;
using TaxiDispatcher.Domain.Enums;
using TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase;
using TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase.Repositories;
using TaxiDispatcher.Test.Shared;
using Xunit;

namespace TaxiDispatcher.Test.Unit.Repository
{
    public class RideRepositoryTests
    {
        [Fact]
        public async void RideRepository_CreateRide()
        {
            // Arrange
            var ride = GetSampleRide();

            InMemoryDbContext context = await InMemoryDbContextMock.GetDatabaseContextEmpty();
            var rideRepository = new RideRepository(context);

            // Act
            await rideRepository.CreateRide(ride);

            // Assert
            Assert.Single(context.Taxis);
        }

        [Fact]
        public async void RideRepository_GetRideById()
        {
            // Arrange
            var ride = GetSampleRide();

            InMemoryDbContext context = await InMemoryDbContextMock.GetDatabaseContextEmpty();
            var rideRepository = new RideRepository(context);
            await rideRepository.CreateRide(ride);

            // Act
            var actual = await rideRepository.GetRideById(ride.Id);

            // Assert
            Assert.NotNull(actual);
            Debug.Assert(actual != null, nameof(actual) + " != null");
            Assert.Equal(actual.Id, ride.Id);
        }

        private static Ride GetSampleRide()
        {
            return new Ride
            {
                Id = Guid.NewGuid(),
                RideRequest = new RideRequest
                {
                    Id = Guid.NewGuid(),
                    LocationFrom = 0,
                    LocationTo = 1,
                    RideTime = DateTime.Now,
                    RideType = RideType.City
                },
                Price = 100,
                RideStatus = RideStatus.Ordered,
                Taxi = new Taxi
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
                }
            };
        }
    }
}
