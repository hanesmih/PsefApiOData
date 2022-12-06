using System;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a OSS Rptka Tki Pendamping Information.
    /// </summary>
    public class OssRptkaTkiPendamping
    {
        /// <summary>
        /// Gets or sets the IdJabatan.
        /// </summary>
        /// <value>The IdJabatan.</value>
        public int IdJabatan { get; set; }

        /// <summary>
        /// Gets or sets the IdPendamping.
        /// </summary>
        /// <value>The IdPendamping.</value>
        public int IdPendamping { get; set; }

        /// <summary>
        /// Gets or sets the Nama.
        /// </summary>
        /// <value>The Nama.</value>
        public string Nama { get; set; }

        /// <summary>
        /// Gets or sets the Nik.
        /// </summary>
        /// <value>The Nik.</value>
        public string Nik { get; set; }

        /// <summary>
        /// Gets or sets the Jabatan.
        /// </summary>
        /// <value>The Jabatan.</value>
        public string Jabatan { get; set; }

        /// <summary>
        /// Gets or sets the Hp.
        /// </summary>
        /// <value>The Hp.</value>
        public string Hp { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        /// <value>The Email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Foto.
        /// </summary>
        /// <value>The Foto.</value>
        public string Foto { get; set; }

        /// <summary>
        /// Gets or sets the PendidikanMin.
        /// </summary>
        /// <value>The PendidikanMin.</value>
        public string PendidikanMin { get; set; }

        /// <summary>
        /// Gets or sets the Sertifikat.
        /// </summary>
        /// <value>The Sertifikat.</value>
        public string Sertifikat { get; set; }

        /// <summary>
        /// Gets or sets the PengalamanKerja.
        /// </summary>
        /// <value>The PengalamanKerja.</value>
        public int PengalamanKerja { get; set; }

        /// <summary>
        /// Gets or sets the Keterangan.
        /// </summary>
        /// <value>The Keterangan.</value>
        public string Keterangan { get; set; }
    }
}