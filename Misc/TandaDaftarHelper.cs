using System;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Security.Policy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.OData.Edm;
using PsefApiOData.Models;
using PsefApiOData.Models.ViewModels;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

namespace PsefApiOData.Misc
{
    /// <summary>
    /// Tanda Daftar helpers.
    /// </summary>
    public class TandaDaftarHelper
    {
        /// <summary>
        /// Tanda Daftar helpers.
        /// </summary>
        /// <param name="environment">Web Host environment.</param>
        /// <param name="httpContext">Http context.</param>
        /// <param name="urlHelper">Url helper.</param>
        /// <param name="options">Electronic signature options.</param>
        public TandaDaftarHelper(
            IWebHostEnvironment environment,
            HttpContext httpContext,
            IUrlHelper urlHelper,
            IOptions<ElectronicSignatureOptions> options)
        {
            _environment = environment;
            _httpContext = httpContext;
            _urlHelper = urlHelper;
            _options = options;
        }

        /// <summary>
        /// Generate Tanda Daftar Pdf.
        /// </summary>
        /// <param name="ossInfo">Oss info.</param>
        /// <param name="pemohon">Pemohon.</param>
        /// <param name="permohonan">Permohonan.</param>
        /// <param name="perizinan">Perizinan.</param>
        /// <returns>A GeneratePdfResult that contains information about generated pdf.</returns>
        public GeneratePdfResult GeneratePdf(
            OssFullInfo ossInfo,
            Pemohon pemohon,
            Permohonan permohonan,
            Perizinan perizinan)
        {
            Guid randomizer = Guid.NewGuid();

            GeneratePdfResult result = new GeneratePdfResult
            {
                FileName = $"{pemohon.UserId}-{randomizer.ToString()[..13]}.pdf",
                DatePath = perizinan.IssuedAt.ToString(
                    "yyyy-MM-dd",
                    DateTimeFormatInfo.InvariantInfo)
            };

            result.FullPath = _urlHelper.Content($"~/{result.DatePath}/{result.FileName}");
            FileAndPathHelper helper = new FileAndPathHelper();
            string filePath = helper.PrepareFileAndFolder(_environment, result.DatePath, result.FileName);
            PdfDocument document = new PdfDocument();
            document.FileStructure.Version = PdfVersion.Version1_3;
            float top = 0;

            SetupPage(document);
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;

            top = DrawLogo(graphics, top);
            top = DrawHeader(perizinan, graphics, top);
            DrawContent(permohonan, perizinan, ossInfo, graphics, top);

            FileStream fileStream = new FileStream(
                filePath,
                FileMode.CreateNew,
                FileAccess.ReadWrite);

            document.Save(fileStream);
            fileStream.Close();
            document.Close(true);

            return result;
        }

        /// <summary>
        /// Generate Tanda Daftar Pdf.
        /// </summary>
        /// <param name="pemohon">Pemohon.</param>
        /// <param name="perubahanIzin">PerubahanIzin.</param>
        /// <param name="perizinan">Perizinan.</param>
        /// <returns>A GeneratePdfResult that contains information about generated pdf.</returns>
        public GeneratePdfResult ReGeneratePdf(
            Pemohon pemohon,
            PerubahanIzin perubahanIzin,
            Perizinan perizinan)
        {
            Guid randomizer = Guid.NewGuid();

            GeneratePdfResult result = new GeneratePdfResult
            {
                FileName = $"{pemohon.UserId}-{randomizer.ToString()[..13]}.pdf",
                DatePath = perizinan.IssuedAt.ToString(
                    "yyyy-MM-dd",
                    DateTimeFormatInfo.InvariantInfo)
            };

            result.FullPath = _urlHelper.Content($"~/{result.DatePath}/{result.FileName}");
            FileAndPathHelper helper = new FileAndPathHelper();
            string filePath = helper.PrepareFileAndFolder(_environment, result.DatePath, result.FileName);
            PdfDocument document = new PdfDocument();
            document.FileStructure.Version = PdfVersion.Version1_3;
            float top = 0;

            SetupPage(document);
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;

            top = DrawLogo(graphics, top);
            top = DrawHeader(perizinan, graphics, top);
            DrawContentPerubahan(perubahanIzin, perizinan, graphics, top);

            FileStream fileStream = new FileStream(
                filePath,
                FileMode.CreateNew,
                FileAccess.ReadWrite);

            document.Save(fileStream);
            fileStream.Close();
            document.Close(true);

            return result;
        }


