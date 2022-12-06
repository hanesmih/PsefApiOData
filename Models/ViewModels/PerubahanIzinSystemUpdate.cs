using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents Permohonan update data.
    /// </summary>
    public class PerubahanIzinSystemUpdate
    {
        /// <summary>
        /// Gets or sets the update Perizinan unique identifier.
        /// </summary>
        /// <value>The update Perizinan's unique identifier.</value>
        public uint PerizinanId { get; set; }

        /// <summary>
        /// Gets or sets the update reason.
        /// </summary>
        /// <value>The update's reason.</value>
        public string Reason { get; set; }
    }
}