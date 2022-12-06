using System;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsefApiOData.Models;
using PsefApiOData.Models.ViewModels;
using Syncfusion.Pdf.Parsing;

namespace PsefApiOData.Misc
{
    internal class PerubahanIzinHelper
    {
        public PerubahanIzinHelper(PsefMySqlContext context)
        {
            _context = context;
        }

        public IQueryable<PerubahanIzin> Verifikator()
        {
            return _context.PerubahanIzin
                .Where(c =>
                    c.StatusId == PermohonanStatus.Diajukan.Id ||
                    c.StatusId == PermohonanStatus.DikembalikanKepalaSeksi.Id);
        }

        public IQueryable<PerubahanIzin> Kasi()
        {
            return _context.PerubahanIzin
                .Where(c =>
                    c.StatusId == PermohonanStatus.DisetujuiVerifikator.Id ||
                    c.StatusId == PermohonanStatus.DikembalikanKepalaSubDirektorat.Id);
        }

        public IQueryable<PerubahanIzin> Kasubdit()
        {
            return _context.PerubahanIzin
                .Where(c =>
                    c.StatusId == PermohonanStatus.DisetujuiKepalaSeksi.Id ||
                    c.StatusId == PermohonanStatus.DikembalikanDirekturPelayananFarmasi.Id);
        }

        public IQueryable<PerubahanIzin> Diryanfar()
        {
            return _context.PerubahanIzin
                .Where(c =>
                    c.StatusId == PermohonanStatus.DisetujuiKepalaSubDirektorat.Id ||
                    c.StatusId == PermohonanStatus.DikembalikanDirekturJenderal.Id);
        }

        public IQueryable<PerubahanIzin> Dirjen()
        {
            return _context.PerubahanIzin
                .Where(c =>
                    c.StatusId == PermohonanStatus.DisetujuiDirekturPelayananFarmasi.Id);
        }

        public IQueryable<PerubahanIzin> DirjenSetujui()
        {
            return _context.PerubahanIzin
                .Where(c =>
                    c.StatusId == PermohonanStatus.DisetujuiDirekturJenderal.Id);
        }

        public IQueryable<PerubahanIzin> Validator()
        {
            return _context.PerubahanIzin
                .Where(c =>
                    c.StatusId == PermohonanStatus.DisetujuiDirekturJenderal.Id);
        }

        public IQueryable<PerubahanIzin> NonRumusan()
        {
            return _context.PerubahanIzin
                .Where(c =>
                    c.StatusId != PermohonanStatus.Dibuat.Id &&
                    c.StatusId != PermohonanStatus.DikembalikanVerifikator.Id);
        }

        public IQueryable<PerubahanIzin> DalamProses()
        {
            return _context.PerubahanIzin
                .Where(c =>
                    c.StatusId != PermohonanStatus.Dibuat.Id &&
                    c.StatusId != PermohonanStatus.DikembalikanVerifikator.Id &&
                    c.StatusId != PermohonanStatus.Selesai.Id &&
                    c.StatusId != PermohonanStatus.Ditolak.Id);
        }

        public IQueryable<PerubahanIzin> Ditolak()
        {
            return _context.PerubahanIzin
                .Where(c =>
                    c.StatusId == PermohonanStatus.Ditolak.Id);
        }

        public HistoryPerubahanIzin CreateHistory(
            PerubahanIzin perubahanIzin,
            PermohonanSystemUpdate update,
            HttpContext httpContext)
        {
            return new HistoryPerubahanIzin
            {
                PerubahanIzinId = perubahanIzin.Id,
                PermohonanId = perubahanIzin.PermohonanId,
                StatusId = perubahanIzin.StatusId,
                Reason = update.Reason ?? string.Empty,
                SystemName = perubahanIzin.SystemName,
                UpdatedAt = DateTime.Now,
                UpdatedBy = ApiHelper.GetUserName(httpContext.User)
            };
        }

        public GeneratePdfResult GenerateAndSignPdf(
            TandaDaftarHelper helper,
            OssFullInfo ossFullInfo,
            Pemohon pemohon,
            Permohonan permohonan,
            Perizinan perizinan)
        {
            GeneratePdfResult result = helper.GeneratePdf(ossFullInfo, pemohon, permohonan, perizinan);
            result.SignResult = new ElectronicSignatureResult
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                FailureContent = string.Empty
            };

            return result;
        }


        public GeneratePdfResult ReGenerateAndSignPdf(
            TandaDaftarHelper helper,
            Pemohon pemohon,
            PerubahanIzin perubahanIzin,
            Perizinan perizinan)
        {
            GeneratePdfResult result = helper.ReGeneratePdf(pemohon, perubahanIzin, perizinan);
            result.SignResult = new ElectronicSignatureResult
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                FailureContent = string.Empty
            };

            return result;
        }

        public GeneratePdfResult MergePerubahanIzinSertifikat(
            TandaDaftarHelper helper,
            GeneratePdfResult fileTandaDaftar,
            Pemohon pemohon,
            PerubahanIzin perubahanIzin,
            Perizinan perizinan)
        {

            GeneratePdfResult result = helper.MergeSertifikatPdf(fileTandaDaftar, pemohon, perubahanIzin, perizinan);

            result.SignResult = new ElectronicSignatureResult
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                FailureContent = string.Empty
            };

            return result;
        }

        private readonly PsefMySqlContext _context;
    }
}