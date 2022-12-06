namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Pemohon.
    /// </summary>
    public class PemohonApiUpdate
    {
        /// <summary>
        /// Gets or sets the Pemohon API url.
        /// </summary>
        /// <value>The Pemohon's API url.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the token for the API Token.
        /// </summary>
        /// <value>The API Token</value>
        public string Token { get; set; }
    }
}
