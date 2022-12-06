using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using PsefApiOData.Controllers;
using PsefApiOData.Models;

namespace PsefApiOData.Configuration
{
    /// <summary>
    /// Represents the model configuration for Perizinan.
    /// </summary>
    public class PerizinanConfiguration : IModelConfiguration
    {
        /// <summary>
        /// Applies model configurations using the provided builder for the specified API version.
        /// </summary>
        /// <param name="builder">The <see cref="ODataModelBuilder">builder</see> used to apply configurations.</param>
        /// <param name="apiVersion">The <see cref="ApiVersion">API version</see> associated with the <paramref name="builder"/>.</param>
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            builder.ComplexType<PerizinanUpdate>();
            builder.ComplexType<PerizinanTanggalPerubahan>();
            EntityTypeConfiguration<PerizinanView> perizinan = builder
               .EntitySet<PerizinanView>(nameof(Perizinan))
               .EntityType;

            perizinan.Collection
                .Function(nameof(PerizinanController.DownloadFileIzinOss))
                .Returns<string>();

            perizinan.Collection
                .Function(nameof(PerizinanController.HalamanMuka))
                .Returns<PerizinanHalamanMuka>();

            //perizinan.Collection
            //    .Action(nameof(PerizinanController.PerubahanTanggalIzin));


            perizinan.HasKey(p => p.Id);
            perizinan
                .Expand()
                .Filter()
                .OrderBy()
                .Page(50, 50)
                .Select();
        }
    }
}