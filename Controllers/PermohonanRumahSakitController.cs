using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
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
    /// Represents a RESTful service of Permohonan Rumah Sakit.
    /// </summary>
    [Authorize]
    [ApiVersion(V0_1)]
    [ODataRoutePrefix(nameof(PermohonanRumahSakit))]
    public class PermohonanRumahSakitController : ODataController
    {
        /// <summary>
        /// Permohonan Rumah Sakit REST service.
        /// </summary>
        /// <param name="context">Database context.</param>
        public PermohonanRumahSakitController(PsefMySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all Rumah Sakit for the specified Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Permohonan identifier.</param>
        /// <returns>All available Rumah Sakit for the specified Permohonan.</returns>
        /// <response code="200">List of Rumah Sakit successfully retrieved.</response>
        /// <response code="404">The list of Rumah Sakit does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<RumahSakit>>), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery]
        public IQueryable<RumahSakit> Get(uint id)
        {
            if (string.IsNullOrEmpty(ApiHelper.GetUserRole(HttpContext.User)))
            {
                return _context.RumahSakit
                    .Include(e => e.Provinsi)
                    .Where(e =>
                        e.PermohonanId == id &&
                        e.Permohonan.Pemohon.UserId == ApiHelper.GetUserId(HttpContext.User));
            }

            return _context.RumahSakit
                .Include(e => e.Provinsi)
                .Where(e => e.PermohonanId == id);
        }

        /// <summary>
        /// Creates a new list of Rumah Sakit for the specified Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="create">The list of Rumah Sakit to create.</param>
        /// <returns>None.</returns>
        /// <response code="204">The list of Rumah Sakit was successfully created.</response>
        /// <response code="400">The list of Rumah Sakit is invalid.</response>
        [Produces(JsonOutput)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<IActionResult> Post(
            [FromBody] PermohonanRumahSakit create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Permohonan permohonan = string.IsNullOrEmpty(ApiHelper.GetUserRole(HttpContext.User))
                ? await _context.Permohonan
                    .FirstOrDefaultAsync(e =>
                        e.Id == create.PermohonanId &&
                        e.Pemohon.UserId == ApiHelper.GetUserId(HttpContext.User))
                : await _context.Permohonan
                    .FirstOrDefaultAsync(e =>
                        e.Id == create.PermohonanId);

            if (permohonan == null)
            {
                return BadRequest();
            }

            foreach (RumahSakit rumahSakit in create.RumahSakit)
            {
                rumahSakit.Id = 0;
                rumahSakit.PermohonanId = create.PermohonanId;
            }

            await _context.RumahSakit.AddRangeAsync(create.RumahSakit);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Updates list of Rumah Sakit for the specified Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">Unused, please use 1.</param>
        /// <param name="update">The list of Rumah Sakit to update.</param>
        /// <returns>None.</returns>
        /// <response code="204">The list of Rumah Sakit was successfully updated.</response>
        /// <response code="400">The list of Rumah Sakit is invalid.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<IActionResult> Put(
            [FromODataUri] uint id,
            [FromBody] PermohonanRumahSakit update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Permohonan permohonan = string.IsNullOrEmpty(ApiHelper.GetUserRole(HttpContext.User))
                ? await _context.Permohonan
                    .FirstOrDefaultAsync(e =>
                        e.Id == update.PermohonanId &&
                        e.Pemohon.UserId == ApiHelper.GetUserId(HttpContext.User))
                : await _context.Permohonan
                    .FirstOrDefaultAsync(e =>
                        e.Id == update.PermohonanId);

            if (permohonan == null)
            {
                return BadRequest();
            }

            foreach (RumahSakit rumahSakit in update.RumahSakit)
            {
                if (!_context.RumahSakit.Any(e =>
                    e.Id == rumahSakit.Id &&
                    e.PermohonanId == update.PermohonanId))
                {
                    return BadRequest();
                }
            }

            _context.UpdateRange(update.RumahSakit);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes list of Rumah Sakit for the specified Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">Unused, please use 1.</param>
        /// <param name="delete">The list of Rumah Sakit to delete.</param>
        /// <returns>None.</returns>
        /// <response code="204">The list of Rumah Sakit was successfully deleted.</response>
        /// <response code="400">The list of Rumah Sakit is invalid.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<IActionResult> Delete(
            [FromODataUri] uint id,
            [FromBody] PermohonanRumahSakit delete)
        {
            Permohonan permohonan = string.IsNullOrEmpty(ApiHelper.GetUserRole(HttpContext.User))
                ? await _context.Permohonan
                    .FirstOrDefaultAsync(e =>
                        e.Id == delete.PermohonanId &&
                        e.Pemohon.UserId == ApiHelper.GetUserId(HttpContext.User))
                : await _context.Permohonan
                    .FirstOrDefaultAsync(e =>
                        e.Id == delete.PermohonanId);

            if (permohonan == null)
            {
                return BadRequest();
            }

            foreach (RumahSakit rumahSakit in delete.RumahSakit)
            {
                if (!_context.RumahSakit.Any(e =>
                    e.Id == rumahSakit.Id &&
                    e.PermohonanId == delete.PermohonanId))
                {
                    return BadRequest();
                }
            }

            List<RumahSakit> removed = new List<RumahSakit>();

            foreach (RumahSakit rumahSakit in delete.RumahSakit)
            {
                removed.Add(await _context.RumahSakit.FindAsync(rumahSakit.Id));
            }

            _context.RumahSakit.RemoveRange(removed);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return NoContent();
        }

        private readonly PsefMySqlContext _context;
    }
}