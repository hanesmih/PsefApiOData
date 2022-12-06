using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Permohonan Billing.
    /// </summary>
    public class PermohonanBilling
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Billing.
        /// </summary>
        /// <value>The Pemohon's unique identifier.</value>
        public uint Id { get; set; }

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
        public string TglJamBilling { get; set; }

        /// <summary>
        /// Gets or sets the TglJamBilling.
        /// </summary>
        /// <value>The TglJamBilling</value>
        public string TglJamExpiredBilling { get; set; }

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
        /// Gets or sets the TglJamBilling.
        /// </summary>
        /// <value>The TglJamBilling</value>
        public string TglJamPembayaran { get; set; }

        /// <summary>
        /// Gets or sets the NTB.
        /// </summary>
        /// <value>The NTB</value>
        public string BankPersepsi { get; set; }

        /// <summary>
        /// Gets or sets the ChannelPembayaranId.
        /// </summary>
        /// <value>The ChannelPembayaranID</value>
        public string ChannelPembayaranID { get; set; }

        /// <summary>
        /// Gets or sets the TglBuku.
        /// </summary>
        /// <value>The TglBuku</value>
        public string TglBuku { get; set; }

        /// <summary>
        /// Gets or sets Status Pembayaran.
        /// </summary>
        /// <value>The Status Pembayaran</value>
        public int StatusBayar { get; set; }

    }
}

