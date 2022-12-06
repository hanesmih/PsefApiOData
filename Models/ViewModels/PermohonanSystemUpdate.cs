using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents Permohonan update data.
    /// </summary>
    public class PermohonanSystemUpdate
    {
        /// <summary>
        /// Gets or sets the update Permohonan unique identifier.
        /// </summary>
        /// <value>The update Permohonan's unique identifier.</value>
        public uint PermohonanId { get; set; }

        /// <summary>
        /// Gets or sets the update reason.
        /// </summary>
        /// <value>The update's reason.</value>
        public string Reason { get; set; }
    }
}