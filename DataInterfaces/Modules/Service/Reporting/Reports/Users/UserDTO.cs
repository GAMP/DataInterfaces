using System;
using System.Runtime.Serialization;
using SharedLib;

namespace ServerService.Reporting.Reports.Users
{
    /// <summary>
    /// User's Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class UserDTO
    {
        /// <summary>
        /// User's username.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// User's first name.
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// User's last name.
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// User's birth date.
        /// </summary>
        [DataMember]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Registration date of the user.
        /// </summary>
        [DataMember]
        public DateTime Registered { get; set; }

        /// <summary>
        /// The Id of the group to which the user belongs.
        /// </summary>
        [DataMember]
        public int GroupId { get; set; }

        /// <summary>
        /// The name of the group to which the user belongs.
        /// </summary>
        [DataMember]
        public string GroupName { get; set; }

        /// <summary>
        /// User's country.
        /// </summary>
        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// User's city.
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// User's address.
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// User's e-mail.
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// User's phone number.
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// User's mobile phone number.
        /// </summary>
        [DataMember]
        public string MobilePhone { get; set; }

        /// <summary>
        /// User's postal code.
        /// </summary>
        [DataMember]
        public string PostCode { get; set; }

        /// <summary>
        /// User Id.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// User's gender.
        /// </summary>
        [DataMember]
        public Sex Sex { get; set; }

        /// <summary>
        /// User is banned.
        /// </summary>
        public bool IsBanned { get; set; }

    }
}
