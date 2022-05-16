using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaxiDispatcher.ConsoleClient.Models;

namespace TaxiDispatcher.Test.Integration
{
    public class BaseIntegrationTest
    {
        private readonly HttpClient httpClient;
        private const string baseAddress = "http://localhost:5021";

        public BaseIntegrationTest()
        {
            var application = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });
            httpClient = application.CreateClient();
        }

        public async Task<ResponseResult<Ride>> RequestRide(RideRequest rideRequest, CancellationToken cancellationToken = default)
        {
            var url = new Uri($"{baseAddress}/api/Rides/RequestRide");
            var stringContent = new StringContent(JsonConvert.SerializeObject(rideRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, stringContent, cancellationToken);

            return await response.Content.ReadFromJsonAsync<ResponseResult<Ride>>(
                cancellationToken: cancellationToken) ?? new ResponseResult<Ride>();
        }

        public async Task<ResponseResult<Ride>> AcceptRide(Guid rideId, CancellationToken cancellationToken = default)
        {
            var url = new Uri($"{baseAddress}/api/Rides/AcceptRide");
            var stringContent = new StringContent(JsonConvert.SerializeObject(new { Id = rideId }), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, stringContent, cancellationToken);

            return await response.Content.ReadFromJsonAsync<ResponseResult<Ride>>(
                cancellationToken: cancellationToken) ?? new ResponseResult<Ride>();
        }

        public async Task<ResponseResult<string>> GetDriverEarnings(int driverId, CancellationToken cancellationToken = default)
        {
            var url = new Uri($"{baseAddress}/api/Taxis/Driver/{driverId}/Earnings");
            HttpResponseMessage response = await httpClient.GetAsync(url, cancellationToken);

            return await response.Content.ReadFromJsonAsync<ResponseResult<string>>(
                cancellationToken: cancellationToken) ?? new ResponseResult<string>();
        }
    }
}
