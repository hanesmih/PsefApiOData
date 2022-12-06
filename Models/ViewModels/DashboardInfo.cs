using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Dashboard Information.
    /// </summary>
    public class DashboardInfo
    {
        /// <summary>
        /// Gets or sets the Dashboard Information total pemohon.
        /// </summary>
        /// <value>The Dashboard Information's total pemohon.</value>
        public long TotalPemohon { get; set; }

        /// <summary>
        /// Gets or sets the Dashboard Information total permohonan pending.
        /// </summary>
        /// <value>The Dashboard Information's total permohonan pending.</value>
        public long TotalPermohonanPending { get; set; }

        /// <summary>
        /// Gets or sets the Dashboard Information total permohonan.
        /// </summary>
        /// <value>The Dashboard Information's total permohonan.</value>
        public long TotalPermohonan { get; set; }

        /// <summary>
        /// Gets or sets the Dashboard Information total permohonan dalam proses.
        /// </summary>
        /// <value>The Dashboard Information's total permohonan dalam proses.</value>
        public long TotalPermohonanDalamProses { get; set; }

        /// <summary>
        /// Gets or sets the Dashboard Information total permohonan ditolak.
        /// </summary>
        /// <value>The Dashboard Information's total permohonan ditolak.</value>
        public long TotalPermohonanDitolak { get; set; }

        /// <summary>
        /// Gets or sets the Dashboard Information total perizinan.
        /// </summary>
        /// <value>The Dashboard Information's total perizinan.</value>
        public long TotalPerizinan { get; set; }

        /// <summary>
        /// Gets or sets the Dashboard Information aktifitas.
        /// </summary>
        /// <value>The Dashboard Information's aktifitas.</value>
        public List<Aktifitas> Aktifitas { get; set; }
    }
}