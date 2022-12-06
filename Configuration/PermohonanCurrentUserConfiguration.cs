using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using PsefApiOData.Controllers;
using PsefApiOData.Models;

namespace PsefApiOData.Configuration
{
    /// <summary>
    /// Represents the model configuration for Permohonan for current user.
    /// </summary>
    public class PermohonanCurrentUserConfiguration : IModelConfiguration
    {
        /// <summary>
        /// Applies model configurations using the provided builder for the specified API version.
        /// </summary>
        /// <param name="builder">The <see cref="ODataModelBuilder">builder</see> used to apply configurations.</param>
        /// <param name="apiVersion">The <see cref="ApiVersion">API version</see> associated with the <paramref name="builder"/>.</param>
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            EntityTypeConfiguration<Permohonan> permohonan = builder
                .EntitySet<Permohonan>(nameof(Permohonan) + ApiInfo.CurrentUser)
                .EntityType;

            permohonan.Collection
                .Function(nameof(PermohonanCurrentUserController.Rumusan))
                .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            //permohonan.Collection
            //    .Function(nameof(PermohonanCurrentUserController.Rumusan))
            //    .Returns<PermohonanView>();
            permohonan.Collection
                .Function(nameof(PermohonanCurrentUserController.Dikembalikan))
                .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            permohonan.Collection
                .Function(nameof(PermohonanCurrentUserController.Progress))
                .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            permohonan.Collection
                .Function(nameof(PermohonanCurrentUserController.Selesai))
                .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            permohonan.Collection
                .Function(nameof(PermohonanCurrentUserController.Ditolak))
                .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            permohonan.Collection
                .Function(nameof(PermohonanCurrentUserController.AlasanDikembalikan))
                .Returns<PermohonanSystemUpdate>();
            permohonan.Collection
                .Function(nameof(PermohonanCurrentUserController.CekStatusBillingPnbp))
                .Returns<PermohonanBilling>();

            //permohonan.Collection
            //    .Function(nameof(PermohonanCurrentUserController.PerubahanIzin))
            //    .Returns<PerubahanIzin>();

            permohonan.Collection
                .Action(nameof(PermohonanCurrentUserController.Ajukan));

            permohonan.Collection
                .Action(nameof(PermohonanCurrentUserController.AjukanPerubahanIzin));

            permohonan.Collection
                .Action(nameof(PermohonanCurrentUserController.PostPerubahanIzin));

            permohonan.HasKey(p => p.Id);
            permohonan
                .Filter()
                .OrderBy()
                .Page(50, 50)
                .Select();
        }
    }
}