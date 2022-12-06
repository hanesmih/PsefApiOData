using System;
using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Perizinan.
    /// </summary>
    public partial class Perizinan
    {
        /// <summary>
        /// Initializes a new instance of Perizinan.
        /// </summary>
        public Perizinan()
        {
            InversePrevious = new HashSet<Perizinan>();
            PermohonanPerizinanNavigation = new HashSet<Permohonan>();
            PermohonanPreviousPerizinan = new HashSet<Permohonan>();
        }

        /// <summary>
        /// Gets or sets the unique identifier for the Perizinan.
        /// </summary>
        /// <value>The Perizinan's unique identifier.</value>
        public uint Id { get; set; }

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
        /// Gets or sets the Perizinan OSS document url.
        /// </summary>
        /// <value>The Perizinan's OSS document url.</value>
        public string OssIzinUrl { get; set; }

        /// <summary>
        /// Gets or sets Permohonan associated with the Perizinan.
        /// </summary>
        /// <value>The associated Permohonan.</value>
        public virtual Permohonan Permohonan { get; set; }

        /// <summary>
        /// Gets or sets Permohonan associated with the Perizinan.
        /// </summary>
        /// <value>The associated Permohonan.</value>
        public virtual PerubahanIzin PerubahanIzin { get; set; }

        /// <summary>
        /// Gets or sets Previous Perizinan associated with the Perizinan.
        /// </summary>
        /// <value>The associated Previous Perizinan.</value>
        public virtual Perizinan Previous { get; set; }

        /// <summary>
        /// Gets or sets Next Perizinan associated with the Perizinan.
        /// </summary>
        /// <value>The associated Next Perizinan.</value>
        public virtual ICollection<Perizinan> InversePrevious { get; set; }

        /// <summary>
        /// Gets or sets list of Permohonan associated with the Perizinan.
        /// </summary>
        /// <value>The associated list of Permohonan.</value>
        public virtual ICollection<Permohonan> PermohonanPerizinanNavigation { get; set; }

        /// <summary>
        /// Gets or sets list of Permohonan associated with the Previous Perizinan.
        /// </summary>
        /// <value>The associated list of Permohonan.</value>
        public virtual ICollection<Permohonan> PermohonanPreviousPerizinan { get; set; }
    }
}
