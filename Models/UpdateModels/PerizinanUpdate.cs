using System;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Perizinan Update information.
    /// </summary>
    public class PerizinanUpdate
    {
        /// <summary>
        /// Gets or sets the associated Permohonan identifier.
        /// </summary>
        /// <value>The associated Permohonan identifier.</value>
        public uint? PermohonanId { get; set; }

        /// <summary>
        /// Gets or sets the associated Previous Perizinan identifier.
        /// </summary>
        /// <value>The associated Previous Perizinan identifier.</value>
        public uint? PreviousId { get; set; }

        /// <summary>
        /// Gets or sets the Perizinan number.
        /// </summary>
        /// <value>The Perizinan's number.</value>
        public string PerizinanNumber { get; set; }

        /// <summary>
        /// Gets or sets the Perizinan issued date.
        /// </summary>
        /// <value>The Perizinan's issued date.</value>
        public DateTime IssuedAt { get; set; }

        /// <summary>
        /// Gets or sets the Perizinan expired date.
        /// </summary>
        /// <value>The Perizinan's expired date.</value>
        public DateTime ExpiredAt { get; set; }

        /// <summary>
        /// Gets or sets the Perizinan Tanda Daftar document url.
        /// </summary>
        /// <value>The Perizinan's Tanda Daftar document url.</value>
        public string TandaDaftarUrl { get; set; }

        /// <summary>
        /// Gets or sets the Tanggal Perubahan Izin.
        /// </summary>
        /// <value>The Perizinan's Tanggal Perubahan Izin.</value>
        public string TanggalPerubahanIzin { get; set; }
    }
}
