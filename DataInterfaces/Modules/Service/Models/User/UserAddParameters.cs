using ProtoBuf;
using SharedLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User add parameters.
    /// </summary>
    [ProtoContract()]
    [DataContract()]
    public class UserAddParameters
    {
        #region PROPERTIES

        /// <summary>
        /// Username.
        /// The username must be unique otherwise non unique api error will occur.
        /// </summary>
        [Required()]
        [DataMember(Order = 0)]
        [StringLength(254)]
        [ProtoMember(1)]
        public virtual string Username
        {
            get; set;
        }

        /// <summary>
        /// User group id.
        /// </summary>
        [Required()]
        [DataMember(Order = 1)]
        [ProtoMember(2)]
        public virtual int UserGroupId
        {
            get;
            set;
        }

        /// <summary>
        /// Email address.
        /// </summary>
        [DataMember()]
        [StringLength(254)]
        [ProtoMember(3)]
        public virtual string Email { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        [DataMember()]
        [StringLength(45)]
        [ProtoMember(4)]
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Last name.
        /// </summary>
        [DataMember()]
        [StringLength(45)]
        [ProtoMember(5)]
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Birth date.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public DateTime? BirthDate
        {
            get;
            set;
        }

        /// <summary>
        /// Address.
        /// </summary>
        [DataMember()]
        [StringLength(255)]
        [ProtoMember(7)]
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// City.
        /// </summary>
        [DataMember()]
        [StringLength(45)]
        [ProtoMember(8)]
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// Country.
        /// </summary>
        [DataMember()]
        [StringLength(45)]
        [ProtoMember(9)]
        public string Country
        {
            get;
            set;
        }

        /// <summary>
        /// Post code.
        /// </summary>
        [DataMember()]
        [StringLength(20)]
        [ProtoMember(10)]
        public string PostCode
        {
            get;
            set;
        }

        /// <summary>
        /// Phone number.
        /// </summary>
        [DataMember()]
        [StringLength(20)]
        [ProtoMember(11)]
        public string Phone
        {
            get;
            set;
        }

        /// <summary>
        /// Mobile phone number.
        /// </summary>
        [DataMember()]
        [StringLength(20)]
        [ProtoMember(12)]
        public string MobilePhone
        {
            get;
            set;
        }

        /// <summary>
        /// Sex.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public Sex Sex
        {
            get;
            set;
        }

        /// <summary>
        /// Identification number.
        /// </summary>
        [DataMember()]
        [StringLength(255)]
        [ProtoMember(14)]
        public string Identification
        {
            get; set;
        }

        #endregion
    }
}
