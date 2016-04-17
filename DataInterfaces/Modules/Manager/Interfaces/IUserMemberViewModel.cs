using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.ViewModels
{
    /// <summary>
    /// Member user view model interface.
    /// </summary>
    public interface IUserMemberViewModel : IUserViewModel
    {
        /// <summary>
        /// Gets or sets user group id.
        /// </summary>
        int? GroupId { get; }

        /// <summary>
        /// Gets email.
        /// </summary>
        string Email { get; }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// Gets total amount of points.
        /// </summary>
        int Points { get; }

        /// <summary>
        /// Gets user deposits balance.
        /// </summary>
        decimal Deposits { get; }
    }
}
