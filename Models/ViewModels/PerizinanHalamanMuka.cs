using System;
using System.Runtime.Serialization;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Perizinan Halaman Muka information.
    /// </summary>
    public class PerizinanHalamanMuka
    {
        /// <summary>
        /// Gets or sets the Perizinan number.
        /// </summary>
        /// <value>The Perizinan's number.</value>
        public string PerizinanNumber { get; set; }

        /// <summary>
        /// Gets or sets the Perizinan company name.
        /// </summary>
        /// <value>The Perizinan's company name.</value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the Perizinan domain.
        /// </summary>
        /// <value>The Perizinan's domain.</value>
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the Perizinan issued date.
        /// </summary>
        /// <value>The Perizinan's issued date.</value>
        public DateTime IssuedAt { get; set; }
    }
}