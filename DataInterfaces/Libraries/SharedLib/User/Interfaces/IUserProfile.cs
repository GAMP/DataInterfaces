using System;

namespace SharedLib.User
{
    /// <summary>
    /// User profile implementation interface.
    /// </summary>
    public interface IUserProfile
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// First Name.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Last Name.
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Gets the users birth date.
        /// </summary>
        DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets users registration date.
        /// </summary>
        DateTime Registered { get; set; }

        /// <summary>
        /// Gets the group id of the user.
        /// </summary>
        int GroupId { get; set; }

        /// <summary>
        /// Group Name.
        /// </summary>
        string GroupName { get; set; }

        /// <summary>
        /// Country.
        /// </summary>
        string Country { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        string City { get; set; }

        /// <summary>
        /// Address.
        /// </summary>
        string Address { get; set; }

        /// <summary>
        /// Email address.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Phone Number.
        /// </summary>
        string Phone { get; set; }

        /// <summary>
        /// Mobile Phone Number.
        /// </summary>
        string MobilePhone { get; set; }

        /// <summary>
        /// Post code.
        /// </summary>
        string PostCode { get; set; }

        /// <summary>
        /// User id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Sex.
        /// </summary>
        Sex Sex { get; set; }

        /// <summary>
        /// Gets user role.
        /// </summary>
        UserRoles Role { get; set; }

        /// <summary>
        /// Gets if user is administrator.
        /// </summary>
        bool IsAdmin { get; }

        /// <summary>
        /// Gets if user is guest.
        /// </summary>
        bool IsGuest { get; }

        /// <summary>
        /// Gets or sets if user profile is enabled.
        /// </summary>
        bool IsEnabled { get; set; }

        #endregion

        #region FUNCTIONS
        
        /// <summary>
        /// Reset profile to default values.
        /// </summary>
        void Reset();

        #endregion
    }
}
