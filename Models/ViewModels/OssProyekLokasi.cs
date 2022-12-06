using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a OSS Proyek Lokasi Information.
    /// </summary>
    public class OssProyekLokasi
    {
        /// <summary>
        /// Gets or sets the IdProyekLokasi.
        /// </summary>
        /// <value>The IdProyekLokasi.</value>
        public string IdProyekLokasi { get; set; }

        /// <summary>
        /// Gets or sets the ProyekDaerahId.
        /// </summary>
        /// <value>The ProyekDaerahId.</value>
        public string ProyekDaerahId { get; set; }

        /// <summary>
        /// Gets or sets the KdKawasan.
        /// </summary>
        /// <value>The KdKawasan.</value>
        public string KdKawasan { get; set; }

        /// <summary>
        /// Gets or sets the AlamatUsaha.
        /// </summary>
        /// <value>The AlamatUsaha.</value>
        public string AlamatUsaha { get; set; }

        /// <summary>
        /// Gets or sets the IdKegiatan.
        /// </summary>
        /// <value>The IdKegiatan.</value>
        public string IdKegiatan { get; set; }

        /// <summary>
        /// Gets or sets the ResponseKegiatan.
        /// </summary>
        /// <value>The ResponseKegiatan.</value>
        public string ResponseKegiatan { get; set; }

        /// <summary>
        /// Gets or sets the JenisKawasan.
        /// </summary>
        /// <value>The JenisKawasan.</value>
        public string JenisKawasan { get; set; }

        /// <summary>
        /// Gets or sets the JenisLokasi.
        /// </summary>
        /// <value>The JenisLokasi.</value>
        public string JenisLokasi { get; set; }

        /// <summary>
        /// Gets or sets the StatusLokasi.
        /// </summary>
        /// <value>The StatusLokasi.</value>
        public string StatusLokasi { get; set; }

        /// <summary>
        /// Gets or sets the list of DataLokasiProyek.
        /// </summary>
        /// <value>The list of DataLokasiProyek.</value>
        public List<OssProyekLokasiLokasi> DataLokasiProyek { get; set; }

        /// <summary>
        /// Gets or sets the list of DataPosisiProyek.
        /// </summary>
        /// <value>The list of DataPosisiProyek.</value>
        public List<OssProyekPosisi> DataPosisiProyek { get; set; }
    }
}
