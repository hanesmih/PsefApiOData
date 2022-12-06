namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Homepage Banner.
    /// </summary>
    public partial class HomepageBanner
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Homepage Banner.
        /// </summary>
        /// <value>The Homepage Banner's unique identifier.</value>
        public ushort Id { get; set; }

        /// <summary>
        /// Gets or sets the Homepage Banner url.
        /// </summary>
        /// <value>The Homepage Banner's url.</value>
        public string Url { get; set; }
    }
}
