using System;
using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Perizinan Perubahan Tanggal.
    /// </summary>
    public class PerizinanTanggalPerubahan
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Perizinan.
        /// </summary>
        /// <value>The Perizinan's unique identifier.</value>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the Tanggal Perubahan Izin.
        /// </summary>
        /// <value>The Perizinan's Tanggal Perubahan Izin.</value>
        public DateTime TanggalPerubahanIzin { get; set; }

    }
}

