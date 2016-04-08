using SharedLib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.ViewModels
{
    public interface IUserViewModelLocator : IViewModelLocator<IUserMemberViewModel>
    {
        /// <summary>
        /// Checks if specified username exists.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <param name="exclude">User id to excluse from search.</param>
        /// <returns>True or false.</returns>
        bool UserExists(string userName, int exclude);
    }
}
