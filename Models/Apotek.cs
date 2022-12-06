using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Apotek.
    /// </summary>
    public partial class Apotek
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Apotek.
        /// </summary>
        /// <value>The Apotek's unique identifier.</value>
        public ulong Id { get; set; }

        /// <summary>
        /// Gets or sets the Apotek name.
        /// </summary>
        /// <value>The Apotek's name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the associated Permohonan identifier.
        /// </summary>
        /// <value>The associated Permohonan identifier.</value>
        public uint? PermohonanId { get; set; }

        /// <summary>
        /// Gets or sets the Apotek SIA number.
        /// </summary>
        /// <value>The Apotek's SIA number.</value>
        public string SiaNumber { get; set; }

        /// <summary>
        /// Gets or sets the Apotek apoteker name.
        /// </summary>
        /// <value>The Apotek's apoteker name.</value>
        public string ApotekerName { get; set; }

        /// <summary>
        /// Gets or sets the Apotek apoteker STRA number.
        /// </summary>
        /// <value>The Apotek's apoteker STRA number.</value>
        public string StraNumber { get; set; }

        /// <summary>
        /// Gets or sets the Apotek SIPA number.
        /// </summary>
        /// <value>The Apotek's SIPA number.</value>
        public string SipaNumber { get; set; }

        /// <summary>
        /// Gets or sets the Apotek address.
        /// </summary>
        /// <value>The Apotek's address.</value>
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
        /// Gets or sets Permohonan associated with the Apotek.
        /// </summary>
        /// <value>The associated Permohonan.</value>
        [IgnoreDataMember]
        public virtual Permohonan Permohonan { get; set; }

        /// <summary>
        /// Gets or sets Provinsi associated with the Apotek.
        /// </summary>
        /// <value>The associated Provinsi.</value>
        [IgnoreDataMember]
        public virtual Provinsi Provinsi { get; set; }
    }
}
