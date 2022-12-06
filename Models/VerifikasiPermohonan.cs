using System.Runtime.Serialization;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Verifikasi Permohonan.
    /// </summary>
    public partial class VerifikasiPermohonan
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Verifikasi Permohonan.
        /// </summary>
        /// <value>The Verifikasi Permohonan's unique identifier.</value>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the associated Permohonan identifier.
        /// </summary>
        /// <value>The associated Permohonan identifier.</value>
        public uint? PermohonanId { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan domain check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's domain check status.</value>
        public sbyte DomainCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan domain check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's domain check reason.</value>
        public string DomainCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan system name check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's system name check status.</value>
        public sbyte SystemNameCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan system name check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's system name check reason.</value>
        public string SystemNameCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan provider name check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's provider name check status.</value>
        public sbyte ProviderNameCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan provider name check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's provider name check reason.</value>
        public string ProviderNameCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan tenaga ahli name check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's tenaga ahli name check status.</value>
        public sbyte TenagaAhliNameCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan tenaga ahli name check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's tenaga ahli name check reason.</value>
        public string TenagaAhliNameCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan apoteker name check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's apoteker name check status.</value>
        public sbyte ApotekerNameCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan apoteker name check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's apoteker name check reason.</value>
        public string ApotekerNameCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan apoteker email check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's apoteker email check status.</value>
        public sbyte ApotekerEmailCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan apoteker email check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's apoteker email check reason.</value>
        public string ApotekerEmailCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan apoteker phone check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's apoteker phone check status.</value>
        public sbyte ApotekerPhoneCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan apoteker phone check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's apoteker phone check reason.</value>
        public string ApotekerPhoneCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan apoteker NIK check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's apoteker NIK check status.</value>
        public sbyte ApotekerNikCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan apoteker NIK check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's apoteker NIK check reason.</value>
        public string ApotekerNikCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan STRA number check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's STRA number check status.</value>
        public sbyte StraNumberCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan STRA number check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's STRA number check reason.</value>
        public string StraNumberCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan STRA expiry check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's STRA expiry check status.</value>
        public sbyte StraExpiryCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan STRA expiry check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's STRA expiry check reason.</value>
        public string StraExpiryCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan STRA check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's STRA check status.</value>
        public sbyte StraUrlCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan STRA check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's STRA check reason.</value>
        public string StraUrlCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan surat permohonan check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's surat permohonan check status.</value>
        public sbyte SuratPermohonanUrlCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan surat permohonan check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's surat permohonan check reason.</value>
        public string SuratPermohonanUrlCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan proses bisnis check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's proses bisnis check status.</value>
        public sbyte ProsesBisnisUrlCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan proses bisnis check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's proses bisnis check reason.</value>
        public string ProsesBisnisUrlCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan dokumen API check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's dokumen API check status.</value>
        public sbyte DokumenApiUrlCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan dokumen API check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's dokumen API check reason.</value>
        public string DokumenApiUrlCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan dokumen PSE check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's dokumen PSE check status.</value>
        public sbyte DokumenPseUrlCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan dokumen PSE check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's dokumen PSE check reason.</value>
        public string DokumenPseUrlCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan izin usaha check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's izin usaha check status.</value>
        public sbyte IzinUsahaUrlCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan izin usaha check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's izin usaha check reason.</value>
        public string IzinUsahaUrlCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan komitmen kerjasama apotek check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's komitmen kerjasama apotek check status.</value>
        public sbyte KomitmenKerjasamaApotekUrlCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan komitmen kerjasama apotek check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's komitmen kerjasama apotek check reason.</value>
        public string KomitmenKerjasamaApotekUrlCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan SPPL check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's SPPL check status.</value>
        public sbyte SpplUrlCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan SPPL check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's SPPL check reason.</value>
        public string SpplUrlCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan izin lokasi check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's izin lokasi check status.</value>
        public sbyte IzinLokasiUrlCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan izin lokasi check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's izin lokasi check reason.</value>
        public string IzinLokasiUrlCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan IMB check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's IMB check status.</value>
        public sbyte ImbUrlCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan IMB check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's IMB check reason.</value>
        public string ImbUrlCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan pembayaran PNBP check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's pembayaran PNBP check status.</value>
        public sbyte PembayaranPnbpUrlCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan pembayaran PNBP check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's pembayaran PNBP check reason.</value>
        public string PembayaranPnbpUrlCheckReason { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan pernyataan keaslian dokumen check status.
        /// </summary>
        /// <value>The Verifikasi Permohonan's pernyataan keaslian dokumen check status.</value>
        public sbyte PernyataanKeaslianDokumenUrlCheck { get; set; }

        /// <summary>
        /// Gets or sets the Verifikasi Permohonan pernyataan keaslian dokumen check reason.
        /// </summary>
        /// <value>The Verifikasi Permohonan's pernyataan keaslian dokumen check reason.</value>
        public string PernyataanKeaslianDokumenUrlCheckReason { get; set; }

        /// <summary>
        /// Gets or sets Permohonan associated with the Verifikasi Permohonan.
        /// </summary>
        /// <value>The associated Permohonan.</value>
        [IgnoreDataMember]
        public virtual Permohonan Permohonan { get; set; }
    }
}
