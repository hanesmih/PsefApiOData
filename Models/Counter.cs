namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents Counter information.
    /// </summary>
    public partial class Counter
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Counter.
        /// </summary>
        /// <value>The Counter's unique identifier.</value>
        public ushort Id { get; set; }

        /// <summary>
        /// Gets or sets the Counter name.
        /// </summary>
        /// <value>The Counter's name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Counter display format.
        /// </summary>
        /// <value>The Counter's display format.</value>
        public string DisplayFormat { get; set; }

        /// <summary>
        /// Gets or sets the Counter last value date format.
        /// </summary>
        /// <value>The Counter's last value date format.</value>
        public string DateFormat { get; set; }

        /// <summary>
        /// Gets or sets the Counter last value date part.
        /// </summary>
        /// <value>The Counter's last value date part.</value>
        public string LastValueDate { get; set; }

        /// <summary>
        /// Gets or sets the Counter last value number part.
        /// </summary>
        /// <value>The Counter's last value number part.</value>
        public int LastValueNumber { get; set; }
    }
}
