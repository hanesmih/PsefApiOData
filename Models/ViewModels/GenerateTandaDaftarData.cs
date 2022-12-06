namespace PsefApiOData.Models.ViewModels
{
    /// <summary>
    /// Represents Permohonan update to generate tanda daftar data.
    /// </summary>
    public class GenerateTandaDaftarData : PermohonanSystemUpdate
    {
        /// <summary>
        /// Gets or sets the NIK.
        /// </summary>
        /// <value>The NIK.</value>
        public string Nik { get; set; }

        /// <summary>
        /// Gets or sets the passphrase.
        /// </summary>
        /// <value>The passphrase.</value>
        public string Passphrase { get; set; }
    }
}