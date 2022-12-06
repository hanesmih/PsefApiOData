using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Permohonan Status.
    /// </summary>
    public partial class PermohonanStatus
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Permohonan Status.
        /// </summary>
        /// <value>The Permohonan Status's unique identifier.</value>
        public byte Id { get; set; }

        /// <summary>
        /// Gets or sets the Permohonan Status name.
        /// </summary>
        /// <value>The Permohonan Status's name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Permohonan Status name displayed to user.
        /// </summary>
        /// <value>The Permohonan Status's name displayed to user.</value>
        public string PemohonDisplayedName { get; set; }

        /// <summary>
        /// Permohonan Status Dibuat.
        /// </summary>
        /// <value>Permohonan Status Dibuat.</value>
        public static PermohonanStatus Dibuat => new PermohonanStatus
        {
            Id = 1,
            Name = "Dibuat oleh Pemohon",
            PemohonDisplayedName = "Rumusan"
        };

        /// <summary>
        /// Permohonan Status Diajukan.
        /// </summary>
        /// <value>Permohonan Status Diajukan.</value>
        public static PermohonanStatus Diajukan => new PermohonanStatus
        {
            Id = 2,
            Name = "Diajukan oleh Pemohon",
            PemohonDisplayedName = "Diajukan"
        };

        /// <summary>
        /// Permohonan Status Disetujui Verifikator.
        /// </summary>
        /// <value>Permohonan Status Disetujui Verifikator.</value>
        public static PermohonanStatus DisetujuiVerifikator => new PermohonanStatus
        {
            Id = 3,
            Name = "Diteruskan oleh Verifikator",
            PemohonDisplayedName = "Dalam Proses"
        };

        /// <summary>
        /// Permohonan Status Dikembalikan Verifikator.
        /// </summary>
        /// <value>Permohonan Status Dikembalikan Verifikator.</value>
        public static PermohonanStatus DikembalikanVerifikator => new PermohonanStatus
        {
            Id = 4,
            Name = "Dikembalikan oleh Verifikator",
            PemohonDisplayedName = "Dikembalikan"
        };

        /// <summary>
        /// Permohonan Status Disetujui Kepala Seksi.
        /// </summary>
        /// <value>Permohonan Status Disetujui Kepala Seksi.</value>
        public static PermohonanStatus DisetujuiKepalaSeksi => new PermohonanStatus
        {
            Id = 5,
            Name = "Diteruskan oleh Kepala Seksi",
            PemohonDisplayedName = "Dalam Proses"
        };

        /// <summary>
        /// Permohonan Status Dikembalikan Kepala Seksi.
        /// </summary>
        /// <value>Permohonan Status Dikembalikan Kepala Seksi.</value>
        public static PermohonanStatus DikembalikanKepalaSeksi => new PermohonanStatus
        {
            Id = 6,
            Name = "Dikembalikan oleh Kepala Seksi",
            PemohonDisplayedName = "Dalam Proses"
        };

        /// <summary>
        /// Permohonan Status Disetujui Kepala Sub Direktorat.
        /// </summary>
        /// <value>Permohonan Status Disetujui Kepala Sub Direktorat.</value>
        public static PermohonanStatus DisetujuiKepalaSubDirektorat => new PermohonanStatus
        {
            Id = 7,
            Name = "Diteruskan oleh Kepala Sub Direktorat",
            PemohonDisplayedName = "Dalam Proses"
        };

        /// <summary>
        /// Permohonan Status Dikembalikan Kepala Sub Direktorat.
        /// </summary>
        /// <value>Permohonan Status Dikembalikan Kepala Sub Direktorat.</value>
        public static PermohonanStatus DikembalikanKepalaSubDirektorat => new PermohonanStatus
        {
            Id = 8,
            Name = "Dikembalikan oleh Kepala Sub Direktorat",
            PemohonDisplayedName = "Dalam Proses"
        };

        /// <summary>
        /// Permohonan Status Disetujui Direktur Pelayanan Farmasi.
        /// </summary>
        /// <value>Permohonan Status Disetujui Direktur Pelayanan Farmasi.</value>
        public static PermohonanStatus DisetujuiDirekturPelayananFarmasi => new PermohonanStatus
        {
            Id = 9,
            Name = "Diteruskan oleh Direktur Pelayanan Farmasi",
            PemohonDisplayedName = "Dalam Proses"
        };

        /// <summary>
        /// Permohonan Status Dikembalikan Direktur Pelayanan Farmasi.
        /// </summary>
        /// <value>Permohonan Status Dikembalikan Direktur Pelayanan Farmasi.</value>
        public static PermohonanStatus DikembalikanDirekturPelayananFarmasi => new PermohonanStatus
        {
            Id = 10,
            Name = "Dikembalikan oleh Direktur Pelayanan Farmasi",
            PemohonDisplayedName = "Dalam Proses"
        };

        /// <summary>
        /// Permohonan Status Disetujui Direktur Jenderal.
        /// </summary>
        /// <value>Permohonan Status Disetujui Direktur Jenderal.</value>
        public static PermohonanStatus DisetujuiDirekturJenderal => new PermohonanStatus
        {
            Id = 11,
            Name = "Disetujui oleh Direktur Jenderal",
            PemohonDisplayedName = "Dalam Proses"
        };

        /// <summary>
        /// Permohonan Status Dikembalikan Direktur Jenderal.
        /// </summary>
        /// <value>Permohonan Status Dikembalikan Direktur Jenderal.</value>
        public static PermohonanStatus DikembalikanDirekturJenderal => new PermohonanStatus
        {
            Id = 12,
            Name = "Dikembalikan oleh Direktur Jenderal",
            PemohonDisplayedName = "Dalam Proses"
        };

        /// <summary>
        /// Permohonan Status Selesai.
        /// </summary>
        /// <value>Permohonan Status Selesai.</value>
        public static PermohonanStatus Selesai => new PermohonanStatus
        {
            Id = 13,
            Name = "Selesai",
            PemohonDisplayedName = "Selesai"
        };

        /// <summary>
        /// Permohonan Status Ditolak.
        /// </summary>
        /// <value>Permohonan Status Ditolak.</value>
        public static PermohonanStatus Ditolak => new PermohonanStatus
        {
            Id = 14,
            Name = "Ditolak",
            PemohonDisplayedName = "Ditolak"
        };

        /// <summary>
        /// Permohonan Status Ditolak.
        /// </summary>
        /// <value>Permohonan Status Ditolak.</value>
        public static PermohonanStatus PerubahanIzin => new PermohonanStatus
        {
            Id = 15,
            Name = "PerubahanIzin",
            PemohonDisplayedName = "PerubahanIzin"
        };

        /// <summary>
        /// Gets list of predefined Permohonan Status.
        /// </summary>
        /// <value></value>
        public static List<PermohonanStatus> List => new List<PermohonanStatus>
        {
            Dibuat,
            Diajukan,
            DisetujuiVerifikator,
            DikembalikanVerifikator,
            DisetujuiKepalaSeksi,
            DikembalikanKepalaSeksi,
            DisetujuiKepalaSubDirektorat,
            DikembalikanKepalaSubDirektorat,
            DisetujuiDirekturPelayananFarmasi,
            DikembalikanDirekturPelayananFarmasi,
            DisetujuiDirekturJenderal,
            DikembalikanDirekturJenderal,
            Selesai,
            Ditolak,
            PerubahanIzin
        };
    }
}