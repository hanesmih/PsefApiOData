using System;
using System.Collections.Generic;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a OSS Checklist Information.
    /// </summary>
    public class OssChecklist
    {
        /// <summary>
        /// Gets or sets the IdProduk.
        /// </summary>
        /// <value>The IdProduk.</value>
        public string IdProduk { get; set; }

        /// <summary>
        /// Gets or sets the IdProyek.
        /// </summary>
        /// <value>The IdProyek.</value>
        public string IdProyek { get; set; }

        /// <summary>
        /// Gets or sets the IdIzin.
        /// </summary>
        /// <value>The IdIzin.</value>
        public string IdIzin { get; set; }

        /// <summary>
        /// Gets or sets the JenisIzin.
        /// </summary>
        /// <value>The JenisIzin.</value>
        public string JenisIzin { get; set; }

        /// <summary>
        /// Gets or sets the KdIzin.
        /// </summary>
        /// <value>The KdIzin.</value>
        public string KdIzin { get; set; }

        /// <summary>
        /// Gets or sets the KdDaerah.
        /// </summary>
        /// <value>The KdDaerah.</value>
        public string KdDaerah { get; set; }

        /// <summary>
        /// Gets or sets the NamaIzin.
        /// </summary>
        /// <value>The NamaIzin.</value>
        public string NamaIzin { get; set; }

        /// <summary>
        /// Gets or sets the NoIzin.
        /// </summary>
        /// <value>The NoIzin.</value>
        public string NoIzin { get; set; }

        /// <summary>
        /// Gets or sets the TglIzin.
        /// </summary>
        /// <value>The TglIzin.</value>
        public DateTime? TglIzin { get; set; }

        /// <summary>
        /// Gets or sets the Instansi.
        /// </summary>
        /// <value>The Instansi.</value>
        public string Instansi { get; set; }

        /// <summary>
        /// Gets or sets the IdBidangSpesifik.
        /// </summary>
        /// <value>The IdBidangSpesifik.</value>
        public string IdBidangSpesifik { get; set; }

        /// <summary>
        /// Gets or sets the BidangSpesifik.
        /// </summary>
        /// <value>The BidangSpesifik.</value>
        public string BidangSpesifik { get; set; }

        /// <summary>
        /// Gets or sets the IdKewenangan.
        /// </summary>
        /// <value>The IdKewenangan.</value>
        public int IdKewenangan { get; set; }

        /// <summary>
        /// Gets or sets the ParameterKewenangan.
        /// </summary>
        /// <value>The ParameterKewenangan.</value>
        public string ParameterKewenangan { get; set; }

        /// <summary>
        /// Gets or sets the Kewenangan.
        /// </summary>
        /// <value>The Kewenangan.</value>
        public string Kewenangan { get; set; }

        /// <summary>
        /// Gets or sets the FileIzin.
        /// </summary>
        /// <value>The FileIzin.</value>
        public string FileIzin { get; set; }

        /// <summary>
        /// Gets or sets the FileIzinOss.
        /// </summary>
        /// <value>The FileIzinOss.</value>
        public string FileIzinOss { get; set; }

        /// <summary>
        /// Gets or sets the FlagChecklist.
        /// </summary>
        /// <value>The FlagChecklist.</value>
        public string FlagChecklist { get; set; }

        /// <summary>
        /// Gets or sets the StatusChecklist.
        /// </summary>
        /// <value>The StatusChecklist.</value>
        public string StatusChecklist { get; set; }

        /// <summary>
        /// Gets or sets the FlagTransaksional.
        /// </summary>
        /// <value>The FlagTransaksional.</value>
        public string FlagTransaksional { get; set; }

        /// <summary>
        /// Gets or sets the FlagPerpanjangan.
        /// </summary>
        /// <value>The FlagPerpanjangan.</value>
        public string FlagPerpanjangan { get; set; }

        /// <summary>
        /// Gets or sets the KdDokumen.
        /// </summary>
        /// <value>The KdDokumen.</value>
        public string KdDokumen { get; set; }

        /// <summary>
        /// Gets or sets the NmDokumen.
        /// </summary>
        /// <value>The NmDokumen.</value>
        public string NmDokumen { get; set; }

        /// <summary>
        /// Gets or sets the list of DataPersyaratan.
        /// </summary>
        /// <value>The list of DataPersyaratan.</value>
        public List<OssChecklistPersyaratan> DataPersyaratan { get; set; }
    }
}