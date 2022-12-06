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
    /// Represents a RESTful service of Rumah Sakit.
    /// </summary>
    [Authorize]
    [ApiVersion(V0_1)]
    [ODataRoutePrefix(nameof(RumahSakit))]
    public class RumahSakitController : ODataController
    {
        /// <summary>
        /// Rumah Sakit REST service.
        /// </summary>
        /// <param name="context">Database context.</param>
        public RumahSakitController(PsefMySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves Rumah Sakit total count.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <returns>Rumah Sakit total count.</returns>
        /// <response code="200">Total count of Rumah Sakit retrieved.</response>
        [HttpGet]
        [ODataRoute(nameof(TotalCount))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(long), Status200OK)]
        public async Task<long> TotalCount()
        {
            return await _context.RumahSakit.LongCountAsync();
        }

        /// <summary>
        /// Retrieves all Rumah Sakit.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <returns>All available Rumah Sakit.</returns>
        /// <response code="200">Rumah Sakit successfully retrieved.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<RumahSakit>>), Status200OK)]
        [EnableQuery]
        public IQueryable<RumahSakit> Get()
        {
            return _context.RumahSakit.Include(e => e.Provinsi);
        }

        /// <summary>
        /// Gets a single Rumah Sakit.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Rumah Sakit identifier.</param>
        /// <returns>The requested Rumah Sakit.</returns>
        /// <response code="200">The Rumah Sakit was successfully retrieved.</response>
        /// <response code="404">The Rumah Sakit does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(RumahSakit), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public SingleResult<RumahSakit> Get([FromODataUri] ulong id)
        {
            if (string.IsNullOrEmpty(ApiHelper.GetUserRole(HttpContext.User)))
            {
                return SingleResult.Create(
                    _context.RumahSakit
                        .Include(e => e.Provinsi)
                        .Where(e =>
                            e.Id == id &&
                            e.Permohonan.Pemohon.UserId == ApiHelper.GetUserId(HttpContext.User)));
            }

            return SingleResult.Create(
                _context.RumahSakit
                    .Include(e => e.Provinsi)
                    .Where(e => e.Id == id));
        }

        /// <summary>
        /// Creates a new Rumah Sakit.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="create">The Rumah Sakit to create.</param>
        /// <returns>The created Rumah Sakit.</returns>
        /// <response code="201">The Rumah Sakit was successfully created.</response>
        /// <response code="204">The Rumah Sakit was successfully created.</response>
        /// <response code="400">The Rumah Sakit is invalid.</response>
        /// <response code="409">The Rumah Sakit with supplied id already exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(RumahSakit), Status201Created)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] RumahSakit create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RumahSakit.Add(create);

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
        /// Updates an existing Rumah Sakit.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The requested Rumah Sakit identifier.</param>
        /// <param name="delta">The partial Rumah Sakit to update.</param>
        /// <returns>The updated Rumah Sakit.</returns>
        /// <response code="200">The Rumah Sakit was successfully updated.</response>
        /// <response code="204">The Rumah Sakit was successfully updated.</response>
        /// <response code="400">The Rumah Sakit is invalid.</response>
        /// <response code="404">The Rumah Sakit does not exist.</response>
        /// <response code="422">The Rumah Sakit identifier is specified on delta and its value is different from id.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(RumahSakit), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status422UnprocessableEntity)]
        public async Task<IActionResult> Patch(
            [FromODataUri] ulong id,
            [FromBody] Delta<RumahSakit> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var update = await _context.RumahSakit.FindAsync(id);

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
        /// Deletes a Rumah Sakit.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The Rumah Sakit to delete.</param>
        /// <returns>None</returns>
        /// <response code="204">The Rumah Sakit was successfully deleted.</response>
        /// <response code="404">The Rumah Sakit does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Delete([FromODataUri] ulong id)
        {
            var delete = await _context.RumahSakit.FindAsync(id);

            if (delete == null)
            {
                return NotFound();
            }

            _context.RumahSakit.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Updates an existing Rumah Sakit.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Rumah Sakit identifier.</param>
        /// <param name="update">The Rumah Sakit to update.</param>
        /// <returns>The updated Rumah Sakit.</returns>
        /// <response code="200">The Rumah Sakit was successfully updated.</response>
        /// <response code="204">The Rumah Sakit was successfully updated.</response>
        /// <response code="400">The Rumah Sakit is invalid.</response>
        /// <response code="404">The Rumah Sakit does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(RumahSakit), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Put(
            [FromODataUri] ulong id,
            [FromBody] RumahSakit update)
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
            return _context.RumahSakit.Any(e => e.Id == id);
        }

        private readonly PsefMySqlContext _context;
    }
}
