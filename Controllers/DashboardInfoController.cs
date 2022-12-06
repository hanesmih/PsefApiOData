using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Newtonsoft.Json.Linq;
using PsefApiOData.Misc;
using PsefApiOData.Models;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static PsefApiOData.ApiInfo;

namespace PsefApiOData.Controllers
{
    /// <summary>
    /// Represents a RESTful service of Dashboard Info.
    /// </summary>
    [Authorize]
    [ApiVersion(V0_1)]
    public class DashboardInfoController : ODataController
    {
        /// <summary>
        /// Permohonan REST service.
        /// </summary>
        /// <param name="context">Database context.</param>
        public DashboardInfoController(
            PsefMySqlContext context)
        {
            _context = context;
            _helper = new PermohonanHelper(context);
        }

        /// <summary>
        /// Retrieves Pemohon Dashboard Info.
        /// </summary>
        /// <remarks>
        /// *Role: None*
        /// </remarks>
        /// <returns>Pemohon Dashboard Info.</returns>
        /// <response code="200">Pemohon Dashboard Info.</response>
        [HttpGet]
        [ODataRoute(nameof(DashboardPemohon))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(DashboardInfo), Status200OK)]
        public async Task<ActionResult> DashboardPemohon()
        {
            return Ok(new DashboardInfo
            {
                TotalPemohon = 1,
                TotalPermohonanPending = await TotalPermohonanPemohonPending(),
                TotalPermohonan = await TotalPermohonanPemohon(),
                TotalPerizinan = await TotalPerizinanPemohon(),
                Aktifitas = await Aktifitas()
            });
        }

