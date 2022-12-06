namespace PsefApiOData.Misc
{
    /// <summary>
    /// OSS API configuration options.
    /// </summary>
    public class KemenkeuApiOptions
    {
        /// <summary>
        /// Configuration options name.
        /// </summary>
        public const string OptionsName = "KemenkeuApi";

        /// <summary>
        /// Gets or sets the Kemenkeu base uri dev.
        /// </summary>
        /// <value>The Kemenkeu base uri.</value>
        public string UrlDev { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu base uri prod.
        /// </summary>
        /// <value>The Kemenkeu base uri.</value>
        public string UrlProd { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu user id.
        /// </summary>
        /// <value>The Kemenkeu user id.</value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu username.
        /// </summary>
        /// <value>The Kemenkeu username.</value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu password.
        /// </summary>
        /// <value>The Kemenkeu password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu Expired Payment Days.
        /// </summary>
        /// <value>The Kemenkeu cache time in hour.</value>
        public int ExpiredDay { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu staging flag.
        /// </summary>
        /// <value>The Kemenkeu staging flag.</value>
        public bool IsStaging { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu kodeKL.
        /// </summary>
        /// <value>The Kemenkeu kodeKL.</value>
        public string KodeKL { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu KodeEselon1.
        /// </summary>
        /// <value>The Kemenkeu KodeEselon1.</value>
        public string KodeEselon1 { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu KodeSatker.
        /// </summary>
        /// <value>The Kemenkeu KodeSatker.</value>
        public string KodeSatker { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu JenisPnbp.
        /// </summary>
        /// <value>The Kemenkeu JenisPnbp.</value>
        public string JenisPnbp { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu KodeMataUang.
        /// </summary>
        /// <value>The Kemenkeu KodeMataUang.</value>
        public string KodeMataUang { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu TotalNominalBilling.
        /// </summary>
        /// <value>The Kemenkeu TotalNominalBilling.</value>
        public int TotalNominalBilling { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu KodeSatkerPemungut.
        /// </summary>
        /// <value>The Kemenkeu KodeSatkerPemungut.</value>
        public string KodeSatkerPemungut { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu KodeTarifSimponi.
        /// </summary>
        /// <value>The Kemenkeu KodeTarifSimponi.</value>
        public string KodeTarifSimponi { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu KodePpSimponi.
        /// </summary>
        /// <value>The Kemenkeu KodePpSimponi.</value>
        public string KodePpSimponi { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu KodeAkun.
        /// </summary>
        /// <value>The Kemenkeu KodeAkun.</value>
        public string KodeAkun { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu NominalTarifPnbp.
        /// </summary>
        /// <value>The Kemenkeu NominalTarifPnbp.</value>
        public int NominalTarifPnbp { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu Volume.
        /// </summary>
        /// <value>The Kemenkeu Volume.</value>
        public int Volume { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu Satuan.
        /// </summary>
        /// <value>The Kemenkeu Satuan.</value>
        public string Satuan { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu KodeLokasiSatker.
        /// </summary>
        /// <value>The Kemenkeu KodeLokasiSatker.</value>
        public string KodeLokasiSatker { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu KodeKabkotaSatker.
        /// </summary>
        /// <value>The Kemenkeu KodeKabkotaSatker.</value>
        public string KodeKabkotaSatker { get; set; }

        /// <summary>
        /// Gets or sets the Kemenkeu Npwp.
        /// </summary>
        /// <value>The Kemenkeu Npwp.</value>
        public string Npwp { get; set; }
    }
}