namespace PsefApiOData.Misc
{
    /// <summary>
    /// Permohonan email configuration options.
    /// </summary>
    public class PermohonanEmailOptions
    {
        /// <summary>
        /// Configuration options name.
        /// </summary>
        public const string OptionsName = "PermohonanEmail";

        /// <summary>
        /// Gets or sets the Permohonan email To address.
        /// </summary>
        /// <value>The Permohonan email To address.</value>
        public string To { get; set; }

        /// <summary>
        /// Gets or sets the Permohonan email To displayed address.
        /// </summary>
        /// <value>The Permohonan email To displayed address.</value>
        public string ToDisplay { get; set; }
    }
}