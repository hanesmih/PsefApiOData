using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using PsefApiOData.Models;
using PsefApiOData.Controllers;

namespace PsefApiOData.Configuration
{
    /// <summary>
    /// Represents the model configuration for Pemohon.
    /// </summary>
    public class PemohonConfiguration : IModelConfiguration
    {
        /// <summary>
        /// Applies model configurations using the provided builder for the specified API version.
        /// </summary>
        /// <param name="builder">The <see cref="ODataModelBuilder">builder</see> used to apply configurations.</param>
        /// <param name="apiVersion">The <see cref="ApiVersion">API version</see> associated with the <paramref name="builder"/>.</param>
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            builder.ComplexType<PemohonUpdate>();
            EntityTypeConfiguration<PemohonView> pemohon = builder
               .EntitySet<PemohonView>(nameof(Pemohon))
               .EntityType;
            ComplexTypeConfiguration<PemohonUserInfo> pemohonUserInfo = builder
                .ComplexType<PemohonUserInfo>();

            pemohon.Collection
                .Function(nameof(PemohonController.CurrentUserInfo))
                .Returns<PemohonUserInfo>();
            pemohon.Collection
                .Function(ApiInfo.CurrentUser)
                .ReturnsFromEntitySet<PemohonView>(nameof(Pemohon));
            pemohon.Collection
                .Function(nameof(PemohonController.TotalCount))
                .Returns<long>();

            pemohon.HasKey(p => p.Id);
            pemohon
                .Filter()
                .OrderBy()
                .Page(50, 50)
                .Select();

            pemohonUserInfo
                .Filter()
                .OrderBy()
                .Page(50, 50)
                .Select();
        }
    }
}