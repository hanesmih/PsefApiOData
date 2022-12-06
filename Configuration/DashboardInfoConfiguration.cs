using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using PsefApiOData.Models;
using PsefApiOData.Controllers;

namespace PsefApiOData.Configuration
{
    /// <summary>
    /// Represents the model configuration for Dashboard Info.
    /// </summary>
    public class DashboardInfoConfiguration : IModelConfiguration
    {
        /// <summary>
        /// Applies model configurations using the provided builder for the specified API version.
        /// </summary>
        /// <param name="builder">The <see cref="ODataModelBuilder">builder</see> used to apply configurations.</param>
        /// <param name="apiVersion">The <see cref="ApiVersion">API version</see> associated with the <paramref name="builder"/>.</param>
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            builder.ComplexType<DashboardInfo>();

            builder.Function(nameof(DashboardInfoController.DashboardPemohon))
                .Returns<DashboardInfo>();
            builder.Function(nameof(DashboardInfoController.DashboardAdmin))
                .Returns<DashboardInfo>();
            builder.Function(nameof(DashboardInfoController.DashboardVerifikator))
                .Returns<DashboardInfo>();
            builder.Function(nameof(DashboardInfoController.DashboardKepalaSeksi))
                .Returns<DashboardInfo>();
            builder.Function(nameof(DashboardInfoController.DashboardKepalaSubDirektorat))
                .Returns<DashboardInfo>();
            builder.Function(nameof(DashboardInfoController.DashboardDirekturPelayananFarmasi))
                .Returns<DashboardInfo>();
            builder.Function(nameof(DashboardInfoController.DashboardDirekturJenderal))
                .Returns<DashboardInfo>();
            builder.Function(nameof(DashboardInfoController.DashboardValidatorSertifikat))
                .Returns<DashboardInfo>();
        }
    }
}