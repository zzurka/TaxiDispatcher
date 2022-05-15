using System.Net.Http.Json;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TaxiDispatcher.ConsoleClient.Models;

namespace TaxiDispatcher.ConsoleClient.ApiHelpers
{
    public class TaxiDispatcherApiClient : ITaxiDispatcherApiClient
    {
        private readonly string baseAddress;
        private IHttpClientFactory HttpFactory { get; }

        public TaxiDispatcherApiClient(IConfiguration config, IHttpClientFactory httpFactory)
        {
            this.baseAddress = config.GetValue<string>("TaxiDispatcherApiAddress");
            this.HttpFactory = httpFactory;
        }

        public async Task<ResponseResult<Ride>> OrderRide(RideRequest rideRequest, CancellationToken cancellationToken = default)
        {
            HttpClient httpClient = HttpFactory.CreateClient();
            var url = new Uri($"{baseAddress}/api/Rides/RequestRide");
            var stringContent = new StringContent(JsonConvert.SerializeObject(rideRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, stringContent, cancellationToken);

            return await response.Content.ReadFromJsonAsync<ResponseResult<Ride>>(
                cancellationToken: cancellationToken) ?? new ResponseResult<Ride>();
        }

        public async Task<ResponseResult<Ride>> AcceptRide(Guid rideId, CancellationToken cancellationToken = default)
        {
            HttpClient httpClient = HttpFactory.CreateClient();
            var url = new Uri($"{baseAddress}/api/Rides/AcceptRide");
            var stringContent = new StringContent(JsonConvert.SerializeObject(new { Id = rideId }), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, stringContent, cancellationToken);

            return await response.Content.ReadFromJsonAsync<ResponseResult<Ride>>(
                cancellationToken: cancellationToken) ?? new ResponseResult<Ride>();
        }

        public async Task<ResponseResult<string>> GetDriverEarnings(int driverId, CancellationToken cancellationToken = default)
        {
            var httpClient = HttpFactory.CreateClient();
            var url = new Uri($"{baseAddress}/api/Taxis/Driver/{driverId}/Earnings");
            HttpResponseMessage response = await httpClient.GetAsync(url, cancellationToken);

            return await response.Content.ReadFromJsonAsync<ResponseResult<string>>(
                cancellationToken: cancellationToken) ?? new ResponseResult<string>();
        }
    }
}
