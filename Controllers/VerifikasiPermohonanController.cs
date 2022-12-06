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
using Microsoft.Extensions.Logging;
using PsefApiOData.Misc;
using PsefApiOData.Models;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static PsefApiOData.ApiInfo;

namespace PsefApiOData.Controllers
{
    /// <summary>
    /// Represents a RESTful service of Verifikasi Permohonan.
    /// </summary>
    [Authorize]
    [ApiVersion(V0_1)]
    [ODataRoutePrefix(nameof(VerifikasiPermohonan))]
    public class VerifikasiPermohonanController : ODataController
    {
        /// <summary>
        /// Verifikasi Permohonan REST service.
        /// </summary>
        public VerifikasiPermohonanController(
            PsefMySqlContext context,
            ILogger<VerifikasiPermohonanController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all Verifikasi Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: Verifikator*
        /// </remarks>
        /// <returns>All available Verifikasi Permohonan.</returns>
        /// <response code="200">Verifikasi Permohonan successfully retrieved.</response>
        [MultiRoleAuthorize(
            ApiRole.Verifikator,
            ApiRole.Validator,
            ApiRole.Supervisor,
            ApiRole.Timja,
            ApiRole.Dirpenyanfar,
            ApiRole.Dirjen,
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<VerifikasiPermohonan>>), Status200OK)]
        [EnableQuery]
        public IQueryable<VerifikasiPermohonan> Get()
        {
            return _context.VerifikasiPermohonan;
        }

        /// <summary>
        /// Gets a single Verifikasi Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: Verifikator*
        /// </remarks>
        /// <param name="id">The requested Verifikasi Permohonan identifier.</param>
        /// <returns>The requested Verifikasi Permohonan.</returns>
        /// <response code="200">The Verifikasi Permohonan was successfully retrieved.</response>
        /// <response code="404">The Verifikasi Permohonan does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Verifikator,
            ApiRole.Validator,
            ApiRole.Supervisor,
            ApiRole.Timja,
            ApiRole.Dirpenyanfar,
            ApiRole.Dirjen,
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(VerifikasiPermohonan), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public SingleResult<VerifikasiPermohonan> Get([FromODataUri] uint id)
        {
            return SingleResult.Create(
                _context.VerifikasiPermohonan.Where(e => e.Id == id));
        }

        /// <summary>
        /// Creates a new Verifikasi Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: Verifikator*
        /// </remarks>
        /// <param name="create">The Verifikasi Permohonan to create.</param>
        /// <returns>The created Verifikasi Permohonan.</returns>
        /// <response code="201">The Verifikasi Permohonan was successfully created.</response>
        /// <response code="204">The Verifikasi Permohonan was successfully created.</response>
        /// <response code="400">The Verifikasi Permohonan is invalid.</response>
        /// <response code="409">The Verifikasi Permohonan with supplied id already exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Verifikator,
            ApiRole.Validator,
            ApiRole.Supervisor,
            ApiRole.Timja,
            ApiRole.Dirpenyanfar,
            ApiRole.Dirjen,
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(VerifikasiPermohonan), Status201Created)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] VerifikasiPermohonan create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.VerifikasiPermohonan.Add(create);

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
        /// Updates an existing Verifikasi Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: Verifikator*
        /// </remarks>
        /// <param name="id">The requested Verifikasi Permohonan identifier.</param>
        /// <param name="delta">The partial Verifikasi Permohonan to update.</param>
        /// <returns>The updated Permohonan.</returns>
        /// <response code="200">The Verifikasi Permohonan was successfully updated.</response>
        /// <response code="204">The Verifikasi Permohonan was successfully updated.</response>
        /// <response code="400">The Verifikasi Permohonan is invalid.</response>
        /// <response code="404">The Verifikasi Permohonan does not exist.</response>
        /// <response code="422">The Verifikasi Permohonan identifier is specified on delta and its value is different from id.</response>
        [MultiRoleAuthorize(
            ApiRole.Verifikator,
            ApiRole.Validator,
            ApiRole.Supervisor,
            ApiRole.Timja,
            ApiRole.Dirpenyanfar,
            ApiRole.Dirjen,
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(VerifikasiPermohonan), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status422UnprocessableEntity)]
        public async Task<IActionResult> Patch(
            [FromODataUri] uint id,
            [FromBody] Delta<VerifikasiPermohonan> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var update = await _context.VerifikasiPermohonan.FindAsync(id);

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
        /// Deletes a Verifikasi Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The Verifikasi Permohonan to delete.</param>
        /// <returns>None</returns>
        /// <response code="204">The Verifikasi Permohonan was successfully deleted.</response>
        /// <response code="404">The Verifikasi Permohonan does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Delete([FromODataUri] uint id)
        {
            var delete = await _context.VerifikasiPermohonan.FindAsync(id);

            if (delete == null)
            {
                return NotFound();
            }

            _context.VerifikasiPermohonan.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Updates an existing Verifikasi Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The requested Verifikasi Permohonan identifier.</param>
        /// <param name="update">The Verifikasi Permohonan to update.</param>
        /// <returns>The updated Verifikasi Permohonan.</returns>
        /// <response code="200">The Verifikasi Permohonan was successfully updated.</response>
        /// <response code="204">The Verifikasi Permohonan was successfully updated.</response>
        /// <response code="400">The Verifikasi Permohonan is invalid.</response>
        /// <response code="404">The Verifikasi Permohonan does not exist.</response>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(VerifikasiPermohonan), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Put(
            [FromODataUri] uint id,
            [FromBody] VerifikasiPermohonan update)
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

        /// <summary>
        /// Gets a single Verifikasi Permohonan for the current user.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="permohonanId">The requested Permohonan identifier.</param>
        /// <returns>The requested Verifikasi Permohonan.</returns>
        /// <response code="200">The Verifikasi Permohonan was successfully retrieved.</response>
        /// <response code="404">The Verifikasi Permohonan does not exist.</response>
        [ODataRoute(CurrentUser)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(VerifikasiPermohonan), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public SingleResult<VerifikasiPermohonan> GetCurrentUser(uint permohonanId)
        {
            return SingleResult.Create(
                _context.VerifikasiPermohonan.Where(
                    e => e.Permohonan.Pemohon.UserId == ApiHelper.GetUserId(HttpContext.User) &&
                    e.PermohonanId == permohonanId));
        }

        /// <summary>
        /// Gets a single Verifikasi Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="permohonanId">The requested Permohonan identifier.</param>
        /// <returns>The requested Verifikasi Permohonan.</returns>
        /// <response code="200">The Verifikasi Permohonan was successfully retrieved.</response>
        /// <response code="404">The Verifikasi Permohonan does not exist.</response>
        [ODataRoute(nameof(ByPermohonan))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(VerifikasiPermohonan), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public SingleResult<VerifikasiPermohonan> ByPermohonan(uint permohonanId)
        {
            return SingleResult.Create(
                _context.VerifikasiPermohonan.Where(e => e.PermohonanId == permohonanId));
        }

        private bool Exists(uint id)
        {
            return _context.VerifikasiPermohonan.Any(e => e.Id == id);
        }

        private readonly PsefMySqlContext _context;
        private readonly ILogger<VerifikasiPermohonanController> _logger;
    }
}