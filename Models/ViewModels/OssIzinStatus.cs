namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a OSS Izin Status Information.
    /// </summary>
    public class OssIzinStatus
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
        /// Gets or sets the kode instansi.
        /// </summary>
        /// <value>The kode instansi.</value>
        public string KdInstansi { get; set; }

        /// <summary>
        /// Gets or sets the kode status.
        /// </summary>
        /// <value>The kode status.</value>
        public string KdStatus { get; set; }

        /// <summary>
        /// Gets or sets the tanggal status.
        /// </summary>
        /// <value>The tanggal status.</value>
        public string TglStatus { get; set; }

        /// <summary>
        /// Gets or sets the nip status.
        /// </summary>
        /// <value>The nip status.</value>
        public string NipStatus { get; set; }

        /// <summary>
        /// Gets or sets the nama status.
        /// </summary>
        /// <value>The nama status.</value>
        public string NamaStatus { get; set; }

        /// <summary>
        /// Gets or sets the tanggal berlaku izin.
        /// </summary>
        /// <value>The tanggal berlaku izin.</value>
        public string TglBerlakuIzin { get; set; }

        /// <summary>
        /// Gets or sets the data pnbp.
        /// </summary>
        /// <value>The data pnbp.</value>
        public OssDataPnbpIzinStatus DataPnbp { get; set; }
    }
}
