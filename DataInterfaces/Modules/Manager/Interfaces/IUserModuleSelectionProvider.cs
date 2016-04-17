using Manager.ViewModels;
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
    public interface IUserModuleSelectionProvider 
    {
        event EventHandler<SelectionChangedEventArgs> SelectionChanged;

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

    public interface ISingleGetSelectionProvider<T>
    {
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