        /// <summary>
        /// Generate Tanda Daftar Pdf.
        /// </summary>
        /// <param name="TandaDaftarResult">fileTandaDaftar.</param>
        /// <param name="pemohon">Pemohon.</param>
        /// <param name="perubahanIzin">PerubahanIzin.</param>
        /// <param name="perizinan">Perizinan.</param>
        /// <returns>A GeneratePdfResult that contains information about generated pdf.</returns>
        public GeneratePdfResult MergeSertifikatPdf(
            GeneratePdfResult TandaDaftarResult,
            Pemohon pemohon,
            PerubahanIzin perubahanIzin,
            Perizinan perizinan)
        {
            GeneratePdfResult result = new GeneratePdfResult
            {
                FileName = $"{Guid.NewGuid():N}.pdf",
                DatePath = perizinan.IssuedAt.ToString(
                    "yyyy-MM-dd",
                    DateTimeFormatInfo.InvariantInfo)
            };

            string[] temp = perizinan.OssIzinUrl.Split("/");

            result.FullPath = _urlHelper.Content($"~/{result.DatePath}/{result.FileName}");
            FileAndPathHelper helper = new FileAndPathHelper();
            string filePath = helper.PrepareFileAndFolder(_environment, result.DatePath, result.FileName);
            string filePathTandaDaftar = helper.CombineFileAndFolder(_environment, TandaDaftarResult.DatePath, TandaDaftarResult.FileName);
            string filePathSertifikat = helper.CombineFileAndFolder(_environment, temp[temp.Length -2], temp[temp.Length - 1]);

            Stream oldFile = new FileStream(
                filePathSertifikat,
                FileMode.Open, FileAccess.ReadWrite);

            FileStream fileStream = new FileStream(
                filePath,
                FileMode.CreateNew,
                FileAccess.ReadWrite);

            //Create an instance of PdfDocument
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(oldFile, true);

            //Remove the first page in the PDF document

            loadedDocument.Pages.RemoveAt(1);

            //Save and close the document
            loadedDocument.Save(fileStream);

            Stream stream1 = File.OpenRead(filePath);

            Stream stream2 = File.OpenRead(filePathTandaDaftar);

            Stream[] source = { stream1, stream2 };

            PdfDocument finalDoc = new PdfDocument();
            PdfDocumentBase.Merge(finalDoc, source);
            //Saves the document

            finalDoc.Save(fileStream);

            oldFile.Close();
            fileStream.Close();
            loadedDocument.Close(true);
            finalDoc.Close(true);

            return result;
        }


        private void SetupPage(PdfDocument document)
        {
            PdfUnitConverter converter = new PdfUnitConverter();

            document.PageSettings.Size = new SizeF(
                converter.ConvertUnits(210, PdfGraphicsUnit.Millimeter, PdfGraphicsUnit.Point),
                converter.ConvertUnits(297, PdfGraphicsUnit.Millimeter, PdfGraphicsUnit.Point));

            document.PageSettings.SetMargins(
                converter.ConvertUnits(15, PdfGraphicsUnit.Millimeter, PdfGraphicsUnit.Point),
                converter.ConvertUnits(25, PdfGraphicsUnit.Millimeter, PdfGraphicsUnit.Point));
        }

        private float DrawLogo(PdfGraphics graphics, float top)
        {
            PdfBitmap logo = new PdfBitmap(new FileStream(
                "logo-garuda.jpg",
                FileMode.Open,
                FileAccess.Read));
            PdfUnitConverter converter = new PdfUnitConverter();

            float drawWidth = converter.ConvertUnits(26, PdfGraphicsUnit.Millimeter, PdfGraphicsUnit.Point);
            float drawHeight = drawWidth;

            graphics.DrawImage(
                logo,
                (graphics.ClientSize.Width - drawWidth) / 2,
                top,
                drawWidth,
                drawHeight);

            return top + drawHeight;
        }

