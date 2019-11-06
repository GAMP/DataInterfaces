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
        #region PROPERTIES

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
        
        #endregion
    }
    #endregion

    #region ISelectedChangedEvent
    /// <summary>
    /// Selected changed event provider.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    public interface ISelectedChangedEvent<T>
    {
        #region EVENTS
        /// <summary>
        /// Raised when selected item changes.
        /// </summary>
        event EventHandler<SelectedChangeEventArgs<T>> SelectedChanged; 
        #endregion
    }
    #endregion

    #region ISelectionChangedEvent
    /// <summary>
    /// Selection changed event provider.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    public interface ISelectionChangedEvent<T>
    {
        #region EVENTS
        /// <summary>
        /// Raised when selected items changed.
        /// </summary>
        event EventHandler<SelectionChangedEventArgs> SelectionChanged; 
        #endregion
    }
    #endregion

    #region ISingleGetSelectionProvider
    /// <summary>
    /// Single selection provider interface.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
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
    /// <summary>
    /// Multi selection provider interface.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
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
