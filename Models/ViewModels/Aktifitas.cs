using System;
using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Aktifitas Information.
    /// </summary>
    public class Aktifitas
    {
        /// <summary>
        /// Gets or sets the Aktifitas user name.
        /// </summary>
        /// <value>The Aktifitas's user name.</value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the Aktifitas date.
        /// </summary>
        /// <value>The Aktifitas's date.</value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the Aktifitas action.
        /// </summary>
        /// <value>The Aktifitas's action.</value>
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the Aktifitas item.
        /// </summary>
        /// <value>The Aktifitas's item.</value>
        public string Item { get; set; }

        /// <summary>
        /// Gets or sets the Aktifitas item identifier.
        /// </summary>
        /// <value>The Aktifitas's item identifier.</value>
        public uint? ItemId { get; set; }
    }
}