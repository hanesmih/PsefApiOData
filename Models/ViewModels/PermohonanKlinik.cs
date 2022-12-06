using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents multiple Klinik update data.
    /// </summary>
    public class PermohonanKlinik
    {
        /// <summary>
        /// Gets or sets the Permohonan unique identifier.
        /// </summary>
        /// <value>The Permohonan's unique identifier.</value>
        public uint PermohonanId { get; set; }

        /// <summary>
        /// Gets or sets list of Klinik to post.
        /// </summary>
        /// <value>The  list of Klinik to post.</value>
        public List<Klinik> Klinik { get; set; }
    }
}