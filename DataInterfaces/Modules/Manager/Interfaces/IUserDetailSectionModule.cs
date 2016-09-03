using Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Modules
{
    public interface IUserDetailSectionModule
    {
        /// <summary>
        /// Initialize module to user.
        /// </summary>
        /// <param name="user">User view model instance.</param>
        /// <returns>Associated task.</returns>
        Task Initialize(IUserMemberViewModel user);

        /// <summary>
        /// Gets icon resource.
        /// </summary>
        string IconResource { get; }

        /// <summary>
        /// Gets header string.
        /// </summary>
        string Header { get; }

    }
}
