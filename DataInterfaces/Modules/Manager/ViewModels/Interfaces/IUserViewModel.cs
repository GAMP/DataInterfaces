using SharedLib;
using System;
using System.ComponentModel;

namespace Manager.ViewModels
{
    /// <summary>
    /// Base user view model interface implemented by all user view models.
    /// </summary>
    public interface IUserViewModel : INotifyPropertyChanged
    {
        #region PROPERTIES

        /// <summary>
        /// Gets user id.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets user id.
        /// </summary>
        int UserId { get; }

        /// <summary>
        /// Gets address.
        /// </summary>
        string Address { get; }

        /// <summary>
        /// Gets birthdate.
        /// </summary>
        DateTime? BirthDate { get; }

        /// <summary>
        /// Gets city.
        /// </summary>
        string City { get; }

        /// <summary>
        /// Gets country.
        /// </summary>
        string Country { get; }

        /// <summary>
        /// Gets first name.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Gets last name.
        /// </summary>
        string LastName { get; }

        /// <summary>
        /// Gets if user is disabled.
        /// </summary>
        bool IsDisabled { get; }

        /// <summary>
        /// Gets mobile phone number.
        /// </summary>
        string Mobile { get; }

        /// <summary>
        /// Gets phone number.
        /// </summary>
        string Phone { get; }

        /// <summary>
        /// Gets post code.
        /// </summary>
        string PostCode { get; }

        /// <summary>
        /// Gets sex.
        /// </summary>
        Sex Sex { get; }

        /// <summary>
        /// Gets if user is delted.
        /// </summary>
        bool IsDeleted { get; }

        /// <summary>
        /// Gets user guid.
        /// </summary>
        Guid Guid { get; }

        /// <summary>
        /// Gets user SmartCard UID.
        /// </summary>
        string SmartCardUID { get; }

        /// <summary>
        /// Gets users identification.
        /// </summary>
        string Identification { get; }

        /// <summary>
        /// Gets user age.
        /// </summary>
        int? Age { get; }

        #endregion
    }
}
