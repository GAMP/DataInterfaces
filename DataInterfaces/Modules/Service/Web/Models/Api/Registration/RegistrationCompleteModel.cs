using SharedLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Registration completion.
    /// Used to complete registration process.
    /// </summary>
    [DataContract()]
    public class RegistrationCompleteModel
    {
        #region PROPERTIES

        /// <summary>
        /// Username.
        /// </summary>
        [DataMember(Order = 1)]
        [StringLength(30)]
        [Required()]
        public virtual string Username
        {
            get; set;
        }

        /// <summary>
        /// Optional user group id.
        /// </summary>
        [DataMember(Order = 1)]
        public int? UserGroupId
        {
            get; set;
        }

        /// <summary>
        /// Optional first name.
        /// </summary>
        [StringLength(45)]
        [CharacterOnly()]
        [DataMember()]
        public string FirstName
        {
            get; set;
        }

        /// <summary>
        /// Optional last name.
        /// </summary>
        [StringLength(45)]
        [CharacterOnly()]
        [DataMember()]
        public string LastName
        {
            get; set;
        }

        /// <summary>
        /// Optional birth date.
        /// </summary>
        [DataMember()]
        public DateTime? BirthDate
        {
            get; set;
        }

        /// <summary>
        /// Optional address.
        /// </summary>
        [StringLength(255)]
        [DataMember()]
        public string Address
        {
            get; set;
        }

        /// <summary>
        /// Optional city.
        /// </summary>
        [StringLength(45)]
        [DataMember()]
        public string City
        {
            get; set;
        }

        /// <summary>
        /// Optional country.
        /// </summary>
        [StringLength(45)]
        [DataMember()]
        public string Country
        {
            get; set;
        }

        /// <summary>
        /// Optional post code.
        /// </summary>
        [StringLength(20)]
        [DataMember()]
        public string PostCode
        {
            get; set;
        }

        /// <summary>
        /// Optional phone number.
        /// </summary>
        [StringLength(20)]
        [PhoneNullEmpty()]
        [DataMember()]
        public string Phone
        {
            get; set;
        }

        /// <summary>
        /// Optional mobile phone number.
        /// </summary>
        [StringLength(20)]
        [PhoneNullEmpty()]
        [DataMember()]
        public string MobilePhone
        {
            get; set;
        }

        /// <summary>
        /// Optional email.
        /// </summary>
        [StringLength(254)]
        [EmailNullEmpty()]
        [DataMember()]
        public string Email
        {
            get; set;
        }

        /// <summary>
        /// Optional sex.
        /// </summary>
        [DataMember()]
        public Sex Sex
        {
            get; set;
        }

        /// <summary>
        /// Optional password.
        /// </summary>
        [DataMember()]
        public string Password
        {
            get; set;
        }

        #endregion
    }
}