        private float DrawHeader(Perizinan perizinan, PdfGraphics graphics, float top)
        {
            PdfStandardFont headerFont = new PdfStandardFont(PdfFontFamily.Helvetica, 13, PdfFontStyle.Bold);
            PdfStringFormat centered = new PdfStringFormat
            {
                Alignment = PdfTextAlignment.Center
            };
            PdfUnitConverter converter = new PdfUnitConverter();

            top += converter.ConvertUnits(12, PdfGraphicsUnit.Millimeter, PdfGraphicsUnit.Point);
            top = DrawString(
                "PEMERINTAH REPUBLIK INDONESIA ",
                graphics,
                headerFont,
                centered,
                new RectangleF(0, top, graphics.ClientSize.Width, 0));
            top += converter.ConvertUnits(12, PdfGraphicsUnit.Millimeter, PdfGraphicsUnit.Point);
            top = DrawString(
                "PERIZINAN BERUSAHA UNTUK MENUNJANG KEGIATAN USAHA\nPENYELENGGARA SISTEM ELEKTRONIK FARMASI (PSEF)\nLAMPIRAN",
                graphics,
                headerFont,
                centered,
                new RectangleF(0, top, graphics.ClientSize.Width, 0));
            top += converter.ConvertUnits(4, PdfGraphicsUnit.Millimeter, PdfGraphicsUnit.Point);
            top = DrawString(
                $"PB-UMKU: {perizinan.PerizinanNumber}",
                graphics,
                headerFont,
                centered,
                new RectangleF(0, top, graphics.ClientSize.Width, 0));

            return top;
        }

        private float DrawContent(
            Permohonan permohonan,
            Perizinan perizinan,
            OssFullInfo ossInfo,
            PdfGraphics graphics,
            float top)
        {
            PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.Helvetica, 11);
            PdfStringFormat leftAlign = new PdfStringFormat
            {
                Alignment = PdfTextAlignment.Left
            };
            PdfUnitConverter converter = new PdfUnitConverter();
            float leftCol = 0f;

            top += converter.ConvertUnits(8, PdfGraphicsUnit.Millimeter, PdfGraphicsUnit.Point);
            top = DrawString(
                "Lampiran berikut memuat data teknis Penyelenggara Sistem Elektronik Farmasi (PSEF) sebagai berikut:",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(leftCol, top, graphics.ClientSize.Width, 0));
            top += converter.ConvertUnits(5, PdfGraphicsUnit.Millimeter, PdfGraphicsUnit.Point);

            float leftWidth = converter.ConvertUnits(62, PdfGraphicsUnit.Millimeter, PdfGraphicsUnit.Point);
            float rightWidth = graphics.ClientSize.Width - leftWidth;
            float rightCol = leftWidth;

            DrawString(
                "Bidang",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(leftCol, top, leftWidth, 0));
            top = DrawString(
                ": Pelayanan",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(rightCol, top, rightWidth, 0));

