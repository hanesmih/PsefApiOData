namespace PsefApiOData.Misc
{
    /// <summary>
    /// Api security configuration options.
    /// </summary>
    public class ApiSecurityOptions
    {
        /// <summary>
        /// Configuration options name.
        /// </summary>
        public const string OptionsName = "Bearer";

        /// <summary>
        /// Gets or sets the authority server url.
        /// </summary>
        /// <value>The authority server url.</value>
        public string Authority { get; set; }

        /// <summary>
        /// Gets or sets the Api audience (Api resource name).
        /// </summary>
        /// <value>The Api audience.</value>
        public string Audience { get; set; }
    }
}
