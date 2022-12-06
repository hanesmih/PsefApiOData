using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Kabupaten/Kota.
    /// </summary>
    public partial class KabupatenKota
    {
        /// <summary>
        /// Initializes a new instance of Kabupaten/Kota.
        /// </summary>
        public KabupatenKota()
        {
            Kecamatan = new HashSet<Kecamatan>();
        }

        /// <summary>
        /// Gets or sets the unique identifier for the Kabupaten/Kota.
        /// </summary>
        /// <value>The Kabupaten/Kota's unique identifier.</value>
        public ushort Id { get; set; }

        /// <summary>
        /// Gets or sets the Kabupaten/Kota name.
        /// </summary>
        /// <value>The Kabupaten/Kota's name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the associated Provinsi identifier.
        /// </summary>
        /// <value>The associated Provinsi identifier.</value>
        public byte? ProvinsiId { get; set; }

        /// <summary>
        /// Gets or sets Provinsi associated with the Kabupaten/Kota.
        /// </summary>
        /// <value>The associated Provinsi.</value>
        [IgnoreDataMember]
        public virtual Provinsi Provinsi { get; set; }

        /// <summary>
        /// Gets or sets list of Kecamatan associated with the Kabupaten/Kota.
        /// </summary>
        /// <value>The associated list of Kecamatan.</value>
        [IgnoreDataMember]
        public virtual ICollection<Kecamatan> Kecamatan { get; set; }
    }
}
