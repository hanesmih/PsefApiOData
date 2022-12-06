using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using PsefApiOData.Controllers;

namespace PsefApiOData.Configuration
{
    /// <summary>
    /// Represents the model configuration for file management.
    /// </summary>
    public class FileConfiguration : IModelConfiguration
    {
        /// <summary>
        /// Applies model configurations using the provided builder for the specified API version.
        /// </summary>
        /// <param name="builder">The <see cref="ODataModelBuilder">builder</see> used to apply configurations.</param>
        /// <param name="apiVersion">The <see cref="ApiVersion">API version</see> associated with the <paramref name="builder"/>.</param>
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            builder.Function(nameof(FileController.UploadUserFile))
                .Returns<string>();
            builder.Function(nameof(FileController.UploadBanner))
                .Returns<string>();
            builder.Function(nameof(FileController.UploadNewsImage))
                .Returns<string>();
            builder.Function(nameof(FileController.UploadUnduhan))
                .Returns<string>();

            builder.Function(nameof(FileController.UploadLaporan))
                .Returns<string>();
        }
    }
}