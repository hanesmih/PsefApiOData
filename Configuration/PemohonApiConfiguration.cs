using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using PsefApiOData.Models;
using PsefApiOData.Controllers;
using System;

namespace PsefApiOData.Configuration
{
    /// <summary>
    /// Represents the model configuration for Pemohon Api.
    /// </summary>
    public class PemohonApiConfiguration : IModelConfiguration
    {
        /// <summary>
        /// Applies model configurations using the provided builder for the specified API version.
        /// </summary>
        /// <param name="builder">The <see cref="ODataModelBuilder">builder</see> used to apply configurations.</param>
        /// <param name="apiVersion">The <see cref="ApiVersion">API version</see> associated with the <paramref name="builder"/>.</param>
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            builder.ComplexType<PemohonApiUpdate>();
            EntityTypeConfiguration<PemohonApiView> pemohonapi = builder
               .EntitySet<PemohonApiView>(nameof(PemohonApi))
               .EntityType;

            pemohonapi.Collection
                .Function(nameof(PemohonApiController.UserApi))
                .Returns<PemohonApiView>();

            pemohonapi.HasKey(p => p.Id);
            pemohonapi
                .Filter()
                .OrderBy()
                .Page(50, 50)
                .Select();
        }
    }
}

