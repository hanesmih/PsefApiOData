using IdentityModel.Client;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PsefApiOData.Misc
{
    /// <summary>
    /// Identity Api service.
    /// </summary>
    public class IdentityApiService : IIdentityApiService
    {
        /// <summary>
        /// Identity Api service.
        /// </summary>
        /// <param name="httpClient">Http client to connect to Identity Api.</param>
        public IdentityApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Call Identity Api.
        /// </summary>
        /// <param name="token">Access token for the Identity Api.</param>
        /// <param name="uri">Uri of Api.</param>
        /// <typeparam name="T">Type of object to return.</typeparam>
        /// <returns>Object retrieved from the Identity Api.</returns>
        public async Task<T> CallApiAsync<T>(TokenResponse token, string uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Get,
                $"{ApiHelper.DelegationBaseUri}{uri}");

            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                token.AccessToken);

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            string content = await response.Content.ReadAsStringAsync();
            T result = JsonConvert.DeserializeObject<T>(content);

            return result;
        }

        private readonly HttpClient _httpClient;
    }
}