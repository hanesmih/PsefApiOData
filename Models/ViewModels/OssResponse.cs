using Newtonsoft.Json.Linq;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a OSS API Response.
    /// </summary>
    public class OssResponse
    {
        /// <summary>
        /// Gets the response success status.
        /// </summary>
        /// <value>The response success status.</value>
        public bool IsSuccess
        {
            get
            {
                return StatusCode == Status200OK ||
                    StatusCode == Status201Created ||
                    StatusCode == Status202Accepted ||
                    StatusCode == Status204NoContent;
            }
        }

        /// <summary>
        /// Gets or sets the response status code.
        /// </summary>
        /// <value>The response status code.</value>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the response information.
        /// </summary>
        /// <value>The response information.</value>
        public string Information { get; set; }

        /// <summary>
        /// Gets or sets the response content.
        /// </summary>
        /// <value>The response content.</value>
        public JObject Content { get; set; }
    }
}
