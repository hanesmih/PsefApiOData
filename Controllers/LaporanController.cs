using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using PsefApiOData.Misc;
using PsefApiOData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static PsefApiOData.ApiInfo;

namespace PsefApiOData.Controllers
{
    /// <summary>
    /// Represents a RESTful service of Laporan.
    /// </summary>
    [Authorize]
    [ApiVersion(V1_0)]
    [ODataRoutePrefix(nameof(Laporan))]
    public class LaporanController : ODataController
    {
        /// <summary>
        /// Laporan REST service.
        /// </summary>
        /// <param name="context">Database context.</param>
        public LaporanController(PsefMySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all Laporan.
        /// </summary>
        /// <remarks>
        /// *Anonymous Access*
        /// </remarks>
        /// <returns>All available Laporan.</returns>
        /// <response code="200">Laporan successfully retrieved.</response>
        [MultiRoleAuthorize(
            ApiRole.Verifikator,
            ApiRole.Validator,
            ApiRole.Supervisor,
            ApiRole.Timja,
            ApiRole.Dirpenyanfar,
            ApiRole.Dirjen,
            ApiRole.Admin,
            ApiRole.SuperAdmin
            )]
        [ODataRoute]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<Laporan>>), Status200OK)]
        [EnableQuery]
        public IQueryable<Laporan> Get()
        {
            return _context.Laporan;
        }

        /// <summary>
        /// Gets a single Laporan.
        /// </summary>
        /// <remarks>
        /// *Min role: None*
        /// </remarks>
        /// <param name="id">The requested Laporan identifier.</param>
        /// <returns>The requested Laporan.</returns>
        /// <response code="200">The Laporan was successfully retrieved.</response>
        /// <response code="404">The Laporan does not exist.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Laporan), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select)]
        public SingleResult<Laporan> Get([FromODataUri] uint id)
        {
            return SingleResult.Create(
                _context.Laporan.Where(e => e.Id == id));
        }

        /// <summary>
        /// Creates a new Laporan.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="create">The Laporan to create.</param>
        /// <returns>The created Laporan.</returns>
        /// <response code="201">The Laporan was successfully created.</response>
        /// <response code="204">The Laporan was successfully created.</response>
        /// <response code="400">The Laporan is invalid.</response>
        /// <response code="409">The Laporan with supplied id already exist.</response>
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Laporan), Status201Created)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] Laporan create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Pemohon pemohon = await _context.Pemohon
                .FirstOrDefaultAsync(c =>
                    c.UserId == ApiHelper.GetUserId(HttpContext.User));

            if (pemohon == null)
            {
                return BadRequest("Pemohon not found");
            }

            create.PemohonId = pemohon.Id;

            _context.Laporan.Add(create);

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
        /// Updates an existing Laporan.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The requested Laporan identifier.</param>
        /// <param name="delta">The partial Laporan to update.</param>
        /// <returns>The updated Laporan.</returns>
        /// <response code="200">The Laporan was successfully updated.</response>
        /// <response code="204">The Laporan was successfully updated.</response>
        /// <response code="400">The Laporan is invalid.</response>
        /// <response code="404">The Laporan does not exist.</response>
        /// <response code="422">The Laporan identifier is specified on delta and its value is different from id.</response>
        [ODataRoute(IdRoute)]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(Laporan), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status422UnprocessableEntity)]
        public async Task<IActionResult> Patch(
            [FromODataUri] uint id,
            [FromBody] Delta<Laporan> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var update = await _context.Laporan.FindAsync(id);

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
        /// Deletes a Laporan.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <param name="id">The Laporan to delete.</param>
        /// <returns>None</returns>
        /// <response code="204">The Laporan was successfully deleted.</response>
        /// <response code="404">The Laporan does not exist.</response>
        [ODataRoute(IdRoute)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Delete([FromODataUri] uint id)
        {
            var delete = await _context.Laporan.FindAsync(id);

            if (delete == null)
            {
                return NotFound();
            }

            _context.Laporan.Remove(delete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [MultiRoleAuthorize(
            ApiRole.Verifikator,
            ApiRole.Validator,
            ApiRole.Supervisor,
            ApiRole.Timja,
            ApiRole.Dirpenyanfar,
            ApiRole.Dirjen,
            ApiRole.Admin,
            ApiRole.SuperAdmin
            )]
        [HttpGet]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<Laporan>>), Status200OK)]
        [EnableQuery]
        public async Task<IQueryable<LaporanView>> GetLaporanAll()
        {
            List<Laporan> laporan = _context.Laporan.Where(c => c.PemohonId != null).ToList();

            if(laporan.Count() == 0)
            {
                NoContent();
            }

            return (await MergeList(laporan, null)).AsQueryable();
        }

        /// <summary>
        /// Retrieves Laporan  by user.
        /// </summary>
        /// <remarks>
        /// *Min role: Admin*
        /// </remarks>
        /// <returns>All available Laporan User.</returns>
        /// <response code="200">Laporan successfully retrieved.</response>
        [HttpGet]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(ODataValue<IEnumerable<LaporanView>>), Status200OK)]
        [EnableQuery]
        public async Task<IQueryable<LaporanView>> GetLaporanUser()
        {
            Pemohon pemohon = await _context.Pemohon.SingleOrDefaultAsync(c => c.UserId == ApiHelper.GetUserId(HttpContext.User));

            if(pemohon == null)
            {
                NoContent();
            }

            List<LaporanView> laporanList = await MergeList(await _context.Laporan.Where(c => c.PemohonId! == pemohon.Id).ToListAsync(), pemohon);

            return laporanList.AsQueryable();
        }

        private Task<List<LaporanView>> MergeList(
            List<Laporan> laporan,
            Pemohon pemohon)
        {
            List<LaporanView> result = new List<LaporanView>();

            foreach(Laporan dt in laporan)
            {
                LaporanView data = new LaporanView();

                data.Id = dt.Id;
                data.keterangan = dt.keterangan;
                data.SubmittedAt = dt.SubmittedAt;
                data.Url = dt.Url;
                data.CompanyName = (pemohon != null) ? pemohon.CompanyName : _context.Pemohon.FirstOrDefault(c => c.Id == dt.PemohonId).CompanyName;

                result.Add(data);
            }

            return Task.FromResult(result);
        }

            private bool Exists(uint id)
        {
            return _context.Laporan.Any(e => e.Id == id);
        }

        private readonly PsefMySqlContext _context;
    }
}
