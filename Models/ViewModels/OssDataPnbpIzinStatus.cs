namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a OSS Data PNBP Information.
    /// </summary>
    public class OssDataPnbpIzinStatus
    {
        /// <summary>
        /// Gets or sets the kode akun.
        /// </summary>
        /// <value>The kode akun.</value>
        public string KdAkun { get; set; }

        /// <summary>
        /// Gets or sets the kode penerimaan.
        /// </summary>
        /// <value>The kode penerimaan.</value>
        public string KdPenerimaan { get; set; }

        /// <summary>
        /// Gets or sets the kode billing.
        /// </summary>
        /// <value>The kode billing.</value>
        public string KdBilling { get; set; }

        /// <summary>
        /// Gets or sets the tanggal billing.
        /// </summary>
        /// <value>The tanggal billing.</value>
        public string TglBilling { get; set; }

        /// <summary>
        /// Gets or sets the tanggal expire.
        /// </summary>
        /// <value>The tanggal expire.</value>
        public string TglExpire { get; set; }

        /// <summary>
        /// Gets or sets the nominal.
        /// </summary>
        /// <value>The nominal.</value>
        public string Nominal { get; set; }

        /// <summary>
        /// Gets or sets the url dokumen.
        /// </summary>
        /// <value>The url dokumen.</value>
        public string UrlDokumen { get; set; }
    }
}