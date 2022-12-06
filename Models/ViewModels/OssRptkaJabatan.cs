using System;
using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a OSS Rptka Jabatan Information.
    /// </summary>
    public class OssRptkaJabatan
    {
        /// <summary>
        /// Gets or sets the IdJabatan.
        /// </summary>
        /// <value>The IdJabatan.</value>
        public int IdJabatan { get; set; }

        /// <summary>
        /// Gets or sets the Jabatan.
        /// </summary>
        /// <value>The Jabatan.</value>
        public string Jabatan { get; set; }

        /// <summary>
        /// Gets or sets the Jumlah.
        /// </summary>
        /// <value>The Jumlah.</value>
        public int Jumlah { get; set; }

        /// <summary>
        /// Gets or sets the TglMulai.
        /// </summary>
        /// <value>The TglMulai.</value>
        public DateTime? TglMulai { get; set; }

        /// <summary>
        /// Gets or sets the TglSelesai.
        /// </summary>
        /// <value>The TglSelesai.</value>
        public DateTime? TglSelesai { get; set; }

        /// <summary>
        /// Gets or sets the Keterangan.
        /// </summary>
        /// <value>The Keterangan.</value>
        public string Keterangan { get; set; }

        /// <summary>
        /// Gets or sets the list of RptkaTkiPendamping.
        /// </summary>
        /// <value>The list of RptkaTkiPendamping.</value>
        public List<OssRptkaTkiPendamping> RptkaTkiPendamping { get; set; }
    }
}