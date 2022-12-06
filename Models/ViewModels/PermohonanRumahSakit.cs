using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents multiple Rumah Sakit update data.
    /// </summary>
    public class PermohonanRumahSakit
    {
        /// <summary>
        /// Gets or sets the Permohonan unique identifier.
        /// </summary>
        /// <value>The Permohonan's unique identifier.</value>
        public uint PermohonanId { get; set; }

        /// <summary>
        /// Gets or sets list of Rumah Sakit to post.
        /// </summary>
        /// <value>The  list of Rumah Sakit to post.</value>
        public List<RumahSakit> RumahSakit { get; set; }
    }
}