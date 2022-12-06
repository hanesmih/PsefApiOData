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
    /// Represents a RESTful service of Permohonan Type.
    /// </summary>
    [Authorize]
    [ApiVersion(V0_1)]
    [ODataRoutePrefix(nameof(PermohonanType))]
    public class PermohonanTypeController : ODataController
    {
        /// <summary>
        /// Permohonan Type REST service.
        /// </summary>
        public PermohonanTypeController()
        {
        }

        /// <summary>
        /// Retrieves all Permohonan Type.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <returns>All available Permohonan Type.</returns>
        /// <response code="200">Permohonan Type successfully retrieved.</response>
        [ODataRoute]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<PermohonanType>>), Status200OK)]
        [EnableQuery]
        public IQueryable<PermohonanType> Get()
        {
            return PermohonanType.List.AsQueryable();
        }

        /// <summary>
        /// Gets a single Permohonan Type.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Permohonan Type identifier.</param>
        /// <returns>The requested Permohonan Type.</returns>
        /// <response code="200">The Permohonan Type was successfully retrieved.</response>
        /// <response code="404">The Permohonan Type does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(PermohonanType), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public SingleResult<PermohonanType> Get([FromODataUri] byte id)
        {
            return SingleResult.Create(PermohonanType.List
                .Where(e => e.Id == id)
                .AsQueryable());
        }
    }
}
