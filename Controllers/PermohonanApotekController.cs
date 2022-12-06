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
    /// Represents a RESTful service of Permohonan Apotek.
    /// </summary>
    [Authorize]
    [ApiVersion(V0_1)]
    [ODataRoutePrefix(nameof(PermohonanApotek))]
    public class PermohonanApotekController : ODataController
    {
        /// <summary>
        /// Permohonan Apotek REST service.
        /// </summary>
        /// <param name="context">Database context.</param>
        public PermohonanApotekController(PsefMySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all Apotek for the specified Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Permohonan identifier.</param>
        /// <returns>All available Apotek for the specified Permohonan.</returns>
        /// <response code="200">List of Apotek successfully retrieved.</response>
        /// <response code="404">The list of Apotek does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<Apotek>>), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery]
        public IQueryable<Apotek> Get(uint id)
        {
            if (string.IsNullOrEmpty(ApiHelper.GetUserRole(HttpContext.User)))
            {
                return _context.Apotek
                    .Include(e => e.Provinsi)
                    .Where(e =>
                        e.PermohonanId == id &&
                        e.Permohonan.Pemohon.UserId == ApiHelper.GetUserId(HttpContext.User));
            }

            return _context.Apotek
                .Include(e => e.Provinsi)
                .Where(e => e.PermohonanId == id);
        }

        /// <summary>
        /// Creates a new list of Apotek for the specified Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="create">The list of Apotek to create.</param>
        /// <returns>None.</returns>
        /// <response code="204">The list of Apotek was successfully created.</response>
        /// <response code="400">The list of Apotek is invalid.</response>
        [Produces(JsonOutput)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<IActionResult> Post(
            [FromBody] PermohonanApotek create)
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

            foreach (Apotek apotek in create.Apotek)
            {
                apotek.Id = 0;
                apotek.PermohonanId = create.PermohonanId;
            }

            await _context.Apotek.AddRangeAsync(create.Apotek);

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
        /// Updates list of Apotek for the specified Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">Unused, please use 1.</param>
        /// <param name="update">The list of Apotek to update.</param>
        /// <returns>None.</returns>
        /// <response code="204">The list of Apotek was successfully updated.</response>
        /// <response code="400">The list of Apotek is invalid.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<IActionResult> Put(
            [FromODataUri] uint id,
            [FromBody] PermohonanApotek update)
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

            foreach (Apotek apotek in update.Apotek)
            {
                if (!_context.Apotek.Any(e =>
                    e.Id == apotek.Id &&
                    e.PermohonanId == update.PermohonanId))
                {
                    return BadRequest();
                }
            }

            _context.UpdateRange(update.Apotek);

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
        /// Deletes list of Apotek for the specified Permohonan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">Unused, please use 1.</param>
        /// <param name="delete">The list of Apotek to delete.</param>
        /// <returns>None.</returns>
        /// <response code="204">The list of Apotek was successfully deleted.</response>
        /// <response code="400">The list of Apotek is invalid.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<IActionResult> Delete(
            [FromODataUri] uint id,
            [FromBody] PermohonanApotek delete)
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

            foreach (Apotek apotek in delete.Apotek)
            {
                if (!_context.Apotek.Any(e =>
                    e.Id == apotek.Id &&
                    e.PermohonanId == delete.PermohonanId))
                {
                    return BadRequest();
                }
            }

            List<Apotek> removed = new List<Apotek>();

            foreach (Apotek apotek in delete.Apotek)
            {
                removed.Add(await _context.Apotek.FindAsync(apotek.Id));
            }

            _context.Apotek.RemoveRange(removed);

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