using TaxiDispatcher.ConsoleClient.ApiHelpers;
using TaxiDispatcher.ConsoleClient.Models;

namespace TaxiDispatcher.ConsoleClient
{
    public class ConsoleClient
    {
        private readonly ITaxiDispatcherApiClient _taxiDispatcher;

        public ConsoleClient(ITaxiDispatcherApiClient taxiDispatcher)
        {
            _taxiDispatcher = taxiDispatcher;
        }

        public async Task Run()
        {
            await OrderRide(5, 0, 0, new DateTime(2018, 1, 1, 23, 0, 0));

            Console.WriteLine();

            await OrderRide(0, 12, 1, new DateTime(2018, 1, 1, 9, 0, 0));

            Console.WriteLine();

            await OrderRide(5, 0, 0, new DateTime(2018, 1, 1, 11, 0, 0));

            Console.WriteLine();

            await OrderRide(35, 12, 0, new DateTime(2018, 1, 1, 11, 0, 0));

            Console.WriteLine();

            await GetDriverEarnings(2);

            Console.ReadLine();
        }

        private async Task OrderRide(int from, int to, int type, DateTime time)
        {
            Console.WriteLine($"Ordering ride from {from} to {to} ...");

            var request = new RideRequest { LocationFrom = from, LocationTo = to, RideType = type, RideTime = time };

            ResponseResult<Ride> rideRequestResponse = await _taxiDispatcher.OrderRide(request);

            if (rideRequestResponse.Succeeded && rideRequestResponse.Data != null)
            {
                int price = rideRequestResponse.Data.Price;
                Guid rideId = rideRequestResponse.Data.Id;

                Console.WriteLine("Ride ordered, price: " + price);

                ResponseResult<Ride> acceptRideResponse = await _taxiDispatcher.AcceptRide(rideId);

                if (acceptRideResponse.Succeeded && acceptRideResponse.Data != null)
                {
                    Console.WriteLine($"Ride accepted, waiting for driver: {acceptRideResponse.Data.Taxi.DriverName}");
                }
                else
                {
                    Console.WriteLine($"{acceptRideResponse.Error?.Message}");
                }
            }
            else
            {
                Console.WriteLine($"{rideRequestResponse.Error?.Message}");
            }
        }

        private async Task GetDriverEarnings(int driverId)
        {
            Console.WriteLine($"Driver with ID = {driverId} earned today:");

            ResponseResult<string> driverEarnings = await _taxiDispatcher.GetDriverEarnings(driverId);

            if (driverEarnings.Succeeded && driverEarnings.Data != null)
            {
                Console.WriteLine(driverEarnings.Data.ToString());
            }
            else
            {
                Console.WriteLine($"{driverEarnings.Error?.Message}");
            }
        }
    }
}
