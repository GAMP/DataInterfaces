using ProtoBuf;
using SharedLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User base model.
    /// Contains all shared user properties that is being used when listing base user.
    /// </summary>
    [ProtoContract()]
    [ProtoInclude(500, typeof(UserMemberModel))]
    [Serializable()]
    [DataContract()]
    public abstract class UserBaseModel
    {
        #region PROPERTIES

        /// <summary>
        /// User id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int UserId
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        [DataMember()]
        [StringLength(45)]
        [ProtoMember(2)]
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
        [ProtoMember(3)]
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets birth date.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
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
        [ProtoMember(5)]
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
        [ProtoMember(6)]
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
        [ProtoMember(7)]
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
        [ProtoMember(8)]
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
        [ProtoMember(9)]
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
        [ProtoMember(10)]
        public string MobilePhone
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets sex.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public Sex Sex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets identification number.
        /// </summary>
        [DataMember()]
        [StringLength(255)]
        [ProtoMember(16)]
        public string Identification
        {
            get; set;
        }

        #endregion
    }

    /// <summary>
    /// User member model.
    /// </summary>
    [ProtoContract()]
    [Serializable()]
    [DataContract()]
    public class UserMemberModel : UserBaseModel
    {
        #region PROPERTIES

        /// <summary>
        /// Username.
        /// </summary>
        [Required()]
        [DataMember()]
        [StringLength(254)]
        [ProtoMember(1)]
        public virtual string Username
        {
            get; set;
        }

        /// <summary>
        /// User member email.
        /// </summary>
        [DataMember()]
        [StringLength(254)]
        [ProtoMember(2)]
        public virtual string Email { get; set; }

        /// <summary>
        /// User group id.
        /// </summary>
        [Required()]
        [DataMember()]
        [ProtoMember(3)]
        public virtual int UserGroupId
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates if user allowed to have negative balance.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public virtual bool? IsNegativeBalanceAllowed
        {
            get; set;
        }

        /// <summary>
        /// Indicates if user personal info is requested.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public virtual bool IsPersonalInfoRequested
        {
            get; set;
        }

        /// <summary>
        /// User billing options.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public virtual BillingOption? BillingOptions
        {
            get; set;
        }

        /// <summary>
        /// User re-enable date-time.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public virtual DateTime? EnableDate
        {
            get; set;
        }

        /// <summary>
        ///  User disabled date-time.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public virtual DateTime? DisabledDate
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets item guid.
        /// </summary>
        [Required()]
        [DataMember()]
        [ProtoMember(14)]
        public virtual Guid Guid
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets SmartCard UID.
        /// </summary>
        [DataMember()]
        [StringLength(255)]
        [ProtoMember(15)]
        public string SmartCardUID
        {
            get; set;
        }

        #endregion
    }
}
