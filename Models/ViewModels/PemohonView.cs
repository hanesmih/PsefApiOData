namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Pemohon.
    /// </summary>
    public class PemohonView
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Pemohon.
        /// </summary>
        /// <value>The Pemohon's unique identifier.</value>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the associated user identifier.
        /// </summary>
        /// <value>The associated user identifier.</value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the Pemohon phone number.
        /// </summary>
        /// <value>The Pemohon's phone number.</value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the Pemohon address.
        /// </summary>
        /// <value>The Pemohon's address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Pemohon NIB.
        /// </summary>
        /// <value>The Pemohon's NIB.</value>
        public string Nib { get; set; }

        /// <summary>
        /// Gets or sets the Pemohon company name.
        /// </summary>
        /// <value>The Pemohon's company name.</value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the Pemohon penanggung jawab.
        /// </summary>
        /// <value>The Pemohon's penanggung jawab.</value>
        public string PenanggungJawab { get; set; }
    }
}
