using System.Runtime.Serialization;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Desa/Kelurahan.
    /// </summary>
    public partial class DesaKelurahan
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Desa/Kelurahan.
        /// </summary>
        /// <value>The Desa/Kelurahan's unique identifier.</value>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the Desa/Kelurahan name.
        /// </summary>
        /// <value>The Desa/Kelurahan's name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the associated Kecamatan identifier.
        /// </summary>
        /// <value>The associated Kecamatan identifier.</value>
        public ushort? KecamatanId { get; set; }

        /// <summary>
        /// Gets or sets Kecamatan associated with the Desa/Kelurahan.
        /// </summary>
        /// <value>The associated Kecamatan.</value>
        [IgnoreDataMember]
        public virtual Kecamatan Kecamatan { get; set; }
    }
}
