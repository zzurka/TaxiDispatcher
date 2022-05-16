using System;
using System.Threading.Tasks;
using TaxiDispatcher.ConsoleClient.Models;
using Xunit;

namespace TaxiDispatcher.Test.Integration
{
    public class IntegrationTests : BaseIntegrationTest
    {
        public static readonly object?[][] RideRequestResultData =
        {
            // Location from, Location to, Ride type (city: 0, inter city: 1), Time, Success, Error code
            new object?[] { 5, 0, 2, new DateTime(2022, 7, 1, 23, 0, 0), false, 105 },
            new object?[] { 5, 0, 0, new DateTime(2022, 7, 1, 23, 0, 0), true, null },
            new object?[] { 0, 12, 1, new DateTime(2022, 7, 1, 9, 0, 0), true, null },
            new object?[] { 5, 0, 0, new DateTime(2022, 7, 1, 11, 0, 0), true, null },
            new object?[] { 35, 12, 1, new DateTime(2022, 7, 1, 11, 0, 0), false, 109 }
        };

        [Theory, MemberData(nameof(RideRequestResultData))]
        public async Task RidesTest(int from, int to, int type, DateTime time, bool success, int? error)
        {
            // Arrange (InMemoryDbContextSeed)

            // Act
            var rideRequest = new RideRequest
            {
                LocationFrom = from, 
                LocationTo = to, 
                RideType = type, 
                RideTime = time
            };

            ResponseResult<Ride> rideRequestResponse = await RequestRide(rideRequest);

            if (rideRequestResponse.Succeeded && rideRequestResponse.Data != null)
            {
                await AcceptRide(rideRequestResponse.Data.Id);
            }

            // Assert
            Assert.NotNull(rideRequestResponse);
            Assert.Equal(rideRequestResponse.Succeeded, success);
            Assert.Equal(rideRequestResponse.Error?.Code, error);
        }
    }
}
