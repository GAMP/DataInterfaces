using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.ViewModels
{
    /// <summary>
    /// Generic user member view model interface.
    /// </summary>
    public interface IUserMemberViewModel : IUserViewModel
    {
        /// <summary>
        /// Gets or sets user group id.
        /// </summary>
        int? GroupId { get; set; }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        string UserName { get; set; }
    }
}
