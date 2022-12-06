namespace PsefApiOData.Misc
{
    /// <summary>
    /// Electronic signature configuration options.
    /// </summary>
    public class ElectronicSignatureOptions
    {
        /// <summary>
        /// Configuration options name.
        /// </summary>
        public const string OptionsName = "Signature";

        /// <summary>
        /// Gets or sets the signer name.
        /// </summary>
        /// <value>The signer name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the signer position.
        /// </summary>
        /// <value>The signer position.</value>
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the API username.
        /// </summary>
        /// <value>The API username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the API password.
        /// </summary>
        /// <value>The API password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the API base uri.
        /// </summary>
        /// <value>The API base uri.</value>
        public string BaseUri { get; set; }

       /// <summary>
        /// Gets or sets the signer NIK.
        /// </summary>
        /// <value>The signer NIK.</value>
        public string Nik { get; set; }
    }
}
