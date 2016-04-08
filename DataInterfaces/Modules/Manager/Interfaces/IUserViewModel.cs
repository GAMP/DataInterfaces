using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.ViewModels
{
    /// <summary>
    /// Generic user view model interface.
    /// </summary>
    public interface IUserViewModel
    {
        /// <summary>
        /// Gets user id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets user id.
        /// </summary>
        int UserId { get; set; }

        /// <summary>
        /// Gets address.
        /// </summary>
        string Address { get; set; }

        /// <summary>
        /// Gets birthdate.
        /// </summary>
        DateTime? BirthDate { get; set; }

        /// <summary>
        /// Gets city.
        /// </summary>
        string City { get; set; }

        /// <summary>
        /// Gets country.
        /// </summary>
        string Country { get; set; }

        /// <summary>
        /// Gets email.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Gets first name.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Gets last name.
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Gets if user is disabled.
        /// </summary>
        bool IsDisabled { get; set; }

        /// <summary>
        /// Gets mobile phone number.
        /// </summary>
        string Mobile { get; set; }

        /// <summary>
        /// Gets phone number.
        /// </summary>
        string Phone { get; set; }

        /// <summary>
        /// Gets post code.
        /// </summary>
        string PostCode { get; set; }

        /// <summary>
        /// Gets sex.
        /// </summary>
        Sex Sex { get; set; }

        /// <summary>
        /// Gets if user is delted.
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
