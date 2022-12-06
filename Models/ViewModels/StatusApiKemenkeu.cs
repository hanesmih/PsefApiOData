namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Status Response From Api Kemenkeu.
    /// </summary>
    public class StatusApiKemenkeu
    {
        /// <summary>
        /// Gets or sets Response Code.
        /// </summary>
        /// <value>The Response Code.</value>
        public string code { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>The Description.</value>
        public string description { get; set; }
    }
}