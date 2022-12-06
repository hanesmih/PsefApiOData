namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a OSS Checklist Persyaratan Information.
    /// </summary>
    public class OssChecklistPersyaratan
    {
        /// <summary>
        /// Gets or sets the IdSyarat.
        /// </summary>
        /// <value>The IdSyarat.</value>
        public string IdSyarat { get; set; }

        /// <summary>
        /// Gets or sets the NoDokumen.
        /// </summary>
        /// <value>The NoDokumen.</value>
        public string NoDokumen { get; set; }

        /// <summary>
        /// Gets or sets the TglDokumen.
        /// </summary>
        /// <value>The TglDokumen.</value>
        public string TglDokumen { get; set; }

        /// <summary>
        /// Gets or sets the FileDokumen.
        /// </summary>
        /// <value>The FileDokumen.</value>
        public string FileDokumen { get; set; }

        /// <summary>
        /// Gets or sets the Keterangan.
        /// </summary>
        /// <value>The Keterangan.</value>
        public string Keterangan { get; set; }
    }
}