using System.Diagnostics;
using System.Threading;
using TaxiDispatcher.Application.Common.Models;
using TaxiDispatcher.Application.DTO;
using TaxiDispatcher.Application.Rides.Commands;
using TaxiDispatcher.Application.Rides.Handlers;
using TaxiDispatcher.Domain.Enums;
using TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase;
using TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase.Repositories;
using TaxiDispatcher.Test.Shared;
using Xunit;

namespace TaxiDispatcher.Test.Unit.Application
{
    public class RequestRideHandlerTests : BaseApplicationTest
    {
        [Fact]
        public async void RequestRide_Success()
        {
            // Arrange
            InMemoryDbContext context = await InMemoryDbContextMock.GetDatabaseContextPopulated();

            var rideRepository = new RideRepository(context);
            var taxiRepository = new TaxiRepository(context);

            var handler = new RequestRideCommandHandler(rideRepository, taxiRepository, mapper);

            var command = new RequestRideCommand
            {
                LocationFrom = 0,
                LocationTo = 5,
                RideType = RideType.City,
                RideTime = "2022-05-16 12:00:00"
            };

            // Act
            ServiceResult<RideDto> actual = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.NotNull(actual);
            Debug.Assert(actual != null, nameof(actual) + " != null");
            Assert.True(actual.Succeeded);
        }

        [Fact]
        public async void RequestRide_Fail()
        {
            // Arrange
            InMemoryDbContext context = await InMemoryDbContextMock.GetDatabaseContextPopulated();

            var rideRepository = new RideRepository(context);
            var taxiRepository = new TaxiRepository(context);

            var handler = new RequestRideCommandHandler(rideRepository, taxiRepository, mapper);

            var command = new RequestRideCommand
            {
                LocationFrom = 35,
                LocationTo = 8,
                RideType = RideType.City,
                RideTime = "2022-05-16 12:00:00"
            };

            // Act
            ServiceResult<RideDto> actual = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.NotNull(actual);
            Debug.Assert(actual != null, nameof(actual) + " != null");
            Assert.False(actual.Succeeded);
        }
    }
}
