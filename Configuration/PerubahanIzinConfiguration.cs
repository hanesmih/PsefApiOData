using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using PsefApiOData.Models;
using PsefApiOData.Controllers;
using System;

namespace PsefApiOData.Configuration
{
    /// <summary>
    /// Represents the model configuration for Perubahan Izin.
    /// </summary>
    public class PerubahanIzinConfiguration : IModelConfiguration
    {
        /// <summary>
        /// Applies model configurations using the provided builder for the specified API version.
        /// </summary>
        /// <param name="builder">The <see cref="ODataModelBuilder">builder</see> used to apply configurations.</param>
        /// <param name="apiVersion">The <see cref="ApiVersion">API version</see> associated with the <paramref name="builder"/>.</param>
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            EntityTypeConfiguration<PerubahanIzin> perubahanIzin = builder
                .EntitySet<PerubahanIzin>(nameof(PerubahanIzin))
                .EntityType;

            builder.ComplexType<PermohonanSystemUpdate>();

            perubahanIzin.Property(e => e.StatusName).AddedExplicitly = true;
            perubahanIzin.Property(e => e.PemohonStatusName).AddedExplicitly = true;
            perubahanIzin.Property(e => e.TypeName).AddedExplicitly = true;

            perubahanIzin.Collection
                .Function(nameof(PerubahanIzinController.PerubahanIzinCurrentUser))
                .Returns<PerubahanIzin>();

            perubahanIzin.Collection
                .Action(nameof(PerubahanIzinController.VerifikatorSetujui));
            //perubahanIzin.Collection
            //    .Action(nameof(PerubahanIzinController.VerifikatorKembalikan));
            perubahanIzin.Collection
                .Action(nameof(PerubahanIzinController.KepalaSeksiSetujui));
            //perubahanIzin.Collection
            //    .Action(nameof(PerubahanIzinController.KepalaSeksiKembalikan));
            perubahanIzin.Collection
                .Action(nameof(PerubahanIzinController.KepalaSubDirektoratSetujui));
            //permohonan.Collection
            //    .Action(nameof(PerubahanIzinController.KepalaSubDirektoratKembalikan));
            perubahanIzin.Collection
                .Action(nameof(PerubahanIzinController.DirekturPelayananFarmasiSetujui));
            //permohonan.Collection
            //    .Action(nameof(PerubahanIzinController.DirekturPelayananFarmasiKembalikan));
            //permohonan.Collection
            //    .Action(nameof(PerubahanIzinController.DirekturJenderalSetujui));
            //permohonan.Collection
            //    .Action(nameof(PerubahanIzinController.DirekturJenderalKembalikan));
            perubahanIzin.Collection
                .Action(nameof(PerubahanIzinController.DirekturJenderalSelesaikan));
            //permohonan.Collection
            //    .Action(nameof(PerubahanIzinController.ValidatorSelesaikan));
            //permohonan.Collection
            //    .Action(nameof(PerubahanIzinController.ValidatorRegenerateTandaDaftar));

            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.TotalCount))
            //    .Returns<long>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.VerifikatorPendingTotal))
            //    .Returns<long>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.KepalaSeksiPendingTotal))
            //    .Returns<long>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.KepalaSubDirektoratPendingTotal))
            //    .Returns<long>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.DirekturPelayananFarmasiPendingTotal))
            //    .Returns<long>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.DirekturJenderalPendingTotal))
            //    .Returns<long>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.ValidatorSertifikatPendingTotal))
            //    .Returns<long>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.SemuaPermohonan))
            //    .Returns<long>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.ProgressAdmin))
            //    .Returns<long>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.DitolakAdmin))
            //    .Returns<long>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.Semua))
            //    .Returns<PermohonanPemohon>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.Baru))
            //    .Returns<PermohonanPemohon>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.VerifikatorPending))
            //    .Returns<PermohonanPemohon>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.KepalaSeksiPending))
            //    .Returns<PermohonanPemohon>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.KepalaSubDirektoratPending))
            //    .Returns<PermohonanPemohon>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.DirekturPelayananFarmasiPending))
            //    .Returns<PermohonanPemohon>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.DirekturJenderalPending))
            //    .Returns<PermohonanPemohon>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.DirekturJenderalDisetujui))
            //    .Returns<PermohonanPemohon>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.ValidatorSertifikatPending))
            //    .Returns<PermohonanPemohon>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.ValidatorSertifikatDone))
            //    .Returns<PermohonanPemohon>();
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.Rumusan))
            //    .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.Progress))
            //    .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.DirekturPelayananFarmasiDisetujui))
            //    .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.Selesai))
            //    .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.Ditolak))
            //    .ReturnsFromEntitySet<Permohonan>(nameof(Permohonan));
            //permohonan.Collection
            //    .Function(nameof(PerubahanIzinController.LayananTotalStartTime))
            //    .Returns<DateTime>();

            perubahanIzin.HasKey(p => p.Id);
            perubahanIzin
                .Filter()
                .OrderBy()
                .Page(50, 50)
                .Select();
        }
    }
}