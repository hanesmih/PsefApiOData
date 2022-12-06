namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Homepage Unduhan.
    /// </summary>
    public partial class HomepageUnduhan
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Homepage Unduhan.
        /// </summary>
        /// <value>The Homepage Unduhan's unique identifier.</value>
        public ushort Id { get; set; }

        /// <summary>
        /// Gets or sets the Homepage Unduhan title.
        /// </summary>
        /// <value>The Homepage Unduhan's title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Homepage Unduhan url.
        /// </summary>
        /// <value>The Homepage Unduhan's url.</value>
        public string Url { get; set; }
    }
}
