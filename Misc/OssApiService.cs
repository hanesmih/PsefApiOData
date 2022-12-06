using IdentityModel.Client;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using PsefApiOData.Models;

namespace PsefApiOData.Misc
{
    /// <summary>
    /// OSS (Online Single Submission) API service.
    /// </summary>
    public class OssApiService : IOssApiService
    {
        /// <summary>
        /// OSS API service.
        /// </summary>
        /// <param name="httpClient">Http client to connect to OSS API.</param>
        /// <param name="memoryCache">Memory cache.</param>
        /// <param name="options">OSS API configuration options.</param>
        public OssApiService(
            HttpClient httpClient,
            IMemoryCache memoryCache,
            IOptions<OssApiOptions> options)
        {
            _memoryCache = memoryCache;
            _options = options;
            _httpClient = httpClient;
        }

        /// <summary>
        /// Authenticate to OSS Api.
        /// </summary>
        /// <returns>Token retrieved from the OSS Api authentication endpoint.</returns>
        public async Task<string> Authenticate()
        {
            if (_memoryCache.TryGetValue(
                nameof(JsonWebToken),
                out string cachedToken))
            {
                return cachedToken;
            }

            Dictionary<string, string> formData = new Dictionary<string, string>();
            formData.Add("username", _options.Value.User);
            formData.Add("password", _options.Value.Password);

            HttpResponseMessage response = await _httpClient.PostAsync(
                $"{_options.Value.BaseUri}/api-token-auth/",
                new FormUrlEncodedContent(formData));

            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            OssToken ossToken = JsonConvert.DeserializeObject<OssToken>(
                await response.Content.ReadAsStringAsync());

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(new TimeSpan(_options.Value.CacheHour, 0, 0));

            _memoryCache.Set(nameof(JsonWebToken), ossToken.Token, cacheEntryOptions);
            return ossToken.Token;
        }

        /// <summary>
        /// Call OSS Api with Token auth header.
        /// </summary>
        /// <param name="token">Access token for the OSS Api.</param>
        /// <param name="uri">Uri of Api request.</param>
        /// <param name="content">Content of Api request.</param>
        /// <returns>OSS response from the OSS Api.</returns>
        public async Task<OssResponse> CallApiAsync(string token, string uri, HttpContent content)
        {
            return await CallApiInternalAsync(new AuthenticationHeaderValue("Token", token), uri, content);
        }

        /// <summary>
        /// Call OSS Api with Bearer auth header.
        /// </summary>
        /// <param name="token">Access token for the OSS Api.</param>
        /// <param name="uri">Uri of Api request.</param>
        /// <param name="content">Content of Api request.</param>
        /// <returns>OSS response from the OSS Api.</returns>
        public async Task<OssResponse> CallBearerAuthApiAsync(string token, string uri, HttpContent content)
        {
            return await CallApiInternalAsync(new AuthenticationHeaderValue("Bearer", token), uri, content);
        }

        private async Task<OssResponse> CallApiInternalAsync(
            AuthenticationHeaderValue authenticationHeader,
            string uri,
            HttpContent content)
        {
            HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                $"{_options.Value.BaseUri}{uri}");

            request.Headers.Authorization = authenticationHeader;
            request.Content = content;
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            return new OssResponse
            {
                StatusCode = (int)response.StatusCode,
                Information = response.ReasonPhrase,
                Content = JObject.Parse(await response?.Content?.ReadAsStringAsync() ?? string.Empty)
            };
        }

        internal class OssToken
        {
            public string Token { get; set; }
        }

        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private readonly IOptions<OssApiOptions> _options;
    }
}
