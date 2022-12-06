using System;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Homepage News.
    /// </summary>
    public partial class HomepageNews
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Homepage News.
        /// </summary>
        /// <value>The Homepage News's unique identifier.</value>
        public ushort Id { get; set; }

        /// <summary>
        /// Gets or sets the Homepage News title.
        /// </summary>
        /// <value>The Homepage News's title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Homepage News content.
        /// </summary>
        /// <value>The Homepage News's content.</value>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the Homepage News image url.
        /// </summary>
        /// <value>The Homepage News's image url.</value>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the Homepage News link url.
        /// </summary>
        /// <value>The Homepage News's link url.</value>
        public string LinkUrl { get; set; }

        /// <summary>
        /// Gets or sets the Homepage News published at.
        /// </summary>
        /// <value>The Homepage News's published at.</value>
        public DateTime PublishedAt { get; set; }
    }
}
