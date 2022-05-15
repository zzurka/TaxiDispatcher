using TaxiDispatcher.ConsoleClient.Models;

namespace TaxiDispatcher.ConsoleClient.ApiHelpers
{
    public interface ITaxiDispatcherApiClient
    {
        /// <summary>
        /// Orders a ride.
        /// </summary>
        /// <param name="rideRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseResult<Ride>> OrderRide(RideRequest rideRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Accepts a ride.
        /// </summary>
        /// <param name="rideId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseResult<Ride>> AcceptRide(Guid rideId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets driver earning info.
        /// </summary>
        /// <param name="driverId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResponseResult<string>> GetDriverEarnings(int driverId, CancellationToken cancellationToken = default);
    }
}
