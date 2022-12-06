using System.Threading.Tasks;
using IdentityModel.Client;

namespace PsefApiOData.Misc
{
    /// <summary>
    /// Identity Api service interface.
    /// </summary>
    public interface IIdentityApiService
    {
        /// <summary>
        /// Call Identity API.
        /// </summary>
        /// <param name="token">Access token for the Identity Api.</param>
        /// <param name="uri">Uri of Api.</param>
        /// <typeparam name="T">Type of object to return.</typeparam>
        /// <returns>Object retrieved from the Identity Api.</returns>
        Task<T> CallApiAsync<T>(TokenResponse token, string uri);
    }
}