namespace PsefApiOData.Misc
{
    /// <summary>
    /// SMTP configuration options.
    /// </summary>
    public class SmtpOptions
    {
        /// <summary>
        /// Configuration options name.
        /// </summary>
        public const string OptionsName = "Smtp";

        /// <summary>
        /// Gets or sets the SMTP Email From address.
        /// </summary>
        /// <value>The SMTP Email From address.</value>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets the SMTP Email From address display name.
        /// </summary>
        /// <value>The SMTP Email From address display name.</value>
        public string FromDisplay { get; set; }

        /// <summary>
        /// Gets or sets the SMTP Host name.
        /// </summary>
        /// <value>The SMTP Host name.</value>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the SMTP login.
        /// </summary>
        /// <value>The SMTP login.</value>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the SMTP login password.
        /// </summary>
        /// <value>The SMTP login password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the SMTP server port.
        /// </summary>
        /// <value>The SMTP server port.</value>
        public int Port { get; set; } = 587; // default smtp port

        /// <summary>
        /// Gets or sets whether SMTP is SSL enabled.
        /// </summary>
        /// <value>Whether SMTP is SSL enabled.</value>
        public bool UseSSL { get; set; } = true;
    }
}