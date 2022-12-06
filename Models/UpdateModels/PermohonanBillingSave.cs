using System;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Permohonan Billing.
    /// </summary>
    public class PermohonanBillingSave
    {
        /// <summary>
        /// Gets or sets the associated Permohonan identifier.
        /// </summary>
        /// <value>The associated Permohonan identifier.</value>
        public uint PermohonanId { get; set; }

        /// <summary>
        /// Gets or sets the Transaksi Id Saat request billing.
        /// </summary>
        /// <value>The Increment transaction.</value>
        public string TransaksiIdKL { get; set; }

        /// <summary>
        /// Gets or sets the Transaksi Id Simponi.
        /// </summary>
        /// <value>The No. Transaksi Simponi.</value>
        public string TransaksiIdSimponi { get; set; }

        /// <summary>
        /// Gets or sets the KodeBillingSimponi.
        /// </summary>
        /// <value>The KodeBillingSimponi</value>
        public string KodeBillingSimponi { get; set; }

        /// <summary>
        /// Gets or sets the TglJamBilling.
        /// </summary>
        /// <value>The TglJamBilling</value>
        public DateTime TglJamBilling { get; set; }

        /// <summary>
        /// Gets or sets the TglJamBilling.
        /// </summary>
        /// <value>The TglJamBilling</value>
        public DateTime TglJamExpiredBilling { get; set; }
    }
}