        /// <summary>
        /// Retrieves Admin Dashboard Info.
        /// </summary>
        /// <remarks>
        /// *Role: Admin*
        /// </remarks>
        /// <returns>Admin Info.</returns>
        /// <response code="200">Admin Dashboard Info.</response>
        [MultiRoleAuthorize(ApiRole.Admin)]
        [HttpGet]
        [ODataRoute(nameof(DashboardAdmin))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(DashboardInfo), Status200OK)]
        public async Task<ActionResult> DashboardAdmin()
        {
            return Ok(new DashboardInfo
            {
                TotalPemohon = await TotalPemohon(),
                TotalPermohonanPending = 0,
                TotalPermohonan = await TotalPermohonan(),
                TotalPermohonanDalamProses = await TotalPermohonanDalamProses(),
                TotalPermohonanDitolak = await TotalPermohonanDitolak(),
                TotalPerizinan = await TotalPerizinan(),
                Aktifitas = await Aktifitas()
            });
        }

        /// <summary>
        /// Retrieves Verifikator Dashboard Info.
        /// </summary>
        /// <remarks>
        /// *Role: Verifikator*
        /// </remarks>
        /// <returns>Verifikator Dashboard Info.</returns>
        /// <response code="200">Verifikator Dashboard Info.</response>
        [MultiRoleAuthorize(ApiRole.Verifikator)]
        [HttpGet]
        [ODataRoute(nameof(DashboardVerifikator))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(DashboardInfo), Status200OK)]
        public async Task<ActionResult> DashboardVerifikator()
        {
            return Ok(new DashboardInfo
            {
                TotalPemohon = await TotalPemohon(),
                TotalPermohonanPending = await _helper.Verifikator().LongCountAsync(),
                TotalPermohonan = await TotalPermohonan(),
                TotalPermohonanDalamProses = await TotalPermohonanDalamProses(),
                TotalPermohonanDitolak = await TotalPermohonanDitolak(),
                TotalPerizinan = await TotalPerizinan(),
                Aktifitas = await Aktifitas()
            });
        }

        /// <summary>
        /// Retrieves Kepala Seksi Dashboard Info.
        /// </summary>
        /// <remarks>
        /// *Role: Kasi*
        /// </remarks>
        /// <returns>Kepala Seksi Dashboard Info.</returns>
        /// <response code="200">Kepala Seksi Dashboard Info.</response>
        [MultiRoleAuthorize(ApiRole.Supervisor)]
        [HttpGet]
        [ODataRoute(nameof(DashboardKepalaSeksi))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(DashboardInfo), Status200OK)]
        public async Task<ActionResult> DashboardKepalaSeksi()
        {
            return Ok(new DashboardInfo
            {
                TotalPemohon = await TotalPemohon(),
                TotalPermohonanPending = await _helper.Kasi().LongCountAsync(),
                TotalPermohonan = await TotalPermohonan(),
                TotalPermohonanDalamProses = await TotalPermohonanDalamProses(),
                TotalPermohonanDitolak = await TotalPermohonanDitolak(),
                TotalPerizinan = await TotalPerizinan(),
                Aktifitas = await Aktifitas()
            });
        }

        /// <summary>
        /// Retrieves Kepala Sub Direktorat Dashboard Info.
        /// </summary>
        /// <remarks>
        /// *Role: Kasubdit*
        /// </remarks>
        /// <returns>Kepala Sub Direktorat Dashboard Info.</returns>
        /// <response code="200">Kepala Sub Direktorat Dashboard Info.</response>
        [MultiRoleAuthorize(ApiRole.Timja)]
        [HttpGet]
        [ODataRoute(nameof(DashboardKepalaSubDirektorat))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(DashboardInfo), Status200OK)]
        public async Task<ActionResult> DashboardKepalaSubDirektorat()
        {
            return Ok(new DashboardInfo
            {
                TotalPemohon = await TotalPemohon(),
                TotalPermohonanPending = await _helper.Kasubdit().LongCountAsync(),
                TotalPermohonan = await TotalPermohonan(),
                TotalPermohonanDalamProses = await TotalPermohonanDalamProses(),
                TotalPermohonanDitolak = await TotalPermohonanDitolak(),
                TotalPerizinan = await TotalPerizinan(),
                Aktifitas = await Aktifitas()
            });
        }

        /// <summary>
        /// Retrieves Direktur Pelayanan Farmasi Dashboard Info.
        /// </summary>
        /// <remarks>
        /// *Role: Diryanfar*
        /// </remarks>
        /// <returns>Direktur Pelayanan Farmasi Dashboard Info.</returns>
        /// <response code="200">Direktur Pelayanan Farmasi Dashboard Info.</response>
        [MultiRoleAuthorize(ApiRole.Dirpenyanfar)]
        [HttpGet]
        [ODataRoute(nameof(DashboardDirekturPelayananFarmasi))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(DashboardInfo), Status200OK)]
        public async Task<ActionResult> DashboardDirekturPelayananFarmasi()
        {
            return Ok(new DashboardInfo
            {
                TotalPemohon = await TotalPemohon(),
                TotalPermohonanPending = await _helper.Diryanfar().LongCountAsync(),
                TotalPermohonan = await TotalPermohonan(),
                TotalPermohonanDalamProses = await TotalPermohonanDalamProses(),
                TotalPermohonanDitolak = await TotalPermohonanDitolak(),
                TotalPerizinan = await TotalPerizinan(),
                Aktifitas = await Aktifitas()
            });
        }

        /// <summary>
        /// Retrieves Direktur Jenderal Dashboard Info.
        /// </summary>
        /// <remarks>
        /// *Role: Dirjen*
        /// </remarks>
        /// <returns>Direktur Jenderal Dashboard Info.</returns>
        /// <response code="200">Direktur Jenderal Dashboard Info.</response>
        [MultiRoleAuthorize(ApiRole.Dirjen)]
        [HttpGet]
        [ODataRoute(nameof(DashboardDirekturJenderal))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(DashboardInfo), Status200OK)]
        public async Task<ActionResult> DashboardDirekturJenderal()
        {
            return Ok(new DashboardInfo
            {
                TotalPemohon = await TotalPemohon(),
                TotalPermohonanPending = await _helper.Dirjen().LongCountAsync(),
                TotalPermohonan = await TotalPermohonan(),
                TotalPermohonanDalamProses = await TotalPermohonanDalamProses(),
                TotalPermohonanDitolak = await TotalPermohonanDitolak(),
                TotalPerizinan = await TotalPerizinan(),
                Aktifitas = await Aktifitas()
            });
        }

        /// <summary>
        /// Retrieves Validator Sertifikat Dashboard Info.
        /// </summary>
        /// <remarks>
        /// *Role: Validator*
        /// </remarks>
        /// <returns>Validator Sertifikat Dashboard Info.</returns>
        /// <response code="200">Validator Sertifikat Dashboard Info.</response>
        [MultiRoleAuthorize(ApiRole.Validator)]
        [HttpGet]
        [ODataRoute(nameof(DashboardValidatorSertifikat))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(DashboardInfo), Status200OK)]
        public async Task<ActionResult> DashboardValidatorSertifikat()
        {
            return Ok(new DashboardInfo
            {
                TotalPemohon = await TotalPemohon(),
                TotalPermohonanPending = await _helper.Validator().LongCountAsync(),
                TotalPermohonan = await TotalPermohonan(),
                TotalPermohonanDalamProses = await TotalPermohonanDalamProses(),
                TotalPermohonanDitolak = await TotalPermohonanDitolak(),
                TotalPerizinan = await TotalPerizinan(),
                Aktifitas = await Aktifitas()
            });
        }

        private async Task<long> TotalPemohon()
        {
            return await _context.Pemohon.LongCountAsync();
        }
        private async Task<long> TotalPermohonan()
        {
            //return await _context.Permohonan.LongCountAsync();
            return await _helper.NonRumusan().LongCountAsync();
        }
        private async Task<long> TotalPermohonanDalamProses()
        {
            return await _helper.DalamProses().LongCountAsync();
        }
        private async Task<long> TotalPermohonanDitolak()
        {
            return await _helper.Ditolak().LongCountAsync();
        }
        private async Task<long> TotalPermohonanPemohon()
        {
            return await _context.Permohonan
                .Where(c => c.Pemohon.UserId == ApiHelper.GetUserId(HttpContext.User))
                .LongCountAsync();
        }
        private async Task<long> TotalPermohonanPemohonPending()
        {
            return await _context.Permohonan
                .Where(c =>
                    c.Pemohon.UserId == ApiHelper.GetUserId(HttpContext.User) &&
                    (c.StatusId == PermohonanStatus.Dibuat.Id ||
                    c.StatusId == PermohonanStatus.DikembalikanVerifikator.Id))
                .LongCountAsync();
        }
        private async Task<long> TotalPerizinan()
        {
            return await _context.Perizinan.LongCountAsync();
        }
        private async Task<long> TotalPerizinanPemohon()
        {
            return await _context.Perizinan
                .Where(c => c.Permohonan.Pemohon.UserId == ApiHelper.GetUserId(HttpContext.User))
                .LongCountAsync();
        }
        private async Task<List<Aktifitas>> Aktifitas()
        {
            List<HistoryPermohonan> historyList = await _context.HistoryPermohonan
                .Include(c => c.Permohonan)
                .Where(c => c.UpdatedBy == ApiHelper.GetUserName(HttpContext.User))
                .OrderByDescending(c => c.UpdatedAt)
                .Take(_aktifitasCount)
                .ToListAsync();
            List<Aktifitas> result = new List<Aktifitas>();

            foreach (HistoryPermohonan history in historyList)
            {
                result.Add(new Aktifitas
                {
                    UserName = history.UpdatedBy,
                    Date = history.UpdatedAt,
                    Action = history.StatusName,
                    Item = history.Permohonan?.Domain,
                    ItemId = history.PermohonanId
                });
            }

            return result;
        }

        private const int _aktifitasCount = 20;
        private readonly PsefMySqlContext _context;
        private readonly PermohonanHelper _helper;
        private static readonly HttpClient client = new HttpClient();
    }
}