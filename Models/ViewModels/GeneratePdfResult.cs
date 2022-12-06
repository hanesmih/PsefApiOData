namespace PsefApiOData.Models.ViewModels
{
    /// <summary>
    /// Represents a Generate Pdf Result.
    /// </summary>
    public class GeneratePdfResult
    {
        /// <summary>
        /// Gets or sets the Generate Pdf Result file name.
        /// </summary>
        /// <value>The Generate Pdf Result's file name.</value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the Generate Pdf Result date path.
        /// </summary>
        /// <value>The Generate Pdf Result's date path.</value>
        public string DatePath { get; set; }

        /// <summary>
        /// Gets or sets the Generate Pdf Result full path.
        /// </summary>
        /// <value>The Generate Pdf Result's full path.</value>
        public string FullPath { get; set; }

        /// <summary>
        /// Gets or sets the electronic signature result.
        /// </summary>
        /// <value>The electronic signature result.</value>
        public ElectronicSignatureResult SignResult { get; set; }
    }
}