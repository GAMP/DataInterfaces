using ProtoBuf;
using SharedLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// User member entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class UserMember : ModifiableByUserBase
    {
        #region UserMember

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        [DataMember()]
        [Required()]
        [StringLength(30)]
        [ProtoMember(1)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets email.
        /// </summary>
        [DataMember()]
        [StringLength(254)]
        [ProtoMember(2)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets users group id.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int UserGroupId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if user allowed to have negative balance.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public bool? IsNegativeBalanceAllowed
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if personal info is requested.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public bool IsPersonalInfoRequested
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets billing options.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public BillingOption? BillingOptions
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets user re-enable date-time.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public DateTime? EnableDate
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets disabled date-time.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public DateTime? DisabledDate
        {
            get; set;
        }

        #endregion

        #region User

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        [DataMember()]
        [StringLength(45)]
        [ProtoMember(9)]
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets last name.
        /// </summary>
        [DataMember()]
        [StringLength(45)]
        [ProtoMember(10)]
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets birth date.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public DateTime? BirthDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets address.
        /// </summary>
        [DataMember()]
        [StringLength(255)]
        [ProtoMember(12)]
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets city.
        /// </summary>
        [DataMember()]
        [StringLength(45)]
        [ProtoMember(13)]
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets country.
        /// </summary>
        [DataMember()]
        [StringLength(45)]
        [ProtoMember(14)]
        public string Country
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets post code.
        /// </summary>
        [DataMember()]
        [StringLength(20)]
        [ProtoMember(15)]
        public string PostCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        [DataMember()]
        [StringLength(20)]
        [ProtoMember(16)]
        public string Phone
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets mobile phone number.
        /// </summary>
        [DataMember()]
        [StringLength(20)]
        [ProtoMember(17)]
        public string MobilePhone
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets sex.
        /// </summary>
        [DataMember()]
        [ProtoMember(18)]
        public Sex Sex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if user is deleted.
        /// </summary>
        [DataMember()]
        [ProtoMember(19)]
        public bool IsDeleted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if user is enabled.
        /// </summary>
        [DataMember()]
        [ProtoMember(20)]
        public bool IsDisabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets item guid.
        /// </summary>
        [Required()]
        [DataMember()]
        [ProtoMember(21)]
        public Guid Guid
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets SmartCard UID.
        /// </summary>
        [DataMember()]
        [StringLength(255)]
        [ProtoMember(22)]
        public string SmartCardUID
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets identification number.
        /// </summary>
        [DataMember()]
        [StringLength(255)]
        [ProtoMember(23)]
        public string Identification
        {
            get; set;
        }
        
        #endregion
        
    }
}