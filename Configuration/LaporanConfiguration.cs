using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using PsefApiOData.Controllers;
using PsefApiOData.Models;

namespace PsefApiOData.Configuration
{
    /// <summary>
    /// Represents the model configuration for Laporan.
    /// </summary>
    public class LaporanConfiguration : IModelConfiguration
    {
        /// <summary>
        /// Applies model configurations using the provided builder for the specified API version.
        /// </summary>
        /// <param name="builder">The <see cref="ODataModelBuilder">builder</see> used to apply configurations.</param>
        /// <param name="apiVersion">The <see cref="ApiVersion">API version</see> associated with the <paramref name="builder"/>.</param>
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            if (apiVersion < ApiInfo.Ver1_0)
            {
                return;
            }

            EntityTypeConfiguration<Laporan> laporan = builder
                .EntitySet<Laporan>(nameof(Laporan))
                .EntityType;


            laporan.Collection
                .Function(nameof(LaporanController.GetLaporanAll))
                .Returns<LaporanView>();
            laporan.Collection
                .Function(nameof(LaporanController.GetLaporanUser))
                .Returns<LaporanView>();

            laporan.HasKey(p => p.Id);
            laporan
                .Expand(SelectExpandType.Disabled)
                .Filter()
                .OrderBy()
                .Page(50, 50)
                .Select();
        }
    }
}
