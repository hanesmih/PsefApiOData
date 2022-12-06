using System;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents basic Permohonan with Pemohon data.
    /// </summary>
    public class PermohonanPemohon
    {
        /// <summary>
        /// Gets or sets the Permohonan unique identifier.
        /// </summary>
        /// <value>The Permohonan's unique identifier.</value>
        public uint PermohonanId { get; set; }

        /// <summary>
        /// Gets or sets the Permohonan submit date.
        /// </summary>
        /// <value>The Permohonan's submit date.</value>
        public DateTime SubmittedAt { get; set; }

        /// <summary>
        /// Gets or sets the Permohonan number.
        /// </summary>
        /// <value>The Permohonan's number.</value>
        public string PermohonanNumber { get; set; }

        /// <summary>
        /// Gets or sets the Permohonan domain.
        /// </summary>
        /// <value>The Permohonan's domain.</value>
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the Permohonan last update.
        /// </summary>
        /// <value>The Permohonan's last update.</value>
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// (Read Only) Gets the associated Permohonan Status name.
        /// </summary>
        /// <value>The associated Permohonan Status name.</value>
        public string StatusName { get; set; }

        /// <summary>
        /// (Read Only) Gets the associated Permohonan Type name.
        /// </summary>
        /// <value>The associated Permohonan Type name.</value>
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or sets the Pemohon NIB.
        /// </summary>
        /// <value>The Pemohon's NIB.</value>
        public string Nib { get; set; }

        /// <summary>
        /// Gets or sets the Pemohon company name.
        /// </summary>
        /// <value>The Pemohon's company name.</value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the Pemohon penanggung jawab.
        /// </summary>
        /// <value>The Pemohon's penanggung jawab.</value>
        public string PenanggungJawab { get; set; }

        /// <summary>
        /// Gets or sets the Pemohon name.
        /// </summary>
        /// <value>The Pemohon's name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Pemohon email.
        /// </summary>
        /// <value>The Pemohon's email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the KodeBillingSimponi.
        /// </summary>
        /// <value>The KodeBillingSimponi</value>
        public string KodeBillingSimponi { get; set; }

        /// <summary>
        /// Gets or sets the NTB.
        /// </summary>
        /// <value>The NTB</value>
        public string NTB { get; set; }

        /// <summary>
        /// Gets or sets the NTB.
        /// </summary>
        /// <value>The NTB</value>
        public string NTPN { get; set; }

        /// <summary>
        /// Gets or sets the Permohonan total days from start.
        /// </summary>
        /// <value>The Permohonan's total days from start.</value>
        public int TotalDays { get; set; }

        /// <summary>
        /// Gets or sets the Permohonan user level days.
        /// </summary>
        /// <value>The Permohonan's user level days.</value>
        public int UserLevelDays { get; set; }
    }
}