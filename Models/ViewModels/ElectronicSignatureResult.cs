using System.Net;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Electronic signature result.
    /// </summary>
    public class ElectronicSignatureResult
    {
        /// <summary>
        /// Gets or sets the result success status.
        /// </summary>
        /// <value>The result success status.</value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the result http status code.
        /// </summary>
        /// <value>The result http status code.</value>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the result content on failure.
        /// </summary>
        /// <value>The result content on failure (empty on success).</value>
        public string FailureContent { get; set; }
    }
}
