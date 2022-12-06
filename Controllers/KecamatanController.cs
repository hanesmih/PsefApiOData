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
    /// Represents a RESTful service of Kecamatan.
    /// </summary>
    [Authorize]
    [ApiVersion(V1_0)]
    [ODataRoutePrefix(nameof(Kecamatan))]
    public class KecamatanController : ODataController
    {
        /// <summary>
        /// Kecamatan REST service.
        /// </summary>
        /// <param name="context">Database context.</param>
        public KecamatanController(PsefMySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves Kecamatan total count.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <returns>Kecamatan total count.</returns>
        /// <response code="200">Total count of Kecamatan retrieved.</response>
        [HttpGet]
        [ODataRoute(nameof(TotalCount))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(int), Status200OK)]
        public async Task<int> TotalCount()
        {
            return await _context.Kecamatan.CountAsync();
        }

        /// <summary>
        /// Retrieves all Kecamatan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <returns>All available Kecamatan.</returns>
        /// <response code="200">Kecamatan successfully retrieved.</response>
        [ODataRoute]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<Kecamatan>>), Status200OK)]
        [EnableQuery]
        public IQueryable<Kecamatan> Get()
        {
            return _context.Kecamatan;
        }

        /// <summary>
        /// Gets a single Kecamatan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Kecamatan identifier.</param>
        /// <returns>The requested Kecamatan.</returns>
        /// <response code="200">The Kecamatan was successfully retrieved.</response>
        /// <response code="404">The Kecamatan does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Kecamatan), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public SingleResult<Kecamatan> Get([FromODataUri] ushort id)
        {
            return SingleResult.Create(
                _context.Kecamatan.Where(e => e.Id == id));
        }

        /// <summary>
        /// Creates a new Kecamatan.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="create">The Kecamatan to create.</param>
        /// <returns>The created Kecamatan.</returns>
        /// <response code="201">The Kecamatan was successfully created.</response>
        /// <response code="204">The Kecamatan was successfully created.</response>
        /// <response code="400">The Kecamatan is invalid.</response>
        /// <response code="409">The Kecamatan with supplied id already exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Kecamatan), Status201Created)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] Kecamatan create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Kecamatan.Add(create);

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
        /// Updates an existing Kecamatan.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The requested Kecamatan identifier.</param>
        /// <param name="delta">The partial Kecamatan to update.</param>
        /// <returns>The updated Kecamatan.</returns>
        /// <response code="200">The Kecamatan was successfully updated.</response>
        /// <response code="204">The Kecamatan was successfully updated.</response>
        /// <response code="400">The Kecamatan is invalid.</response>
        /// <response code="404">The Kecamatan does not exist.</response>
        /// <response code="422">The Kecamatan identifier is specified on delta and its value is different from id.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Kecamatan), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status422UnprocessableEntity)]
        public async Task<IActionResult> Patch(
            [FromODataUri] ushort id,
            [FromBody] Delta<Kecamatan> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var update = await _context.Kecamatan.FindAsync(id);

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
        /// Deletes a Kecamatan.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The Kecamatan to delete.</param>
        /// <returns>None</returns>
        /// <response code="204">The Kecamatan was successfully deleted.</response>
        /// <response code="404">The Kecamatan does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Delete([FromODataUri] ushort id)
        {
            var delete = await _context.Kecamatan.FindAsync(id);

            if (delete == null)
            {
                return NotFound();
            }

            _context.Kecamatan.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Updates an existing Kecamatan.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The requested Kecamatan identifier.</param>
        /// <param name="update">The Kecamatan to update.</param>
        /// <returns>The updated Kecamatan.</returns>
        /// <response code="200">The Kecamatan was successfully updated.</response>
        /// <response code="204">The Kecamatan was successfully updated.</response>
        /// <response code="400">The Kecamatan is invalid.</response>
        /// <response code="404">The Kecamatan does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Kecamatan), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Put(
            [FromODataUri] ushort id,
            [FromBody] Kecamatan update)
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

        private bool Exists(ushort id)
        {
            return _context.Kecamatan.Any(e => e.Id == id);
        }

        private readonly PsefMySqlContext _context;
    }
}
