using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a OSS Izin Final Information.
    /// </summary>
    public class OssIzinFinal
    {
        /// <summary>
        /// Gets or sets the Nib.
        /// </summary>
        /// <value>The Nib.</value>
        public string Nib { get; set; }

        /// <summary>
        /// Gets or sets the id produk.
        /// </summary>
        /// <value>The id produk.</value>
        public string IdProduk { get; set; }

        /// <summary>
        /// Gets or sets the id proyek.
        /// </summary>
        /// <value>The id proyek.</value>
        public string IdProyek { get; set; }

        /// <summary>
        /// Gets or sets the OSS id.
        /// </summary>
        /// <value>The OSS id.</value>
        public string OssId { get; set; }

        /// <summary>
        /// Gets or sets the id izin.
        /// </summary>
        /// <value>The id izin.</value>
        public string IdIzin { get; set; }

        /// <summary>
        /// Gets or sets the kode izin.
        /// </summary>
        /// <value>The kode izin.</value>
        public string KdIzin { get; set; }

        /// <summary>
        /// Gets or sets the kode daerah.
        /// </summary>
        /// <value>The kode daerah.</value>
        public string KdDaerah { get; set; }

        /// <summary>
        /// Gets or sets the kewenangan.
        /// </summary>
        /// <value>The kewenangan.</value>
        public string Kewenangan { get; set; }

        /// <summary>
        /// Gets or sets the nomor izin.
        /// </summary>
        /// <value>The nomor izin.</value>
        public string NomorIzin { get; set; }

        /// <summary>
        /// Gets or sets the tanggal terbit izin.
        /// </summary>
        /// <value>The tanggal terbit izin.</value>
        public string TglTerbitIzin { get; set; }

        /// <summary>
        /// Gets or sets the tanggal berlaku izin.
        /// </summary>
        /// <value>The tanggal berlaku izin.</value>
        public string TglBerlakuIzin { get; set; }

        /// <summary>
        /// Gets or sets the nama ttd.
        /// </summary>
        /// <value>The nama ttd.</value>
        public string NamaTtd { get; set; }

        /// <summary>
        /// Gets or sets the nip ttd.
        /// </summary>
        /// <value>The nip ttd.</value>
        public string NipTtd { get; set; }

        /// <summary>
        /// Gets or sets the jabatan ttd.
        /// </summary>
        /// <value>The jabatan ttd.</value>
        public string JabatanTtd { get; set; }

        /// <summary>
        /// Gets or sets the status izin.
        /// </summary>
        /// <value>The status izin.</value>
        public string StatusIzin { get; set; }

        /// <summary>
        /// Gets or sets the keterangan.
        /// </summary>
        /// <value>The keterangan.</value>
        public string Keterangan { get; set; }

        /// <summary>
        /// Gets or sets the nomenklatur nomor izin.
        /// </summary>
        /// <value>The nomenklatur nomor izin.</value>
        public string NomenklaturNomorIzin { get; set; }

        /// <summary>
        /// Gets or sets the file izin url.
        /// </summary>
        /// <value>The file izin url.</value>
        public string FileIzin { get; set; }

        /// <summary>
        /// Gets or sets the file lampiran url.
        /// </summary>
        /// <value>The file lampiran url.</value>
        public string FileLampiran { get; set; }

        /// <summary>
        /// Gets or sets the list of data pnbp.
        /// </summary>
        /// <value>The list of data pnbp.</value>
        public List<OssDataPnbp> DataPnbp { get; set; }
    }
}