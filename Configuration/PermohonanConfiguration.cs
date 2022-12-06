using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using PsefApiOData.Models;
using PsefApiOData.Controllers;
using System;

namespace PsefApiOData.Configuration
{
    /// <summary>
    /// Represents the model configuration for Permohonan.
    /// </summary>
    public class PermohonanConfiguration : IModelConfiguration
    {
        /// <summary>
        /// Applies model configurations using the provided builder for the specified API version.
        /// </summary>
        /// <param name="builder">The <see cref="ODataModelBuilder">builder</see> used to apply configurations.</param>
        /// <param name="apiVersion">The <see cref="ApiVersion">API version</see> associated with the <paramref name="builder"/>.</param>
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            EntityTypeConfiguration<Permohonan> permohonan = builder
                .EntitySet<Permohonan>(nameof(Permohonan))
                .EntityType;
            builder.ComplexType<PermohonanSystemUpdate>();

            permohonan.Property(e => e.StatusName).AddedExplicitly = true;
            permohonan.Property(e => e.PemohonStatusName).AddedExplicitly = true;
            permohonan.Property(e => e.TypeName).AddedExplicitly = true;

            permohonan.Collection
                .Action(nameof(PermohonanController.VerifikatorSetujui));
            permohonan.Collection
                .Action(nameof(PermohonanController.VerifikatorKembalikan));
            permohonan.Collection
                .Action(nameof(PermohonanController.KepalaSeksiSetujui));
            permohonan.Collection
                .Action(nameof(PermohonanController.KepalaSeksiKembalikan));
            permohonan.Collection
                .Action(nameof(PermohonanController.KepalaSubDirektoratSetujui));
            permohonan.Collection
                .Action(nameof(PermohonanController.KepalaSubDirektoratKembalikan));
            permohonan.Collection
                .Action(nameof(PermohonanController.DirekturPelayananFarmasiSetujui));
            permohonan.Collection
                .Action(nameof(PermohonanController.DirekturPelayananFarmasiKembalikan));
            permohonan.Collection
                .Action(nameof(PermohonanController.DirekturJenderalSetujui));
            permohonan.Collection
                .Action(nameof(PermohonanController.DirekturJenderalKembalikan));
            permohonan.Collection
                .Action(nameof(PermohonanController.DirekturJenderalSelesaikan));
            permohonan.Collection
                .Action(nameof(PermohonanController.ValidatorSelesaikan));
            permohonan.Collection
                .Action(nameof(PermohonanController.ValidatorRegenerateTandaDaftar));

            permohonan.Collection
                .Function(nameof(PermohonanController.TotalCount))
                .Returns<long>();
            permohonan.Collection
                .Function(nameof(PermohonanController.VerifikatorPendingTotal))
                .Returns<long>();
            permohonan.Collection
                .Function(nameof(PermohonanController.KepalaSeksiPendingTotal))
                .Returns<long>();
            permohonan.Collection
                .Function(nameof(PermohonanController.KepalaSubDirektoratPendingTotal))
                .Returns<long>();
            permohonan.Collection
                .Function(nameof(PermohonanController.DirekturPelayananFarmasiPendingTotal))
                .Returns<long>();
            permohonan.Collection
                .Function(nameof(PermohonanController.DirekturJenderalPendingTotal))
                .Returns<long>();
            permohonan.Collection
                .Function(nameof(PermohonanController.ValidatorSertifikatPendingTotal))
                .Returns<long>();
            permohonan.Collection
                .Function(nameof(PermohonanController.SemuaPermohonan))
                .Returns<long>();
            permohonan.Collection
                .Function(nameof(PermohonanController.ProgressAdmin))
                .Returns<long>();
            permohonan.Collection
                .Function(nameof(PermohonanController.DitolakAdmin))
                .Returns<long>();
            permohonan.Collection
                .Function(nameof(PermohonanController.Semua))
                .Returns<PermohonanPemohon>();
            permohonan.Collection
                .Function(nameof(PermohonanController.Baru))
                .Returns<PermohonanPemohon>();
            permohonan.Collection
                .Function(nameof(PermohonanController.VerifikatorPending))
                .Returns<PermohonanPemohon>();
            permohonan.Collection
                .Function(nameof(PermohonanController.KepalaSeksiPending))
                .Returns<PermohonanPemohon>();
            permohonan.Collection
                .Function(nameof(PermohonanController.KepalaSubDirektoratPending))
                .Returns<PermohonanPemohon>();
            permohonan.Collection
                .Function(nameof(PermohonanController.DirekturPelayananFarmasiPending))
                .Returns<PermohonanPemohon>();
            permohonan.Collection
                .Function(nameof(PermohonanController.DirekturJenderalPending))
                .Returns<PermohonanPemohon>();
            permohonan.Collection
                .Function(nameof(PermohonanController.DirekturJenderalDisetujui))
                .Returns<PermohonanPemohon>();
            permohonan.Collection
                .Function(nameof(PermohonanController.DirekturJenderalSelesai))
                .Returns<PermohonanPemohon>();
            permohonan.Collection
                .Function(nameof(PermohonanController.ValidatorSertifikatPending))
                .Returns<PermohonanPemohon>();
            permohonan.Collection
                .Function(nameof(PermohonanController.ValidatorSertifikatDone))
                .Returns<PermohonanPemohon>();
            permohonan.Collection
                .Function(nameof(PermohonanController.Rumusan))
                .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            permohonan.Collection
                .Function(nameof(PermohonanController.Progress))
                .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            permohonan.Collection
                .Function(nameof(PermohonanController.DirekturPelayananFarmasiDisetujui))
                .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            permohonan.Collection
                .Function(nameof(PermohonanController.Selesai))
                .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            permohonan.Collection
                .Function(nameof(PermohonanController.Ditolak))
                .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            permohonan.Collection
                .Function(nameof(PermohonanController.LayananTotalStartTime))
                .Returns<DateTime>();

            permohonan.HasKey(p => p.Id);
            permohonan
                .Filter()
                .OrderBy()
                .Page(50, 50)
                .Select();
        }
    }
}