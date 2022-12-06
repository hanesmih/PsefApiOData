using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace PsefApiOData.Misc
{
    /// <summary>
    /// Api delegation service.
    /// </summary>
    public class ApiDelegateService : IApiDelegateService
    {
        /// <summary>
        /// Api delegation service.
        /// </summary>
        /// <param name="httpClient">Http client to connect to IdentityServer.</param>
        /// <param name="options">Api security configuration options.</param>
        public ApiDelegateService(HttpClient httpClient, IOptions<ApiSecurityOptions> options)
        {
            _httpClient = httpClient;
            _options = options;
        }

        /// <summary>
        /// Retrieve delegation token for calling another API from this API.
        /// </summary>
        /// <param name="userToken">User token to pass to IdentityServer.</param>
        /// <returns>Access token for the other API.</returns>
        public async Task<TokenResponse> DelegateAsync(string userToken)
        {
            var disco = await _httpClient.GetDiscoveryDocumentAsync(
                new DiscoveryDocumentRequest
                {
                    Address = _options.Value.Authority,
                    Policy =
                    {
                        ValidateIssuerName = false,
                        ValidateEndpoints = false,
                    },
                }
            );

            // send custom grant to token endpoint, return response
            return await _httpClient.RequestTokenAsync(new TokenRequest
            {
                Address = disco.TokenEndpoint,
                GrantType = "delegation",

                ClientId = ApiHelper.DelegationClientId,
                ClientSecret = ApiHelper.DelegationClientSecret,

                Parameters =
                {
                    { "scope", ApiHelper.DelegationScope },
                    { "token", userToken}
                }
            });
        }

        private readonly HttpClient _httpClient;
        private readonly IOptions<ApiSecurityOptions> _options;
    }
}