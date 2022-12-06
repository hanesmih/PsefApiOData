using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsefApiOData.Misc;
using PsefApiOData.Models;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static PsefApiOData.ApiInfo;

namespace PsefApiOData.Controllers
{
    /// <summary>
    /// Represents a RESTful service of Homepage Banner.
    /// </summary>
    [Authorize]
    [ApiVersion(V1_0)]
    [ODataRoutePrefix(nameof(HomepageBanner))]
    public class HomepageBannerController : ODataController
    {
        /// <summary>
        /// Homepage Banner REST service.
        /// </summary>
        /// <param name="context">Database context.</param>
        public HomepageBannerController(PsefMySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all Homepage Banner.
        /// </summary>
        /// <remarks>
        /// *Anonymous Access*
        /// </remarks>
        /// <returns>All available Homepage Banner.</returns>
        /// <response code="200">Homepage Banner successfully retrieved.</response>
        [AllowAnonymous]
        [ODataRoute]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<HomepageBanner>>), Status200OK)]
        [EnableQuery]
        public IQueryable<HomepageBanner> Get()
        {
            return _context.HomepageBanner;
        }

        /// <summary>
        /// Gets a single Homepage Banner.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Homepage Banner identifier.</param>
        /// <returns>The requested Homepage Banner.</returns>
        /// <response code="200">The Homepage Banner was successfully retrieved.</response>
        /// <response code="404">The Homepage Banner does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(HomepageBanner), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public SingleResult<HomepageBanner> Get([FromODataUri] ushort id)
        {
            return SingleResult.Create(
                _context.HomepageBanner.Where(e => e.Id == id));
        }

        /// <summary>
        /// Creates a new Homepage Banner.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="create">The Homepage Banner to create.</param>
        /// <returns>The created Homepage Banner.</returns>
        /// <response code="201">The Homepage Banner was successfully created.</response>
        /// <response code="204">The Homepage Banner was successfully created.</response>
        /// <response code="400">The Homepage Banner is invalid.</response>
        /// <response code="409">The Homepage Banner with supplied id already exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(HomepageBanner), Status201Created)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] HomepageBanner create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HomepageBanner.Add(create);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Exists(create.Id))
                {
                    return Conflict();
                }

                throw;
            }

            return Created(create);
        }

        /// <summary>
        /// Updates an existing Homepage Banner.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The requested Homepage Banner identifier.</param>
        /// <param name="delta">The partial Homepage Banner to update.</param>
        /// <returns>The updated Homepage Banner.</returns>
        /// <response code="200">The Homepage Banner was successfully updated.</response>
        /// <response code="204">The Homepage Banner was successfully updated.</response>
        /// <response code="400">The Homepage Banner is invalid.</response>
        /// <response code="404">The Homepage Banner does not exist.</response>
        /// <response code="422">The Homepage Banner identifier is specified on delta and its value is different from id.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(HomepageBanner), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status422UnprocessableEntity)]
        public async Task<IActionResult> Patch(
            [FromODataUri] ushort id,
            [FromBody] Delta<HomepageBanner> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var update = await _context.HomepageBanner.FindAsync(id);

            if (update == null)
            {
                return NotFound();
            }

            delta.Patch(update);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException)
            {
                if (update.Id != id)
                {
                    ModelState.AddModelError(nameof(update.Id), DontSetKeyOnPatch);
                    return UnprocessableEntity(ModelState);
                }

                throw;
            }

            return Updated(update);
        }

        /// <summary>
        /// Deletes a Homepage Banner.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The Homepage Banner to delete.</param>
        /// <returns>None</returns>
        /// <response code="204">The Homepage Banner was successfully deleted.</response>
        /// <response code="404">The Homepage Banner does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Delete([FromODataUri] ushort id)
        {
            var delete = await _context.HomepageBanner.FindAsync(id);

            if (delete == null)
            {
                return NotFound();
            }

            _context.HomepageBanner.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool Exists(ushort id)
        {
            return _context.HomepageBanner.Any(e => e.Id == id);
        }

        private readonly PsefMySqlContext _context;
    }
}