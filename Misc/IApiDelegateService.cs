using System.Threading.Tasks;
using IdentityModel.Client;

namespace PsefApiOData.Misc
{
    /// <summary>
    /// Api delegation service interface.
    /// </summary>
    public interface IApiDelegateService
    {
        /// <summary>
        /// Retrieve delegation token for calling another API from this API.
        /// </summary>
        /// <param name="userToken">User token to pass to IdentityServer.</param>
        /// <returns>Access token for the other API.</returns>
        Task<TokenResponse> DelegateAsync(string userToken);
    }
}