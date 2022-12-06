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
    /// Represents a RESTful service of Apotek.
    /// </summary>
    [Authorize]
    [ApiVersion(V0_1)]
    [ODataRoutePrefix(nameof(Apotek))]
    public class ApotekController : ODataController
    {
        /// <summary>
        /// Apotek REST service.
        /// </summary>
        /// <param name="context">Database context.</param>
        public ApotekController(PsefMySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves Apotek total count.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <returns>Apotek total count.</returns>
        /// <response code="200">Total count of Apotek retrieved.</response>
        [HttpGet]
        [ODataRoute(nameof(TotalCount))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(long), Status200OK)]
        public async Task<long> TotalCount()
        {
            return await _context.Apotek.LongCountAsync();
        }

        /// <summary>
        /// Retrieves all Apotek.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <returns>All available Apotek.</returns>
        /// <response code="200">Apotek successfully retrieved.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<Apotek>>), Status200OK)]
        [EnableQuery]
        public IQueryable<Apotek> Get()
        {
            return _context.Apotek.Include(e => e.Provinsi);
        }

        /// <summary>
        /// Gets a single Apotek.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Apotek identifier.</param>
        /// <returns>The requested Apotek.</returns>
        /// <response code="200">The Apotek was successfully retrieved.</response>
        /// <response code="404">The Apotek does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Apotek), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public SingleResult<Apotek> Get([FromODataUri] ulong id)
        {
            if (string.IsNullOrEmpty(ApiHelper.GetUserRole(HttpContext.User)))
            {
                return SingleResult.Create(
                    _context.Apotek
                        .Include(e => e.Provinsi)
                        .Where(e =>
                            e.Id == id &&
                            e.Permohonan.Pemohon.UserId == ApiHelper.GetUserId(HttpContext.User)));
            }

            return SingleResult.Create(
                _context.Apotek
                    .Include(e => e.Provinsi)
                    .Where(e => e.Id == id));
        }

        /// <summary>
        /// Creates a new Apotek.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="create">The Apotek to create.</param>
        /// <returns>The created Apotek.</returns>
        /// <response code="201">The Apotek was successfully created.</response>
        /// <response code="204">The Apotek was successfully created.</response>
        /// <response code="400">The Apotek is invalid.</response>
        /// <response code="409">The Apotek with supplied id already exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Apotek), Status201Created)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] Apotek create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Apotek.Add(create);

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
        /// Updates an existing Apotek.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The requested Apotek identifier.</param>
        /// <param name="delta">The partial Apotek to update.</param>
        /// <returns>The updated Apotek.</returns>
        /// <response code="200">The Apotek was successfully updated.</response>
        /// <response code="204">The Apotek was successfully updated.</response>
        /// <response code="400">The Apotek is invalid.</response>
        /// <response code="404">The Apotek does not exist.</response>
        /// <response code="422">The Apotek identifier is specified on delta and its value is different from id.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Apotek), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status422UnprocessableEntity)]
        public async Task<IActionResult> Patch(
            [FromODataUri] ulong id,
            [FromBody] Delta<Apotek> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var update = await _context.Apotek.FindAsync(id);

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
        /// Deletes a Apotek.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The Apotek to delete.</param>
        /// <returns>None</returns>
        /// <response code="204">The Apotek was successfully deleted.</response>
        /// <response code="404">The Apotek does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Delete([FromODataUri] ulong id)
        {
            var delete = await _context.Apotek.FindAsync(id);

            if (delete == null)
            {
                return NotFound();
            }

            _context.Apotek.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Updates an existing Apotek.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Apotek identifier.</param>
        /// <param name="update">The Apotek to update.</param>
        /// <returns>The updated Apotek.</returns>
        /// <response code="200">The Apotek was successfully updated.</response>
        /// <response code="204">The Apotek was successfully updated.</response>
        /// <response code="400">The Apotek is invalid.</response>
        /// <response code="404">The Apotek does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Apotek), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Put(
            [FromODataUri] ulong id,
            [FromBody] Apotek update)
        {
            if (id != update.Id)
            {
                return BadRequest();
            }

            _context.Entry(update).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return Updated(update);
        }

        private bool Exists(ulong id)
        {
            return _context.Apotek.Any(e => e.Id == id);
        }

        private readonly PsefMySqlContext _context;
    }
}
