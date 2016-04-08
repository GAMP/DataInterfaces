using Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Modules
{
    /// <summary>
    /// Provides ability to track currently selected users in user module.
    /// </summary>
    public interface IUserModuleSelectionProvider
    {
        /// <summary>
        /// Gets selected items.
        /// </summary>
        IEnumerable<IUserMemberViewModel> SelectedItems
        {
            get;
        }

        /// <summary>
        /// Gets slected item.
        /// </summary>
        IUserMemberViewModel SelectedItem
        {
            get;
        }

        /// <summary>
        /// Gets if selection has logged in.
        /// </summary>
        bool SelectionHasLoggedIn { get; }

        /// <summary>
        /// Gets if single is selected and not logged in.
        /// </summary>
        bool SelectedSingleNotLoggedIn { get; }

        /// <summary>
        /// Gets selected user ids.
        /// </summary>
        IEnumerable<int> GetSelectedUserIds();
    }
}
