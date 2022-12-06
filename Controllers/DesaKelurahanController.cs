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
    /// Represents a RESTful service of Desa/Kelurahan.
    /// </summary>
    [Authorize]
    [ApiVersion(V1_0)]
    [ODataRoutePrefix(nameof(DesaKelurahan))]
    public class DesaKelurahanController : ODataController
    {
        /// <summary>
        /// Desa/Kelurahan REST service.
        /// </summary>
        /// <param name="context">Database context.</param>
        public DesaKelurahanController(PsefMySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves Desa/Kelurahan total count.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <returns>Desa/Kelurahan total count.</returns>
        /// <response code="200">Total count of Desa/Kelurahan retrieved.</response>
        [HttpGet]
        [ODataRoute(nameof(TotalCount))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(long), Status200OK)]
        public async Task<long> TotalCount()
        {
            return await _context.DesaKelurahan.LongCountAsync();
        }

        /// <summary>
        /// Retrieves all Desa/Kelurahan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <returns>All available Desa/Kelurahan.</returns>
        /// <response code="200">Desa/Kelurahan successfully retrieved.</response>
        [ODataRoute]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<DesaKelurahan>>), Status200OK)]
        [EnableQuery]
        public IQueryable<DesaKelurahan> Get()
        {
            return _context.DesaKelurahan;
        }

        /// <summary>
        /// Gets a single Desa/Kelurahan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Desa/Kelurahan identifier.</param>
        /// <returns>The requested Desa/Kelurahan.</returns>
        /// <response code="200">The Desa/Kelurahan was successfully retrieved.</response>
        /// <response code="404">The Desa/Kelurahan does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(DesaKelurahan), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public SingleResult<DesaKelurahan> Get([FromODataUri] uint id)
        {
            return SingleResult.Create(
                _context.DesaKelurahan.Where(e => e.Id == id));
        }

        /// <summary>
        /// Creates a new Desa/Kelurahan.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="create">The Desa/Kelurahan to create.</param>
        /// <returns>The created Desa/Kelurahan.</returns>
        /// <response code="201">The Desa/Kelurahan was successfully created.</response>
        /// <response code="204">The Desa/Kelurahan was successfully created.</response>
        /// <response code="400">The Desa/Kelurahan is invalid.</response>
        /// <response code="409">The Desa/Kelurahan with supplied id already exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(DesaKelurahan), Status201Created)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] DesaKelurahan create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DesaKelurahan.Add(create);

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
        /// Updates an existing Desa/Kelurahan.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The requested Desa/Kelurahan identifier.</param>
        /// <param name="delta">The partial Desa/Kelurahan to update.</param>
        /// <returns>The updated Desa/Kelurahan.</returns>
        /// <response code="200">The Desa/Kelurahan was successfully updated.</response>
        /// <response code="204">The Desa/Kelurahan was successfully updated.</response>
        /// <response code="400">The Desa/Kelurahan is invalid.</response>
        /// <response code="404">The Desa/Kelurahan does not exist.</response>
        /// <response code="422">The Desa/Kelurahan identifier is specified on delta and its value is different from id.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(DesaKelurahan), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status422UnprocessableEntity)]
        public async Task<IActionResult> Patch(
            [FromODataUri] uint id,
            [FromBody] Delta<DesaKelurahan> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var update = await _context.DesaKelurahan.FindAsync(id);

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
        /// Deletes a Desa/Kelurahan.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The Desa/Kelurahan to delete.</param>
        /// <returns>None</returns>
        /// <response code="204">The Desa/Kelurahan was successfully deleted.</response>
        /// <response code="404">The Desa/Kelurahan does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Delete([FromODataUri] uint id)
        {
            var delete = await _context.DesaKelurahan.FindAsync(id);

            if (delete == null)
            {
                return NotFound();
            }

            _context.DesaKelurahan.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Updates an existing Desa/Kelurahan.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The requested Desa/Kelurahan identifier.</param>
        /// <param name="update">The Desa/Kelurahan to update.</param>
        /// <returns>The updated Desa/Kelurahan.</returns>
        /// <response code="200">The Desa/Kelurahan was successfully updated.</response>
        /// <response code="204">The Desa/Kelurahan was successfully updated.</response>
        /// <response code="400">The Desa/Kelurahan is invalid.</response>
        /// <response code="404">The Desa/Kelurahan does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(DesaKelurahan), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Put(
            [FromODataUri] uint id,
            [FromBody] DesaKelurahan update)
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

        private bool Exists(uint id)
        {
            return _context.DesaKelurahan.Any(e => e.Id == id);
        }

        private readonly PsefMySqlContext _context;
    }
}
