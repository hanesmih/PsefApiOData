using System;
using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a OSS Rptka Information.
    /// </summary>
    public class OssRptka
    {
        /// <summary>
        /// Gets or sets the JenisRptka.
        /// </summary>
        /// <value>The JenisRptka.</value>
        public string JenisRptka { get; set; }

        /// <summary>
        /// Gets or sets the NoRptka.
        /// </summary>
        /// <value>The NoRptka.</value>
        public string NoRptka { get; set; }

        /// <summary>
        /// Gets or sets the RptkaAwal.
        /// </summary>
        /// <value>The RptkaAwal.</value>
        public DateTime? RptkaAwal { get; set; }

        /// <summary>
        /// Gets or sets the RptkaAkhir.
        /// </summary>
        /// <value>The RptkaAkhir.</value>
        public DateTime? RptkaAkhir { get; set; }

        /// <summary>
        /// Gets or sets the RptkaGaji.
        /// </summary>
        /// <value>The RptkaGaji.</value>
        public decimal RptkaGaji { get; set; }

        /// <summary>
        /// Gets or sets the JumlahTkaRptka.
        /// </summary>
        /// <value>The JumlahTkaRptka.</value>
        public int JumlahTkaRptka { get; set; }

        /// <summary>
        /// Gets or sets the JangkaPenggunaanWaktu.
        /// </summary>
        /// <value>The JangkaPenggunaanWaktu.</value>
        public DateTime? JangkaPenggunaanWaktu { get; set; }

        /// <summary>
        /// Gets or sets the JangkaWaktuPermohonanRptka.
        /// </summary>
        /// <value>The JangkaWaktuPermohonanRptka.</value>
        public int JangkaWaktuPermohonanRptka { get; set; }

        /// <summary>
        /// Gets or sets the list of RptkaJabatan.
        /// </summary>
        /// <value>The list of RptkaJabatan.</value>
        public List<OssRptkaJabatan> RptkaJabatan { get; set; }

        /// <summary>
        /// Gets or sets the list of RptkaNegara.
        /// </summary>
        /// <value>The list of RptkaNegara.</value>
        public List<OssRptkaNegara> RptkaNegara { get; set; }

        /// <summary>
        /// Gets or sets the list of RptkaLokasi.
        /// </summary>
        /// <value>The list of RptkaLokasi.</value>
        public List<OssRptkaLokasi> RptkaLokasi { get; set; }
    }
}