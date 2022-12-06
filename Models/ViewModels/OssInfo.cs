using System.ComponentModel.DataAnnotations;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a OSS Information.
    /// </summary>
    public class OssInfo
    {
        /// <summary>
        /// Gets or sets the OSS Information NIB.
        /// </summary>
        /// <value>The OSS Information's NIB.</value>
        [Key]
        public string Nib { get; set; }

        /// <summary>
        /// Gets or sets the OSS Information company name.
        /// </summary>
        /// <value>The OSS Information's company name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the OSS Information address.
        /// </summary>
        /// <value>The OSS Information's address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the OSS Information NPWP.
        /// </summary>
        /// <value>The OSS Information's NPWP.</value>
        public string Npwp { get; set; }

        /// <summary>
        /// Gets or sets the OSS Information director name.
        /// </summary>
        /// <value>The OSS Information's director name.</value>
        public string Director { get; set; }
    }
}