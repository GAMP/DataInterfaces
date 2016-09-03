using Manager.ViewModels;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Manager.Modules
{
    /// <summary>
    /// Provides ability to track currently selected users in user module.
    /// </summary>
    public interface IUserModuleSelectionProvider : ISingleGetSelectionProvider<IUserMemberViewModel>
    {
        /// <summary>
        /// Gets selected user id.
        /// </summary>
        int? SelectedUserId { get; }

        /// <summary>
        /// Gets if selected user is logged in.
        /// </summary>
        bool? IsSelectedLoggedIn { get; }

        /// <summary>
        /// Gets if single is selected and not logged in.
        /// </summary>
        bool? IsSelectedLoggedOut { get; }
    }

    public interface ISingleGetSelectionProvider<T>
    {
        /// <summary>
        /// Raised when selected item changes.
        /// </summary>
        event EventHandler<SelectedChangeEventArgs<T>> SelectedChanged;

        /// <summary>
        /// Gets selected item.
        /// </summary>
        T SelectedItem { get; }
    }

    public interface ISingleSetSelectedProvider <T> : ISingleGetSelectionProvider<T>
    {
        /// <summary>
        /// Gets or sets selected item.
        /// </summary>
        new T SelectedItem { set; }
    }

    public interface IMultiSelectSelectionProvider <T>
    {
        IEnumerable<T> SelectedItems
        {
            get;
        }
    }
}
