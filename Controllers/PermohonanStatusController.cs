using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsefApiOData.Models;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static PsefApiOData.ApiInfo;

namespace PsefApiOData.Controllers
{
    /// <summary>
    /// Represents a RESTful service of Permohonan Status.
    /// </summary>
    [Authorize]
    [ApiVersion(V0_1)]
    [ODataRoutePrefix(nameof(PermohonanStatus))]
    public class PermohonanStatusController : ODataController
    {
        /// <summary>
        /// Permohonan Status REST service.
        /// </summary>
        public PermohonanStatusController()
        {
        }

        /// <summary>
        /// Retrieves all Permohonan Status.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <returns>All available Permohonan Status.</returns>
        /// <response code="200">Permohonan Status successfully retrieved.</response>
        [ODataRoute]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<PermohonanStatus>>), Status200OK)]
        [EnableQuery]
        public IQueryable<PermohonanStatus> Get()
        {
            return PermohonanStatus.List.AsQueryable();
        }

        /// <summary>
        /// Gets a single Permohonan Status.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Permohonan Status identifier.</param>
        /// <returns>The requested Permohonan Status.</returns>
        /// <response code="200">The Permohonan Status was successfully retrieved.</response>
        /// <response code="404">The Permohonan Status does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(PermohonanStatus), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public SingleResult<PermohonanStatus> Get([FromODataUri] byte id)
        {
            return SingleResult.Create(PermohonanStatus.List
                .Where(e => e.Id == id)
                .AsQueryable());
        }
    }
}
