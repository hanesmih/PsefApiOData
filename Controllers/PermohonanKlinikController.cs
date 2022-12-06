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
    /// Represents a RESTful service of Permohonan Klinik.
    /// </summary>
    [Authorize]
    [ApiVersion(V0_1)]
    [ODataRoutePrefix(nameof(PermohonanKlinik))]
    public class PermohonanKlinikController : ODataController
    {
        /// <summary>
        /// Permohonan Klinik REST service.
        /// </summary>
        /// <param name="context">Database context.</param>
        public PermohonanKlinikController(PsefMySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all Klinik for the specified Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Permohonan identifier.</param>
        /// <returns>All available Klinik for the specified Permohonan.</returns>
        /// <response code="200">List of Klinik successfully retrieved.</response>
        /// <response code="404">The list of Klinik does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<Klinik>>), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery]
        public IQueryable<Klinik> Get(uint id)
        {
            if (string.IsNullOrEmpty(ApiHelper.GetUserRole(HttpContext.User)))
            {
                return _context.Klinik
                    .Include(e => e.Provinsi)
                    .Where(e =>
                        e.PermohonanId == id &&
                        e.Permohonan.Pemohon.UserId == ApiHelper.GetUserId(HttpContext.User));
            }

            return _context.Klinik
                .Include(e => e.Provinsi)
                .Where(e => e.PermohonanId == id);
        }

        /// <summary>
        /// Creates a new list of Klinik for the specified Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="create">The list of Klinik to create.</param>
        /// <returns>None.</returns>
        /// <response code="204">The list of Klinik was successfully created.</response>
        /// <response code="400">The list of Klinik is invalid.</response>
        [Produces(JsonOutput)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<IActionResult> Post(
            [FromBody] PermohonanKlinik create)
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

            foreach (Klinik klinik in create.Klinik)
            {
                klinik.Id = 0;
                klinik.PermohonanId = create.PermohonanId;
            }

            await _context.Klinik.AddRangeAsync(create.Klinik);

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
        /// Updates list of Klinik for the specified Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">Unused, please use 1.</param>
        /// <param name="update">The list of Klinik to update.</param>
        /// <returns>None.</returns>
        /// <response code="204">The list of Klinik was successfully updated.</response>
        /// <response code="400">The list of Klinik is invalid.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<IActionResult> Put(
            [FromODataUri] uint id,
            [FromBody] PermohonanKlinik update)
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

            foreach (Klinik klinik in update.Klinik)
            {
                if (!_context.Klinik.Any(e =>
                    e.Id == klinik.Id &&
                    e.PermohonanId == update.PermohonanId))
                {
                    return BadRequest();
                }
            }

            _context.UpdateRange(update.Klinik);

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
        /// Deletes list of Klinik for the specified Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">Unused, please use 1.</param>
        /// <param name="delete">The list of Klinik to delete.</param>
        /// <returns>None.</returns>
        /// <response code="204">The list of Klinik was successfully deleted.</response>
        /// <response code="400">The list of Klinik is invalid.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<IActionResult> Delete(
            [FromODataUri] uint id,
            [FromBody] PermohonanKlinik delete)
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

            foreach (Klinik klinik in delete.Klinik)
            {
                if (!_context.Klinik.Any(e =>
                    e.Id == klinik.Id &&
                    e.PermohonanId == delete.PermohonanId))
                {
                    return BadRequest();
                }
            }

            List<Klinik> removed = new List<Klinik>();

            foreach (Klinik klinik in delete.Klinik)
            {
                removed.Add(await _context.Klinik.FindAsync(klinik.Id));
            }

            _context.Klinik.RemoveRange(removed);

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