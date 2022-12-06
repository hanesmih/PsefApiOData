using System.Runtime.Serialization;

namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a Pemohon with User information.
    /// </summary>
    public class PemohonUserInfo
    {
        /// <summary>
        /// Gets or sets the Pemohon.
        /// </summary>
        /// <value>The Pemohon.</value>
        [IgnoreDataMember]
        public Pemohon Pemohon { get; set; }

        /// <summary>
        /// Gets or sets the User.
        /// </summary>
        /// <value>The User.</value>
        [IgnoreDataMember]
        public UserInfo UserInfo { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the Pemohon.
        /// </summary>
        /// <value>The Pemohon's unique identifier.</value>
        public uint Id
        {
            get => Pemohon.Id;
            set => Pemohon.Id = value;
        }

        /// <summary>
        /// Gets or sets the associated user identifier.
        /// </summary>
        /// <value>The associated user identifier.</value>
        public string UserId
        {
            get => Pemohon.UserId;
            set => Pemohon.UserId = value;
        }

        /// <summary>
        /// Gets or sets the Pemohon phone number.
        /// </summary>
        /// <value>The Pemohon's phone number.</value>
        public string Phone
        {
            get => Pemohon.Phone;
            set => Pemohon.Phone = value;
        }

        /// <summary>
        /// Gets or sets the Pemohon address.
        /// </summary>
        /// <value>The Pemohon's address.</value>
        public string Address
        {
            get => Pemohon.Address;
            set => Pemohon.Address = value;
        }

        /// <summary>
        /// Gets or sets the Pemohon NIB.
        /// </summary>
        /// <value>The Pemohon's NIB.</value>
        public string Nib
        {
            get => Pemohon.Nib;
            set => Pemohon.Nib = value;
        }

        /// <summary>
        /// (Read Only) Gets the Pemohon company name.
        /// </summary>
        /// <value>The Pemohon's company name.</value>
        public string CompanyName
        {
            get => Pemohon.CompanyName;
            set
            {
            }
        }

        /// <summary>
        /// (Read Only) Gets the Pemohon penanggung jawab.
        /// </summary>
        /// <value>The Pemohon's penanggung jawab.</value>
        public string PenanggungJawab
        {
            get => Pemohon.PenanggungJawab;
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the Pemohon name.
        /// </summary>
        /// <value>The Pemohon's name.</value>
        public string Name
        {
            get => UserInfo.Name;
            set => UserInfo.Name = value;
        }

        /// <summary>
        /// Gets or sets the Pemohon email.
        /// </summary>
        /// <value>The Pemohon's email.</value>
        public string Email
        {
            get => UserInfo.Email;
            set => UserInfo.Email = value;
        }
    }
}