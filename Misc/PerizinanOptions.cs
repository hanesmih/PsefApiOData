namespace PsefApiOData.Misc
{
    /// <summary>
    /// Perizinan configuration options.
    /// </summary>
    public class PerizinanOptions
    {
        /// <summary>
        /// Configuration options name.
        /// </summary>
        public const string OptionsName = "Perizinan";

        /// <summary>
        /// Gets or sets the Perizinan expiry time in years.
        /// </summary>
        /// <value>The Perizinan expiry time in years.</value>
        public int ExpiryInYears { get; set; }

        /// <summary>
        /// Gets or sets the Perizinan reminder time in month.
        /// </summary>
        /// <value>The Perizinan reminder time in month.</value>
        public int ReminderTimeInMonth { get; set; }
    }
}
