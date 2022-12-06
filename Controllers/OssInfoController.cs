using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PsefApiOData.Misc;
using PsefApiOData.Models;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static PsefApiOData.ApiInfo;

namespace PsefApiOData.Controllers
{
    /// <summary>
    /// Represents a RESTful service of OSS Information.
    /// </summary>
    [Authorize]
    [ApiVersion(V0_1)]
    [ODataRoutePrefix(nameof(OssInfo))]
    public class OssInfoController : ODataController
    {
        /// <summary>
        /// OSS Information REST service.
        /// </summary>
        /// <param name="ossApi">OSS Api service.</param>
        /// <param name="options">OSS API configuration options.</param>
        public OssInfoController(
            IOssApiService ossApi,
            IOptions<OssApiOptions> options)
        {
            _helper = new OssInfoHelper(ossApi, options);
        }

        /// <summary>
        /// Gets a single OSS Information.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested OSS Information identifier.</param>
        /// <returns>The requested OSS Information.</returns>
        /// <response code="200">The OSS Information was successfully retrieved.</response>
        /// <example>OssInfo('0000000000000')</example>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(OssInfo), Status200OK)]
        public async Task<ActionResult> Get([FromODataUri] string id)
        {
            OssFullInfo fullInfo = await _helper.RetrieveInfo(id);

            return Ok(new OssInfo
            {
                Nib = fullInfo?.Nib ?? string.Empty,
                Address = fullInfo?.AlamatPerseroan ?? string.Empty,
                Name = fullInfo?.NamaPerseroan ?? string.Empty,
                Npwp = fullInfo?.NpwpPerseroan ?? string.Empty,
                Director = fullInfo?.NamaUserProses ?? string.Empty
            });
        }

        /// <summary>
        /// Gets a single OSS Full Information.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested OSS Full Information identifier.</param>
        /// <returns>The requested OSS Full Information.</returns>
        /// <response code="200">The OSS Full Information was successfully retrieved.</response>
        /// <response code="404">The OSS Full Information does not exist.</response>
        /// <example>OssFullInfo('0000000000000')</example>
        [HttpGet]
        [ODataRoute(nameof(OssFullInfo))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(OssFullInfo), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public async Task<SingleResult<OssFullInfo>> OssFullInfo([FromQuery] string id)
        {
            List<OssFullInfo> list = new List<OssFullInfo>
            {
                await _helper.RetrieveInfo(id)
            };

            return SingleResult.Create(list.AsQueryable());
        }

        private readonly OssInfoHelper _helper;
    }
}
