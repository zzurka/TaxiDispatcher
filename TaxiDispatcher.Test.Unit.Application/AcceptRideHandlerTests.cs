using System;
using System.Diagnostics;
using System.Threading;
using TaxiDispatcher.Application.Common.Models;
using TaxiDispatcher.Application.DTO;
using TaxiDispatcher.Application.Rides.Commands;
using TaxiDispatcher.Application.Rides.Handlers;
using TaxiDispatcher.Domain.Entities;
using TaxiDispatcher.Domain.Enums;
using TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase;
using TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase.Repositories;
using TaxiDispatcher.Test.Shared;
using Xunit;

namespace TaxiDispatcher.Test.Unit.Application
{
    public class AcceptRideHandlerTests : BaseApplicationTest
    {
        [Fact]
        public async void AcceptRide_Success()
        {
            // Arrange
            InMemoryDbContext context = await InMemoryDbContextMock.GetDatabaseContextEmpty();

            var rideRepository = new RideRepository(context);
            var taxiRepository = new TaxiRepository(context);

            var ride = GetSampleRide();

            await rideRepository.CreateRide(ride);

            var handler = new AcceptRideCommandHandler(rideRepository, taxiRepository, mapper);

            var command = new AcceptRideCommand { Id = ride.Id };

            // Act
            ServiceResult<RideDto> actual = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.NotNull(actual);
            Debug.Assert(actual != null, nameof(actual) + " != null");
            Assert.True(actual.Succeeded);
        }

        [Fact]
        public async void AcceptRide_Fail()
        {
            // Arrange
            InMemoryDbContext context = await InMemoryDbContextMock.GetDatabaseContextEmpty();

            var rideRepository = new RideRepository(context);
            var taxiRepository = new TaxiRepository(context);

            var ride = GetSampleRide();

            await rideRepository.CreateRide(ride);

            var handler = new AcceptRideCommandHandler(rideRepository, taxiRepository, mapper);

            var command = new AcceptRideCommand { Id = Guid.Empty };

            // Act
            ServiceResult<RideDto> actual = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.NotNull(actual);
            Debug.Assert(actual != null, nameof(actual) + " != null");
            Assert.False(actual.Succeeded);
        }

        private static Ride GetSampleRide()
        {
            return new Ride
            {
                Id = Guid.NewGuid(),
                Price = 100,
                RideStatus = RideStatus.Ordered,
                RideRequest = new RideRequest
                {
                    Id = Guid.NewGuid(),
                    LocationFrom = 0,
                    LocationTo = 5,
                    RideTime = DateTime.Now,
                    RideType = RideType.City
                },
                Taxi = GetSampleTaxi()
            };
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
