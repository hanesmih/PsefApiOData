using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PsefApiOData.Models;

namespace PsefApiOData.Misc
{
    /// <summary>
    /// Pemohon with User Information helpers.
    /// </summary>
    public class PemohonUserInfoHelper
    {
        /// <summary>
        /// Pemohon with User Information helpers.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="delegateService">Api delegation service.</param>
        /// <param name="identityApi">Identity Api service.</param>
        public PemohonUserInfoHelper(
            PsefMySqlContext context,
            IApiDelegateService delegateService,
            IIdentityApiService identityApi)
        {
            _identityApi = identityApi;
            _delegateService = delegateService;
            _context = context;
        }

        /// <summary>
        /// Retrieve list of Pemohon with User Information
        /// </summary>
        /// <param name="httpContext">Http context</param>
        /// <returns>List of Pemohon with User Information.</returns>
        public async Task<List<PemohonUserInfo>> RetrieveList(HttpContext httpContext)
        {
            TokenResponse tokenResponse = await _delegateService.DelegateAsync(
                httpContext.Request.Headers["Authorization"][0]["Bearer ".Length..]);
            List<UserInfo> userInfoList = await _identityApi.CallApiAsync<List<UserInfo>>(
                tokenResponse,
                "/BasicUserInfo");
            List<Pemohon> pemohonList = await _context.Pemohon.ToListAsync();
            List<PemohonUserInfo> result = new List<PemohonUserInfo>();

            foreach (Pemohon pemohon in pemohonList)
            {
                UserInfo userInfo = userInfoList.FirstOrDefault(o => o.UserId == pemohon.UserId);

                result.Add(new PemohonUserInfo
                {
                    Pemohon = pemohon,
                    UserInfo = userInfo
                });
            }

            return result;
        }

        /// <summary>
        /// Retrieve Pemohon with User Information for current user
        /// </summary>
        /// <param name="httpContext">Http context</param>
        /// <returns>Pemohon with User Information.</returns>
        public async Task<PemohonUserInfo> RetrieveCurrentUser(HttpContext httpContext)
        {
            Pemohon pemohon = await _context.Pemohon
                .FirstOrDefaultAsync(e => e.UserId == ApiHelper.GetUserId(httpContext.User));

            return await Retrieve(pemohon, httpContext);
        }

        /// <summary>
        /// Retrieve Pemohon with User Information
        /// </summary>
        /// <param name="id">Pemohon identifier</param>
        /// <param name="httpContext">Http context</param>
        /// <returns>Pemohon with User Information.</returns>
        public async Task<PemohonUserInfo> Retrieve(uint id, HttpContext httpContext)
        {
            Pemohon pemohon;

            if (string.IsNullOrEmpty(ApiHelper.GetUserRole(httpContext.User)))
            {
                pemohon = await _context.Pemohon
                    .Where(e => e.Id == id && e.UserId == ApiHelper.GetUserId(httpContext.User))
                    .FirstOrDefaultAsync();
            }
            else
            {
                pemohon = await _context.Pemohon
                    .Where(e => e.Id == id)
                    .FirstOrDefaultAsync();
            }

            return await Retrieve(pemohon, httpContext);
        }

        /// <summary>
        /// Retrieve Pemohon with User Information
        /// </summary>
        /// <param name="pemohon">Pemohon data.</param>
        /// <param name="httpContext">Http context</param>
        /// <returns>Pemohon with User Information.</returns>
        public async Task<PemohonUserInfo> Retrieve(Pemohon pemohon, HttpContext httpContext)
        {
            if (pemohon == null)
            {
                return null;
            }

            TokenResponse tokenResponse = await _delegateService.DelegateAsync(
                httpContext.Request.Headers["Authorization"][0]["Bearer ".Length..]);
            UserInfo userInfo = await _identityApi.CallApiAsync<UserInfo>(
                tokenResponse,
                $"/BasicUserInfo/{pemohon.UserId}");

            return new PemohonUserInfo()
            {
                Pemohon = pemohon,
                UserInfo = userInfo
            };
        }

        private readonly PsefMySqlContext _context;
        private readonly IApiDelegateService _delegateService;
        private readonly IIdentityApiService _identityApi;
    }
}