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
    /// Represents a RESTful service of Klinik.
    /// </summary>
    [Authorize]
    [ApiVersion(V0_1)]
    [ODataRoutePrefix(nameof(Klinik))]
    public class KlinikController : ODataController
    {
        /// <summary>
        /// Klinik REST service.
        /// </summary>
        /// <param name="context">Database context.</param>
        public KlinikController(PsefMySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves Klinik total count.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <returns>Klinik total count.</returns>
        /// <response code="200">Total count of Klinik retrieved.</response>
        [HttpGet]
        [ODataRoute(nameof(TotalCount))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(long), Status200OK)]
        public async Task<long> TotalCount()
        {
            return await _context.Klinik.LongCountAsync();
        }

        /// <summary>
        /// Retrieves all Klinik.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <returns>All available Klinik.</returns>
        /// <response code="200">Klinik successfully retrieved.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<Klinik>>), Status200OK)]
        [EnableQuery]
        public IQueryable<Klinik> Get()
        {
            return _context.Klinik.Include(e => e.Provinsi);
        }

        /// <summary>
        /// Gets a single Klinik.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Klinik identifier.</param>
        /// <returns>The requested Klinik.</returns>
        /// <response code="200">The Klinik was successfully retrieved.</response>
        /// <response code="404">The Klinik does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Klinik), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public SingleResult<Klinik> Get([FromODataUri] ulong id)
        {
            if (string.IsNullOrEmpty(ApiHelper.GetUserRole(HttpContext.User)))
            {
                return SingleResult.Create(
                    _context.Klinik
                        .Include(e => e.Provinsi)
                        .Where(e =>
                            e.Id == id &&
                            e.Permohonan.Pemohon.UserId == ApiHelper.GetUserId(HttpContext.User)));
            }

            return SingleResult.Create(
                _context.Klinik
                    .Include(e => e.Provinsi)
                    .Where(e => e.Id == id));
        }

        /// <summary>
        /// Creates a new Klinik.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="create">The Klinik to create.</param>
        /// <returns>The created Klinik.</returns>
        /// <response code="201">The Klinik was successfully created.</response>
        /// <response code="204">The Klinik was successfully created.</response>
        /// <response code="400">The Klinik is invalid.</response>
        /// <response code="409">The Klinik with supplied id already exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Klinik), Status201Created)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] Klinik create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Klinik.Add(create);

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
        /// Updates an existing Klinik.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The requested Klinik identifier.</param>
        /// <param name="delta">The partial Klinik to update.</param>
        /// <returns>The updated Klinik.</returns>
        /// <response code="200">The Klinik was successfully updated.</response>
        /// <response code="204">The Klinik was successfully updated.</response>
        /// <response code="400">The Klinik is invalid.</response>
        /// <response code="404">The Klinik does not exist.</response>
        /// <response code="422">The Klinik identifier is specified on delta and its value is different from id.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Klinik), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status422UnprocessableEntity)]
        public async Task<IActionResult> Patch(
            [FromODataUri] ulong id,
            [FromBody] Delta<Klinik> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var update = await _context.Klinik.FindAsync(id);

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
        /// Deletes a Klinik.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The Klinik to delete.</param>
        /// <returns>None</returns>
        /// <response code="204">The Klinik was successfully deleted.</response>
        /// <response code="404">The Klinik does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Delete([FromODataUri] ulong id)
        {
            var delete = await _context.Klinik.FindAsync(id);

            if (delete == null)
            {
                return NotFound();
            }

            _context.Klinik.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Updates an existing Klinik.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Klinik identifier.</param>
        /// <param name="update">The Klinik to update.</param>
        /// <returns>The updated Klinik.</returns>
        /// <response code="200">The Klinik was successfully updated.</response>
        /// <response code="204">The Klinik was successfully updated.</response>
        /// <response code="400">The Klinik is invalid.</response>
        /// <response code="404">The Klinik does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Klinik), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Put(
            [FromODataUri] ulong id,
            [FromBody] Klinik update)
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
            return _context.Klinik.Any(e => e.Id == id);
        }

        private readonly PsefMySqlContext _context;
    }
}
