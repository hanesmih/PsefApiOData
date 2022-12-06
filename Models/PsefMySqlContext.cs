using IdentityModel;
using Microsoft.EntityFrameworkCore;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Database context
    /// </summary>
    public partial class PsefMySqlContext : DbContext
    {
        /// <summary>
        /// Database context
        /// </summary>
        /// <param name="options">Database context options</param>
        public PsefMySqlContext(DbContextOptions<PsefMySqlContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Apotek table
        /// </summary>
        /// <value>Apotek</value>
        public virtual DbSet<Apotek> Apotek { get; set; }

        /// <summary>
        /// Counter table
        /// </summary>
        /// <value>Counter</value>
        public virtual DbSet<Counter> Counter { get; set; }

        /// <summary>
        /// Desa/Kelurahan table
        /// </summary>
        /// <value>Desa/Kelurahan</value>
        public virtual DbSet<DesaKelurahan> DesaKelurahan { get; set; }

        /// <summary>
        /// History Permohonan table
        /// </summary>
        /// <value>History Permohonan</value>
        public virtual DbSet<HistoryPermohonan> HistoryPermohonan { get; set; }

        /// <summary>
        /// Homepage Banner table
        /// </summary>
        /// <value>Homepage Banner</value>
        public virtual DbSet<HomepageBanner> HomepageBanner { get; set; }

        /// <summary>
        /// Homepage News table
        /// </summary>
        /// <value>Homepage News</value>
        public virtual DbSet<HomepageNews> HomepageNews { get; set; }

        /// <summary>
        /// Homepage Unduhan table
        /// </summary>
        /// <value>Homepage Unduhan</value>
        public virtual DbSet<HomepageUnduhan> HomepageUnduhan { get; set; }

        /// <summary>
        /// Kabupaten/Kota table
        /// </summary>
        /// <value>Kabupaten/Kota</value>
        public virtual DbSet<KabupatenKota> KabupatenKota { get; set; }

        /// <summary>
        /// Kecamatan table
        /// </summary>
        /// <value>Kecamatan</value>
        public virtual DbSet<Kecamatan> Kecamatan { get; set; }

        /// <summary>
        /// Klinik table
        /// </summary>
        /// <value>Klinik</value>
        public virtual DbSet<Klinik> Klinik { get; set; }

        /// <summary>
        /// Pemohon table
        /// </summary>
        /// <value>Pemohon</value>
        public virtual DbSet<Pemohon> Pemohon { get; set; }

        /// <summary>
        /// Perizinan table
        /// </summary>
        /// <value>Perizinan</value>
        public virtual DbSet<Perizinan> Perizinan { get; set; }

        /// <summary>
        /// Permohonan table
        /// </summary>
        /// <value>Permohonan</value>
        public virtual DbSet<Permohonan> Permohonan { get; set; }

        /// <summary>
        /// Provinsi table
        /// </summary>
        /// <value>Provinsi</value>
        public virtual DbSet<Provinsi> Provinsi { get; set; }

        /// <summary>
        /// Rumah Sakit table
        /// </summary>
        /// <value>Rumah Sakit</value>
        public virtual DbSet<RumahSakit> RumahSakit { get; set; }

        /// <summary>
        /// Verifikasi Permohonan table
        /// </summary>
        /// <value>Verifikasi Permohonan</value>
        public virtual DbSet<VerifikasiPermohonan> VerifikasiPermohonan { get; set; }

        /// <summary>
        /// Verifikasi Permohonan table
        /// </summary>
        /// <value>Verifikasi Permohonan</value>
        public virtual DbSet<Laporan> Laporan { get; set; }

        /// <summary>
        /// API Pemohon table
        /// </summary>
        /// <value>Pemohon API</value>
        public virtual DbSet<PemohonApi> PemohonApi { get; set; }

        /// <summary>
        /// Permohonan Billing table
        /// </summary>
        /// <value>Pemohon API</value>
        public virtual DbSet<PermohonanBilling> PermohonanBilling { get; set; }

        /// <summary>
        /// Permohonan Billing table
        /// </summary>
        /// <value>Pemohon API</value>
        public virtual DbSet<MasterBank> MasterBank { get; set; }

        /// <summary>
        /// Perubahan Izin table
        /// </summary>
        /// <value>Perubahan Izin</value>
        public virtual DbSet<PerubahanIzin> PerubahanIzin { get; set; }

        /// <summary>
        /// Perubahan Izin table
        /// </summary>
        /// <value>Perubahan Izin</value>
        public virtual DbSet<HistoryPerubahanIzin> HistoryPerubahanIzin { get; set; }

        /// <summary>
        /// Configure model
        /// </summary>
        /// <param name="modelBuilder">Model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apotek>(entity =>
            {
                entity.ToTable("apotek");

                entity.HasIndex(e => e.PermohonanId)
                    .HasName("FK_apotek_permohonan");

                entity.HasIndex(e => e.ProvinsiId)
                    .HasName("FK_apotek_provinsi");

                entity.Property(e => e.Id).HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApotekerName)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermohonanId)
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.ProvinsiId)
                    .HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.SiaNumber)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SipaNumber)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StraNumber)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Permohonan)
                    .WithMany(p => p.Apotek)
                    .HasForeignKey(d => d.PermohonanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_apotek_permohonan");

                entity.HasOne(d => d.Provinsi)
                    .WithMany(p => p.Apotek)
                    .HasForeignKey(d => d.ProvinsiId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_apotek_provinsi");
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.ToTable("counter");

                entity.Property(e => e.Id).HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.DateFormat)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DisplayFormat)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastValueDate)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci")
                    .IsConcurrencyToken();

                entity.Property(e => e.LastValueNumber)
                    .HasColumnType("int(11)")
                    .IsConcurrencyToken();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<DesaKelurahan>(entity =>
            {
                entity.ToTable("desakelurahan");

                entity.HasIndex(e => e.KecamatanId)
                    .HasName("FK_desakelurahan_kecamatan");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.KecamatanId)
                    .HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Kecamatan)
                    .WithMany(p => p.DesaKelurahan)
                    .HasForeignKey(d => d.KecamatanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_desakelurahan_kecamatan");
            });

            modelBuilder.Entity<HistoryPermohonan>(entity =>
            {
                entity.ToTable("historypermohonan");

                entity.HasIndex(e => e.PermohonanId)
                    .HasName("FK_historypermohonan_permohonan");

                entity.Property(e => e.Id).HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.PermohonanId)
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StatusId)
                    .HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Permohonan)
                    .WithMany(p => p.HistoryPermohonan)
                    .HasForeignKey(d => d.PermohonanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_historypermohonan_permohonan");
            });

            modelBuilder.Entity<HomepageBanner>(entity =>
            {
                entity.ToTable("homepagebanner");

                entity.Property(e => e.Id).HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<HomepageNews>(entity =>
            {
                entity.ToTable("homepagenews");

                entity.Property(e => e.Id).HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LinkUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PublishedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<HomepageUnduhan>(entity =>
            {
                entity.ToTable("homepageunduhan");

                entity.Property(e => e.Id).HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<KabupatenKota>(entity =>
            {
                entity.ToTable("kabupatenkota");

                entity.HasIndex(e => e.ProvinsiId)
                    .HasName("FK_kabupatenkota_provinsi");

                entity.Property(e => e.Id).HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvinsiId)
                    .HasColumnType("tinyint(3) unsigned");

                entity.HasOne(d => d.Provinsi)
                    .WithMany(p => p.KabupatenKota)
                    .HasForeignKey(d => d.ProvinsiId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_kabupatenkota_provinsi");
            });

            modelBuilder.Entity<Kecamatan>(entity =>
            {
                entity.ToTable("kecamatan");

                entity.HasIndex(e => e.KabupatenKotaId)
                    .HasName("FK_kecamatan_kabupatenkota");

                entity.Property(e => e.Id).HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.KabupatenKotaId)
                    .HasColumnType("smallint(5) unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.KabupatenKota)
                    .WithMany(p => p.Kecamatan)
                    .HasForeignKey(d => d.KabupatenKotaId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_kecamatan_kabupatenkota");
            });

            modelBuilder.Entity<Klinik>(entity =>
            {
                entity.ToTable("klinik");

                entity.HasIndex(e => e.PermohonanId)
                    .HasName("FK_klinik_permohonan");

                entity.HasIndex(e => e.ProvinsiId)
                    .HasName("FK_klinik_provinsi");

                entity.Property(e => e.Id).HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApotekerName)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermohonanId).HasColumnType("int(11) unsigned");

                entity.Property(e => e.ProvinsiId).HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.SiaNumber)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SipaNumber)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StraNumber)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Permohonan)
                    .WithMany(p => p.Klinik)
                    .HasForeignKey(d => d.PermohonanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_klinik_permohonan");

                entity.HasOne(d => d.Provinsi)
                    .WithMany(p => p.Klinik)
                    .HasForeignKey(d => d.ProvinsiId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_klinik_provinsi");
            });

            modelBuilder.Entity<Pemohon>(entity =>
            {
                entity.ToTable("pemohon");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nib)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PenanggungJawab)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Perizinan>(entity =>
            {
                entity.ToTable("perizinan");

                entity.HasIndex(e => e.PermohonanId)
                    .HasName("FK_perizinan_permohonan");

                entity.HasIndex(e => e.PreviousId)
                    .HasName("FK_perizinan_perizinan");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.ExpiredAt).HasColumnType("date");

                entity.Property(e => e.IssuedAt).HasColumnType("date");

                entity.Property(e => e.OssIzinUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PerizinanNumber)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermohonanId)
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.PreviousId)
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.TandaDaftarUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Permohonan)
                    .WithMany(p => p.Perizinan)
                    .HasForeignKey(d => d.PermohonanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_perizinan_permohonan");

                entity.HasOne(d => d.Previous)
                    .WithMany(p => p.InversePrevious)
                    .HasForeignKey(d => d.PreviousId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_perizinan_perizinan");
            });

            modelBuilder.Entity<Permohonan>(entity =>
            {
                entity.ToTable("permohonan");

                entity.HasIndex(e => e.PemohonId)
                    .HasName("FK_permohonan_pemohon");

                entity.HasIndex(e => e.PerizinanId)
                    .HasName("FK_permohonan_perizinan");

                entity.HasIndex(e => e.PreviousPerizinanId)
                    .HasName("FK_permohonan_perizinan_previous");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.ApotekerEmail)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApotekerName)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApotekerNik)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApotekerPhone)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DokumenApiUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DokumenPseUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdIzin)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdProyek)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImbUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IzinLokasiUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IzinUsahaUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.KomitmenKerjasamaApotekUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.PembayaranPnbpUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PemohonId)
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.PerizinanId)
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.PermohonanNumber)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PernyataanKeaslianDokumenUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PreviousPerizinanId)
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ProsesBisnisUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProviderName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SpplUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StatusId).HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.StraExpiry)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'0000-00-00'");

                entity.Property(e => e.StraNumber)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StraUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SubmittedAt)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'0000-00-00'");

                entity.Property(e => e.SuratPermohonanUrl)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SystemName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TenagaAhliName)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeId).HasColumnType("tinyint(3) unsigned");

                entity.HasOne(d => d.Pemohon)
                    .WithMany(p => p.Permohonan)
                    .HasForeignKey(d => d.PemohonId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_permohonan_pemohon");

                entity.HasOne(d => d.PerizinanNavigation)
                    .WithMany(p => p.PermohonanPerizinanNavigation)
                    .HasForeignKey(d => d.PerizinanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_permohonan_perizinan");

                entity.HasOne(d => d.PreviousPerizinan)
                    .WithMany(p => p.PermohonanPreviousPerizinan)
                    .HasForeignKey(d => d.PreviousPerizinanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_permohonan_perizinan_previous");
            });

            modelBuilder.Entity<Provinsi>(entity =>
            {
                entity.ToTable("provinsi");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(3) unsigned")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<RumahSakit>(entity =>
            {
                entity.ToTable("rumahsakit");

                entity.HasIndex(e => e.PermohonanId)
                    .HasName("FK_rumahsakit_permohonan");

                entity.HasIndex(e => e.ProvinsiId)
                    .HasName("FK_rumahsakit_provinsi");

                entity.Property(e => e.Id).HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApotekerName)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermohonanId).HasColumnType("int(11) unsigned");

                entity.Property(e => e.ProvinsiId).HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.SiaNumber)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SipaNumber)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StraNumber)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Permohonan)
                    .WithMany(p => p.RumahSakit)
                    .HasForeignKey(d => d.PermohonanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_rumahsakit_permohonan");

                entity.HasOne(d => d.Provinsi)
                    .WithMany(p => p.RumahSakit)
                    .HasForeignKey(d => d.ProvinsiId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_rumahsakit_provinsi");
            });

            modelBuilder.Entity<VerifikasiPermohonan>(entity =>
            {
                entity.ToTable("verifikasi_permohonan");

                entity.HasIndex(e => e.PermohonanId)
                    .HasName("FK_verifikasi_permohonan_permohonan");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.ApotekerEmailCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.ApotekerEmailCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApotekerNameCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.ApotekerNameCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApotekerNikCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.ApotekerNikCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApotekerPhoneCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.ApotekerPhoneCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DokumenApiUrlCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.DokumenApiUrlCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DokumenPseUrlCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.DokumenPseUrlCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DomainCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.DomainCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImbUrlCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.ImbUrlCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IzinLokasiUrlCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.IzinLokasiUrlCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IzinUsahaUrlCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.IzinUsahaUrlCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.KomitmenKerjasamaApotekUrlCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.KomitmenKerjasamaApotekUrlCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PembayaranPnbpUrlCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.PembayaranPnbpUrlCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermohonanId).HasColumnType("int(11) unsigned");

                entity.Property(e => e.PernyataanKeaslianDokumenUrlCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.PernyataanKeaslianDokumenUrlCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProsesBisnisUrlCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.ProsesBisnisUrlCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProviderNameCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.ProviderNameCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SpplUrlCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.SpplUrlCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StraExpiryCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.StraExpiryCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StraNumberCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.StraNumberCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StraUrlCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.StraUrlCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SuratPermohonanUrlCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.SuratPermohonanUrlCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SystemNameCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.SystemNameCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TenagaAhliNameCheck).HasColumnType("tinyint(4)");

                entity.Property(e => e.TenagaAhliNameCheckReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Permohonan)
                    .WithMany(p => p.VerifikasiPermohonan)
                    .HasForeignKey(d => d.PermohonanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_verifikasi_permohonan_permohonan");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
