using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Klinik.
    /// </summary>
    public partial class Klinik
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Klinik.
        /// </summary>
        /// <value>The Klinik's unique identifier.</value>
        public ulong Id { get; set; }

        /// <summary>
        /// Gets or sets the Klinik name.
        /// </summary>
        /// <value>The Klinik's name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the associated Permohonan identifier.
        /// </summary>
        /// <value>The associated Permohonan identifier.</value>
        public uint? PermohonanId { get; set; }

        /// <summary>
        /// Gets or sets the Klinik SIA number.
        /// </summary>
        /// <value>The Klinik's SIA number.</value>
        public string SiaNumber { get; set; }

        /// <summary>
        /// Gets or sets the Klinik Apoteker name.
        /// </summary>
        /// <value>The Klinik's Apoteker name.</value>
        public string ApotekerName { get; set; }

        /// <summary>
        /// Gets or sets the Klinik Apoteker STRA number.
        /// </summary>
        /// <value>The Klinik's Apoteker STRA number.</value>
        public string StraNumber { get; set; }

        /// <summary>
        /// Gets or sets the Klinik SIPA number.
        /// </summary>
        /// <value>The Klinik's SIPA number.</value>
        public string SipaNumber { get; set; }

        /// <summary>
        /// Gets or sets the Klinik address.
        /// </summary>
        /// <value>The Klinik's address.</value>
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
        /// Gets or sets Permohonan associated with the Klinik.
        /// </summary>
        /// <value>The associated Permohonan.</value>
        [IgnoreDataMember]
        public virtual Permohonan Permohonan { get; set; }

        /// <summary>
        /// Gets or sets Provinsi associated with the Klinik.
        /// </summary>
        /// <value>The associated Provinsi.</value>
        [IgnoreDataMember]
        public virtual Provinsi Provinsi { get; set; }
    }
}
