using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using PsefApiOData.Controllers;
using PsefApiOData.Models;

namespace PsefApiOData.Configuration
{
    /// <summary>
    /// Represents the model configuration for Rumah Sakit.
    /// </summary>
    public class RumahSakitConfiguration : IModelConfiguration
    {
        /// <summary>
        /// Applies model configurations using the provided builder for the specified API version.
        /// </summary>
        /// <param name="builder">The <see cref="ODataModelBuilder">builder</see> used to apply configurations.</param>
        /// <param name="apiVersion">The <see cref="ApiVersion">API version</see> associated with the <paramref name="builder"/>.</param>
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            EntityTypeConfiguration<RumahSakit> rumahSakit = builder
                .EntitySet<RumahSakit>(nameof(RumahSakit))
                .EntityType;

            rumahSakit.Collection
                .Function(nameof(RumahSakitController.TotalCount))
                .Returns<long>();

            rumahSakit.Property(e => e.ProvinsiName).AddedExplicitly = true;
            rumahSakit.HasKey(p => p.Id);
            rumahSakit
                .Expand(SelectExpandType.Disabled)
                .Filter()
                .OrderBy()
                .Page(50, 50)
                .Select();
        }
    }
}