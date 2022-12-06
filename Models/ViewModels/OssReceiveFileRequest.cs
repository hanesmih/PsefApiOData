using System;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a OSS Receive File Request Information.
    /// </summary>
    public class OssReceiveFileRequest
    {
        /// <summary>
        /// Gets or sets the Nib.
        /// </summary>
        /// <value>The Nib.</value>
        public string Nib { get; set; }

        /// <summary>
        /// Gets or sets the id izin.
        /// </summary>
        /// <value>The id izin.</value>
        public string IdIzin { get; set; }
    }
}