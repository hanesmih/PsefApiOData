using System;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a OSS Legalitas Information.
    /// </summary>
    public class OssLegalitas
    {
        /// <summary>
        /// Gets or sets the JenisLegal.
        /// </summary>
        /// <value>The JenisLegal.</value>
        public string JenisLegal { get; set; }

        /// <summary>
        /// Gets or sets the NoLegal.
        /// </summary>
        /// <value>The NoLegal.</value>
        public string NoLegal { get; set; }

        /// <summary>
        /// Gets or sets the TglLegal.
        /// </summary>
        /// <value>The TglLegal.</value>
        public DateTime? TglLegal { get; set; }

        /// <summary>
        /// Gets or sets the AlamatNotaris.
        /// </summary>
        /// <value>The AlamatNotaris.</value>
        public string AlamatNotaris { get; set; }

        /// <summary>
        /// Gets or sets the NamaNotaris.
        /// </summary>
        /// <value>The NamaNotaris.</value>
        public string NamaNotaris { get; set; }

        /// <summary>
        /// Gets or sets the TeleponNotaris.
        /// </summary>
        /// <value>The TeleponNotaris.</value>
        public string TeleponNotaris { get; set; }
    }
}