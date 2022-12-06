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
    /// Represents a RESTful service of Kabupaten/Kota.
    /// </summary>
    [Authorize]
    [ApiVersion(V1_0)]
    [ODataRoutePrefix(nameof(KabupatenKota))]
    public class KabupatenKotaController : ODataController
    {
        /// <summary>
        /// Kabupaten/Kota REST service.
        /// </summary>
        /// <param name="context">Database context.</param>
        public KabupatenKotaController(PsefMySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves Kabupaten/Kota total count.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <returns>Kabupaten/Kota total count.</returns>
        /// <response code="200">Total count of Kabupaten/Kota retrieved.</response>
        [HttpGet]
        [ODataRoute(nameof(TotalCount))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(int), Status200OK)]
        public async Task<int> TotalCount()
        {
            return await _context.KabupatenKota.CountAsync();
        }

        /// <summary>
        /// Retrieves all Kabupaten/Kota.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <returns>All available Kabupaten/Kota.</returns>
        /// <response code="200">Kabupaten/Kota successfully retrieved.</response>
        [ODataRoute]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<KabupatenKota>>), Status200OK)]
        [EnableQuery]
        public IQueryable<KabupatenKota> Get()
        {
            return _context.KabupatenKota;
        }

        /// <summary>
        /// Gets a single Kabupaten/Kota.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Kabupaten/Kota identifier.</param>
        /// <returns>The requested Kabupaten/Kota.</returns>
        /// <response code="200">The Kabupaten/Kota was successfully retrieved.</response>
        /// <response code="404">The Kabupaten/Kota does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(KabupatenKota), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public SingleResult<KabupatenKota> Get([FromODataUri] ushort id)
        {
            return SingleResult.Create(
                _context.KabupatenKota.Where(e => e.Id == id));
        }

        /// <summary>
        /// Creates a new Kabupaten/Kota.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="create">The Kabupaten/Kota to create.</param>
        /// <returns>The created Kabupaten/Kota.</returns>
        /// <response code="201">The Kabupaten/Kota was successfully created.</response>
        /// <response code="204">The Kabupaten/Kota was successfully created.</response>
        /// <response code="400">The Kabupaten/Kota is invalid.</response>
        /// <response code="409">The Kabupaten/Kota with supplied id already exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(KabupatenKota), Status201Created)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] KabupatenKota create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.KabupatenKota.Add(create);

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
        /// Updates an existing Kabupaten/Kota.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The requested Kabupaten/Kota identifier.</param>
        /// <param name="delta">The partial Kabupaten/Kota to update.</param>
        /// <returns>The updated Kabupaten/Kota.</returns>
        /// <response code="200">The Kabupaten/Kota was successfully updated.</response>
        /// <response code="204">The Kabupaten/Kota was successfully updated.</response>
        /// <response code="400">The Kabupaten/Kota is invalid.</response>
        /// <response code="404">The Kabupaten/Kota does not exist.</response>
        /// <response code="422">The Kabupaten/Kota identifier is specified on delta and its value is different from id.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(KabupatenKota), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status422UnprocessableEntity)]
        public async Task<IActionResult> Patch(
            [FromODataUri] ushort id,
            [FromBody] Delta<KabupatenKota> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var update = await _context.KabupatenKota.FindAsync(id);

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
        /// Deletes a Kabupaten/Kota.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The Kabupaten/Kota to delete.</param>
        /// <returns>None</returns>
        /// <response code="204">The Kabupaten/Kota was successfully deleted.</response>
        /// <response code="404">The Kabupaten/Kota does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Delete([FromODataUri] ushort id)
        {
            var delete = await _context.KabupatenKota.FindAsync(id);

            if (delete == null)
            {
                return NotFound();
            }

            _context.KabupatenKota.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Updates an existing Kabupaten/Kota.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The requested Kabupaten/Kota identifier.</param>
        /// <param name="update">The Kabupaten/Kota to update.</param>
        /// <returns>The updated Kabupaten/Kota.</returns>
        /// <response code="200">The Kabupaten/Kota was successfully updated.</response>
        /// <response code="204">The Kabupaten/Kota was successfully updated.</response>
        /// <response code="400">The Kabupaten/Kota is invalid.</response>
        /// <response code="404">The Kabupaten/Kota does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(KabupatenKota), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Put(
            [FromODataUri] ushort id,
            [FromBody] KabupatenKota update)
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
            return _context.KabupatenKota.Any(e => e.Id == id);
        }

        private readonly PsefMySqlContext _context;
    }
}
