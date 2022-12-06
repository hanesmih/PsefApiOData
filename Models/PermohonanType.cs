using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Permohonan Type.
    /// </summary>
    public partial class PermohonanType
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Permohonan Type.
        /// </summary>
        /// <value>The Permohonan Type's unique identifier.</value>
        public byte Id { get; set; }

        /// <summary>
        /// Gets or sets the Permohonan Type name.
        /// </summary>
        /// <value>The Permohonan Type's name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Permohonan Type Baru.
        /// </summary>
        /// <value>Permohonan Type Baru.</value>
        public static PermohonanType Baru => new PermohonanType
        {
            Id = 1,
            Name = "Baru"
        };

        /// <summary>
        /// Permohonan Type Perpanjangan.
        /// </summary>
        /// <value>Permohonan Type Perpanjangan.</value>
        public static PermohonanType Perpanjangan => new PermohonanType
        {
            Id = 2,
            Name = "Perpanjangan"
        };

        /// <summary>
        /// Permohonan Type Perpanjangan.
        /// </summary>
        /// <value>Permohonan Type Perpanjangan.</value>
        public static PermohonanType Peubahanan => new PermohonanType
        {
            Id = 3,
            Name = "Peubahanan"
        };

        /// <summary>
        /// Gets list of predefined Permohonan Type.
        /// </summary>
        /// <value></value>
        public static List<PermohonanType> List => new List<PermohonanType>
        {
            Baru,
            Perpanjangan,
            Peubahanan
        };
    }
}