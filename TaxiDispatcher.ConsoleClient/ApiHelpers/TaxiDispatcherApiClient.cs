using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using TaxiDispatcher.ConsoleClient.Models;

namespace TaxiDispatcher.ConsoleClient.ApiHelpers
{
    public class TaxiDispatcherApiClient : ITaxiDispatcherApiClient
    {
        private readonly string baseAddres;
        private readonly HttpClient httpClient;

        //public TaxiDispatcherApiClient(HttpClient httpClient)
        public TaxiDispatcherApiClient()
        {
            this.baseAddres = "http://localhost:5021";
            this.httpClient = new HttpClient(); // ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<ResponseResult<Ride>> OrderRide(RideRequest rideRequest, CancellationToken cancellationToken = default)
        {
            var url = new Uri($"{baseAddres}/api/Rides/RequestRide");
            var stringContent = new StringContent(JsonConvert.SerializeObject(rideRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, stringContent, cancellationToken);

            var result = new ResponseResult<Ride>();

            if (response.IsSuccessStatusCode)
            {
                ResponseResult<Ride>? responseData = await response.Content.ReadFromJsonAsync<ResponseResult<Ride>>(cancellationToken: cancellationToken);

                if (responseData != null)
                {
                    result = responseData;
                }
            }
            else
            {
                result.Succeeded = false;
                result.Error = new ResponseError { Code = 0, Message = "Bad request." };
            }

            return result;
        }

        public async Task<ResponseResult<Ride>> AcceptRide(Guid rideId, CancellationToken cancellationToken = default)
        {
            var url = new Uri($"{baseAddres}/api/Rides/AcceptRide");
            var stringContent = new StringContent(JsonConvert.SerializeObject(new { Id = rideId }), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, stringContent, cancellationToken);

            var result = new ResponseResult<Ride>();

            if (response.IsSuccessStatusCode)
            {
                ResponseResult<Ride>? responseData = await response.Content.ReadFromJsonAsync<ResponseResult<Ride>>(cancellationToken: cancellationToken);

                if (responseData != null)
                {
                    result = responseData;
                }
            }
            else
            {
                result.Succeeded = false;
                result.Error = new ResponseError { Code = 0, Message = "Bad request." };
            }

            return result;
        }

        public async Task<ResponseResult<string>> GetDriverEarnings(int driverId, CancellationToken cancellationToken = default)
        {
            var url = new Uri($"{baseAddres}/api/Taxis/Driver/{driverId}/Earnings");
            HttpResponseMessage response = await httpClient.GetAsync(url, cancellationToken);

            var result = new ResponseResult<string>();

            if (response.IsSuccessStatusCode)
            {
                ResponseResult<string>? responseData = await response.Content.ReadFromJsonAsync<ResponseResult<string>>(cancellationToken: cancellationToken);

                if (responseData != null)
                {
                    result = responseData;
                }
            }
            else
            {
                result.Succeeded = false;
                result.Error = new ResponseError { Code = 0, Message = "Bad request." };
            }

            return result;
        }
    }
}
