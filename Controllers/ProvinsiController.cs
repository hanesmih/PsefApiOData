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
    /// Represents a RESTful service of Provinsi.
    /// </summary>
    [Authorize]
    [ApiVersion(V1_0)]
    [ODataRoutePrefix(nameof(Provinsi))]
    public class ProvinsiController : ODataController
    {
        /// <summary>
        /// Provinsi REST service.
        /// </summary>
        /// <param name="context">Database context.</param>
        public ProvinsiController(PsefMySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves Provinsi total count.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <returns>Provinsi total count.</returns>
        /// <response code="200">Total count of Provinsi retrieved.</response>
        [HttpGet]
        [ODataRoute(nameof(TotalCount))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(int), Status200OK)]
        public async Task<int> TotalCount()
        {
            return await _context.Provinsi.CountAsync();
        }

        /// <summary>
        /// Retrieves all Provinsi.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <returns>All available Provinsi.</returns>
        /// <response code="200">Provinsi successfully retrieved.</response>
        [ODataRoute]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<Provinsi>>), Status200OK)]
        [EnableQuery]
        public IQueryable<Provinsi> Get()
        {
            return _context.Provinsi;
        }

        /// <summary>
        /// Gets a single Provinsi.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Provinsi identifier.</param>
        /// <returns>The requested Provinsi.</returns>
        /// <response code="200">The Provinsi was successfully retrieved.</response>
        /// <response code="404">The Provinsi does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Provinsi), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public SingleResult<Provinsi> Get([FromODataUri] byte id)
        {
            return SingleResult.Create(
                _context.Provinsi.Where(e => e.Id == id));
        }

        /// <summary>
        /// Creates a new Provinsi.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="create">The Provinsi to create.</param>
        /// <returns>The created Provinsi.</returns>
        /// <response code="201">The Provinsi was successfully created.</response>
        /// <response code="204">The Provinsi was successfully created.</response>
        /// <response code="400">The Provinsi is invalid.</response>
        /// <response code="409">The Provinsi with supplied id already exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Provinsi), Status201Created)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] Provinsi create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Provinsi.Add(create);

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
        /// Updates an existing Provinsi.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The requested Provinsi identifier.</param>
        /// <param name="delta">The partial Provinsi to update.</param>
        /// <returns>The updated Provinsi.</returns>
        /// <response code="200">The Provinsi was successfully updated.</response>
        /// <response code="204">The Provinsi was successfully updated.</response>
        /// <response code="400">The Provinsi is invalid.</response>
        /// <response code="404">The Provinsi does not exist.</response>
        /// <response code="422">The Provinsi identifier is specified on delta and its value is different from id.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Provinsi), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status422UnprocessableEntity)]
        public async Task<IActionResult> Patch(
            [FromODataUri] byte id,
            [FromBody] Delta<Provinsi> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var update = await _context.Provinsi.FindAsync(id);

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
        /// Deletes a Provinsi.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The Provinsi to delete.</param>
        /// <returns>None</returns>
        /// <response code="204">The Provinsi was successfully deleted.</response>
        /// <response code="404">The Provinsi does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Delete([FromODataUri] byte id)
        {
            var delete = await _context.Provinsi.FindAsync(id);

            if (delete == null)
            {
                return NotFound();
            }

            _context.Provinsi.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Updates an existing Provinsi.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The requested Provinsi identifier.</param>
        /// <param name="update">The Provinsi to update.</param>
        /// <returns>The updated Provinsi.</returns>
        /// <response code="200">The Provinsi was successfully updated.</response>
        /// <response code="204">The Provinsi was successfully updated.</response>
        /// <response code="400">The Provinsi is invalid.</response>
        /// <response code="404">The Provinsi does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Provinsi), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Put(
            [FromODataUri] byte id,
            [FromBody] Provinsi update)
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

        private bool Exists(byte id)
        {
            return _context.Provinsi.Any(e => e.Id == id);
        }

        private readonly PsefMySqlContext _context;
    }
}
