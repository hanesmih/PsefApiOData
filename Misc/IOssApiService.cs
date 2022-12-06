using System.Net.Http;
using System.Threading.Tasks;
using PsefApiOData.Models;

namespace PsefApiOData.Misc
{
    /// <summary>
    /// OSS (Online Single Submission) API service interface.
    /// </summary>
    public interface IOssApiService
    {
        /// <summary>
        /// Authenticate to OSS Api.
        /// </summary>
        /// <returns>Token retrieved from the OSS Api authentication endpoint.</returns>
        Task<string> Authenticate();

        /// <summary>
        /// Call OSS Api with Token auth header.
        /// </summary>
        /// <param name="token">Access token for the OSS Api.</param>
        /// <param name="uri">Uri of Api request.</param>
        /// <param name="content">Content of Api request.</param>
        /// <returns>OSS response from the OSS Api.</returns>
        Task<OssResponse> CallApiAsync(string token, string uri, HttpContent content);

        /// <summary>
        /// Call OSS Api with Bearer auth header.
        /// </summary>
        /// <param name="token">Access token for the OSS Api.</param>
        /// <param name="uri">Uri of Api request.</param>
        /// <param name="content">Content of Api request.</param>
        /// <returns>OSS response from the OSS Api.</returns>
        Task<OssResponse> CallBearerAuthApiAsync(string token, string uri, HttpContent content);
    }
}