            top += 8;
            DrawString(
                "Masa Berlaku",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(leftCol, top, leftWidth, 0));
            top = DrawString(
                $": Berlaku 5 (lima) tahun sampai dengan {perizinan.ExpiredAt.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id"))}",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(rightCol, top, rightWidth, 0));

            top += 8;
            DrawString(
                "Nama Sistem Elektronik",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(leftCol, top, leftWidth, 0));
            top = DrawString(
                $": {permohonan.SystemName}",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(rightCol, top, rightWidth, 0));

            top += 8;
            DrawString(
                "Alamat Domain Sistem Elektronik",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(leftCol, top, leftWidth, 0));
            top = DrawString(
                $": {permohonan.Domain}",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(rightCol, top, rightWidth, 0));

            top += 8;
            DrawString(
                "Apoteker Penanggung Jawab",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(leftCol, top, leftWidth, 0));
            top = DrawString(
                $": {permohonan.ApotekerName}",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(rightCol, top, rightWidth, 0));

            top += 8;
            DrawString(
                "Nomor STRA",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(leftCol, top, leftWidth, 0));
            top = DrawString(
                $": {permohonan.StraNumber}",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(rightCol, top, rightWidth, 0));

            return top;
        }

        private float DrawContentPerubahan(
            PerubahanIzin permohonan,
            Perizinan perizinan,
            PdfGraphics graphics,
            float top)
        {
            PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.Helvetica, 11);
            PdfStringFormat leftAlign = new PdfStringFormat
            {
                Alignment = PdfTextAlignment.Left
            };
            PdfUnitConverter converter = new PdfUnitConverter();
            float leftCol = 0f;

            top += converter.ConvertUnits(8, PdfGraphicsUnit.Millimeter, PdfGraphicsUnit.Point);
            top = DrawString(
                "Lampiran berikut memuat data teknis Penyelenggara Sistem Elektronik Farmasi (PSEF) sebagai berikut:",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(leftCol, top, graphics.ClientSize.Width, 0));
            top += converter.ConvertUnits(5, PdfGraphicsUnit.Millimeter, PdfGraphicsUnit.Point);

            float leftWidth = converter.ConvertUnits(62, PdfGraphicsUnit.Millimeter, PdfGraphicsUnit.Point);
            float rightWidth = graphics.ClientSize.Width - leftWidth;
            float rightCol = leftWidth;

            DrawString(
                "Bidang",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(leftCol, top, leftWidth, 0));
            top = DrawString(
                ": Pelayanan",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(rightCol, top, rightWidth, 0));

            top += 8;
            DrawString(
                "Masa Berlaku",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(leftCol, top, leftWidth, 0));
            top = DrawString(
                $": Berlaku 5 (lima) tahun sampai dengan {perizinan.ExpiredAt.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id"))}",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(rightCol, top, rightWidth, 0));

            top += 8;
            DrawString(
                "Nama Sistem Elektronik",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(leftCol, top, leftWidth, 0));
            top = DrawString(
                $": {permohonan.SystemName}",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(rightCol, top, rightWidth, 0));

            top += 8;
            DrawString(
                "Alamat Domain Sistem Elektronik",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(leftCol, top, leftWidth, 0));
            top = DrawString(
                $": {permohonan.Domain}",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(rightCol, top, rightWidth, 0));

            top += 8;
            DrawString(
                "Apoteker Penanggung Jawab",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(leftCol, top, leftWidth, 0));
            top = DrawString(
                $": {permohonan.ApotekerName}",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(rightCol, top, rightWidth, 0));

            top += 8;
            DrawString(
                "Nomor STRA",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(leftCol, top, leftWidth, 0));
            top = DrawString(
                $": {permohonan.StraNumber}",
                graphics,
                contentFont,
                leftAlign,
                new RectangleF(rightCol, top, rightWidth, 0));

            return top;
        }

        private float DrawSignature(
            PdfGraphics graphics,
            float top)
        {
            float rightCol = (graphics.ClientSize.Width / 2) - 30;
            float width = (graphics.ClientSize.Width / 2) + 20;
            PdfStringFormat leftAlign = new PdfStringFormat
            {
                Alignment = PdfTextAlignment.Left
            };

            top = DrawString(
                $"A.N. MENTERI KESEHATAN\n{_options.Value.Position}\n\n\nTTD\n\n\n{_options.Value.Name}",
                graphics,
                new PdfStandardFont(PdfFontFamily.Helvetica, 11),
                leftAlign,
                new RectangleF(rightCol, top, width, 0));

            return top;
        }

        private float DrawFooter(Perizinan perizinan, PdfGraphics graphics, float top)
        {
            float leftCol = 5;
            float width = graphics.ClientSize.Width - 10;
            PdfStandardFont italicFont = new PdfStandardFont(PdfFontFamily.Helvetica, 11, PdfFontStyle.Italic);
            PdfStandardFont labelFont = new PdfStandardFont(PdfFontFamily.Helvetica, 11);
            PdfStringFormat leftAlign = new PdfStringFormat
            {
                Alignment = PdfTextAlignment.Left
            };
            PdfStringFormat justified = new PdfStringFormat
            {
                Alignment = PdfTextAlignment.Justify
            };

            SizeF indentSize = labelFont.MeasureString("-");
            float indentCol = leftCol + indentSize.Width + 2;
            float indentWidth = graphics.ClientSize.Width - indentCol;

            top += 16;
            top = DrawString(
                "Keterangan:",
                graphics,
                italicFont,
                leftAlign,
                new RectangleF(leftCol, top, width, 0));
            top += 4;
            DrawString(
                "-",
                graphics,
                labelFont,
                leftAlign,
                new RectangleF(leftCol, top, indentSize.Width, 0));
            top = DrawString(
                "Tanda Daftar Penyelenggara Sistem Elektronik Farmasi (PSEF) Merupakan Dokumen Sertifikasi Usaha Penyelenggara Sistem Elektronik Farmasi (PSEF)",
                graphics,
                labelFont,
                justified,
                new RectangleF(indentCol, top, indentWidth, 0));

            string expired = perizinan.ExpiredAt.ToString(
                "dd MMMM yyyy",
                CultureInfo.CreateSpecificCulture("id"));

            DrawString(
                "-",
                graphics,
                labelFont,
                leftAlign,
                new RectangleF(leftCol, top, indentSize.Width, 0));
            top = DrawString(
                $"Tanda Daftar Penyelenggara Sistem Elektronik Farmasi (PSEF) Berlaku Sejak Tanggal Diterbitkan Sampai Dengan {expired}",
                graphics,
                labelFont,
                justified,
                new RectangleF(indentCol, top, indentWidth, 0));

            DrawString(
                "-",
                graphics,
                labelFont,
                leftAlign,
                new RectangleF(leftCol, top, indentSize.Width, 0));
            top = DrawString(
                "Jika Tidak Dilakukan Pembaruan, Akan Dihapus Dari Tanda Daftar PSEF Kementerian Kesehatan",
                graphics,
                labelFont,
                justified,
                new RectangleF(indentCol, top, indentWidth, 0));

            return top;
        }

        private float DrawBsreInfo(PdfGraphics graphics, float top)
        {
            top += 20;
            PdfPen pen = new PdfPen(Color.Black, 2);
            graphics.DrawLine(pen, 5, top, graphics.ClientSize.Width, top);

            top += 10;
            PdfBitmap logo = new PdfBitmap(new FileStream(
                "logo-bsre.png",
                FileMode.Open,
                FileAccess.Read));
            float drawWidth = logo.Width / 2.2f;
            float drawHeight = logo.Height / 2.2f;

            graphics.DrawImage(
                logo,
                graphics.ClientSize.Width - 20 - drawWidth,
                top,
                drawWidth,
                drawHeight);

            float leftCol = 5;
            float width = graphics.ClientSize.Width - 50 - drawWidth;
            PdfStandardFont labelFont = new PdfStandardFont(PdfFontFamily.Helvetica, 9);
            PdfStringFormat leftAlign = new PdfStringFormat
            {
                Alignment = PdfTextAlignment.Left
            };
            PdfStringFormat justified = new PdfStringFormat
            {
                Alignment = PdfTextAlignment.Justify
            };

            SizeF indentSize = labelFont.MeasureString("2.");
            float indentCol = leftCol + indentSize.Width + 2;
            float indentWidth = width - indentCol;

            DrawString(
                "1.",
                graphics,
                labelFont,
                leftAlign,
                new RectangleF(leftCol, top, indentSize.Width, 0));
            top = DrawString(
                "Undang-undang Nomor 11 Tahun 2008 Pasal 5 Ayat 1 \"Informasi elektronik dan/atau dokumen elektronik dan/atau hasil cetaknya merupakan alat bukti hukum yang sah\"",
                graphics,
                labelFont,
                justified,
                new RectangleF(indentCol, top, indentWidth, 0));

            top += 4;
            DrawString(
                "2.",
                graphics,
                labelFont,
                leftAlign,
                new RectangleF(leftCol, top, indentSize.Width, 0));
            top = DrawString(
                "Dokumen ini telah ditandatangani secara elektronik menggunakan sertifikat elektronik yang diterbitkan oleh Balai Sertifikasi Elektronik (BSrE)",
                graphics,
                labelFont,
                justified,
                new RectangleF(indentCol, top, indentWidth, 0));

            return top + drawHeight;
        }

        private float DrawString(
            string text,
            PdfGraphics graphics,
            PdfStandardFont font,
            PdfStringFormat format,
            RectangleF bounds)
        {
            SizeF size = font.MeasureString(text, bounds.Width, format);

            bounds.Size = new SizeF(bounds.Width, size.Height);
            graphics.DrawString(text, font, PdfBrushes.Black, bounds, format);
            return bounds.Bottom;
        }

        private readonly IWebHostEnvironment _environment;
        private readonly HttpContext _httpContext;
        private readonly IUrlHelper _urlHelper;
        private readonly IOptions<ElectronicSignatureOptions> _options;
    }
}