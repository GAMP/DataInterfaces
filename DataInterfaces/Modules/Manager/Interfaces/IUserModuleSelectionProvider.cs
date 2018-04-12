using Manager.ViewModels;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Manager.Modules
{
    #region IUserModuleSelectionProvider
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
    #endregion

    #region ISelectedChangedEvent
    public interface ISelectedChangedEvent<T>
    {
        /// <summary>
        /// Raised when selected item changes.
        /// </summary>
        event EventHandler<SelectedChangeEventArgs<T>> SelectedChanged;
    }
    #endregion

    #region ISelectionChangedEvent
    public interface ISelectionChangedEvent<T>
    {
        /// <summary>
        /// Raised when selected items changed.
        /// </summary>
        event EventHandler<SelectionChangedEventArgs> SelectionChanged;
    }
    #endregion

    #region ISingleGetSelectionProvider
    public interface ISingleGetSelectionProvider<T> : ISelectedChangedEvent<T>
    {
        #region PROPERTIES

        /// <summary>
        /// Gets selected item.
        /// </summary>
        T SelectedItem { get; }

        #endregion
    } 
    #endregion

    #region IMultiSelectSelectionProvider
    public interface IMultiSelectSelectionProvider<T> : ISingleGetSelectionProvider<T>,
    ISelectionChangedEvent<T>
    {
        #region PROPERTIES

        /// <summary>
        /// Gets selected items.
        /// </summary>
        IEnumerable<T> SelectedItems
        {
            get;
        }

        #endregion
    } 
    #endregion
}
