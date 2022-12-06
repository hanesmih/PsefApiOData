using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Permohonan Billing.
    /// </summary>
    public class MasterBank
    {
        /// <summary>
        /// Gets or sets the Id Nama Bank.
        /// </summary>
        /// <value>The Id Nama Bank.</value>
        [Key]
        public string BankPersepsiId { get; set; }

        /// <summary>
        /// Gets or sets the Nama Bank.
        /// </summary>
        /// <value>The Nama Bank</value>
        public string BankPersepsi { get; set; }
    }
}

