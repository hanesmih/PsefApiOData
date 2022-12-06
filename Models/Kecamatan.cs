using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Kecamatan.
    /// </summary>
    public partial class Kecamatan
    {
        /// <summary>
        /// Initializes a new instance of Kecamatan.
        /// </summary>
        public Kecamatan()
        {
            DesaKelurahan = new HashSet<DesaKelurahan>();
        }

        /// <summary>
        /// Gets or sets the unique identifier for the Kecamatan.
        /// </summary>
        /// <value>The Kecamatan's unique identifier.</value>
        public ushort Id { get; set; }

        /// <summary>
        /// Gets or sets the Kecamatan name.
        /// </summary>
        /// <value>The Kecamatan's name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the associated Kabupaten/Kota identifier.
        /// </summary>
        /// <value>The associated Kabupaten/Kota identifier.</value>
        public ushort? KabupatenKotaId { get; set; }

        /// <summary>
        /// Gets or sets Kabupaten/Kota associated with the Kecamatan.
        /// </summary>
        /// <value>The associated Kabupaten/Kota.</value>
        [IgnoreDataMember]
        public virtual KabupatenKota KabupatenKota { get; set; }

        /// <summary>
        /// Gets or sets list of Desa/Kelurahan associated with the Kecamatan.
        /// </summary>
        /// <value>The associated list of Desa/Kelurahan.</value>
        [IgnoreDataMember]
        public virtual ICollection<DesaKelurahan> DesaKelurahan { get; set; }
    }
}
