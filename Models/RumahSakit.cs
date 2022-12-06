using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Rumah Sakit.
    /// </summary>
    public partial class RumahSakit
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Rumah Sakit.
        /// </summary>
        /// <value>The Rumah Sakit's unique identifier.</value>
        public ulong Id { get; set; }

        /// <summary>
        /// Gets or sets the Rumah Sakit name.
        /// </summary>
        /// <value>The Rumah Sakit's name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the associated Permohonan identifier.
        /// </summary>
        /// <value>The associated Permohonan identifier.</value>
        public uint? PermohonanId { get; set; }

        /// <summary>
        /// Gets or sets the Rumah Sakit SIA number.
        /// </summary>
        /// <value>The Rumah Sakit's SIA number.</value>
        public string SiaNumber { get; set; }

        /// <summary>
        /// Gets or sets the Rumah Sakit Apoteker name.
        /// </summary>
        /// <value>The Rumah Sakit's Apoteker name.</value>
        public string ApotekerName { get; set; }

        /// <summary>
        /// Gets or sets the Rumah Sakit Apoteker STRA number.
        /// </summary>
        /// <value>The Rumah Sakit's Apoteker STRA number.</value>
        public string StraNumber { get; set; }

        /// <summary>
        /// Gets or sets the Rumah Sakit SIPA number.
        /// </summary>
        /// <value>The Rumah Sakit's SIPA number.</value>
        public string SipaNumber { get; set; }

        /// <summary>
        /// Gets or sets the Rumah Sakit address.
        /// </summary>
        /// <value>The Rumah Sakit's address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the associated Provinsi identifier.
        /// </summary>
        /// <value>The associated Provinsi identifier.</value>
        public byte? ProvinsiId { get; set; }

        /// <summary>
        /// (Read only) Gets the associated Provinsi name.
        /// </summary>
        /// <value>The associated Provinsi name.</value>
        [NotMapped]
        public string ProvinsiName
        {
            get => Provinsi?.Name;
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets Permohonan associated with the Rumah Sakit.
        /// </summary>
        /// <value>The associated Permohonan.</value>
        [IgnoreDataMember]
        public virtual Permohonan Permohonan { get; set; }

        /// <summary>
        /// Gets or sets Provinsi associated with the Rumah Sakit.
        /// </summary>
        /// <value>The associated Provinsi.</value>
        [IgnoreDataMember]
        public virtual Provinsi Provinsi { get; set; }
    }
}
