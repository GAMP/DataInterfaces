using SkinInterfaces;
using System;
using System.Collections.Generic;

namespace SharedLib.ViewModels
{
    /// <summary>
    /// Menu item viewmodel interface.
    /// Used by viewmodel classes that are exposed for binding with menus.
    /// </summary>
    public interface IMenuItemViewModel
    {
        #region PROPERTIES

        /// <summary>
        /// Gets child items.
        /// </summary>
        IEnumerable<IMenuItemViewModel> Children { get; }

        /// <summary>
        /// Gets or sets command.
        /// </summary>
        IExecutionChangedAwareCommand Command { get; set; }

        /// <summary>
        /// Gets icon resource.
        /// </summary>
        string IconResource { get; set; }

        /// <summary>
        /// Gets or sets if icon resource represents vector icon.
        /// </summary>
        bool IsVectorIcon { get; set; }

        /// <summary>
        /// Gets the display header.
        /// </summary>
        string Header { get; set; }

        /// <summary>
        /// Gets or sets if menu is checked.
        /// </summary>
        bool IsChecked { get; set; }

        /// <summary>
        /// Gets or sets if menu is checkable.
        /// </summary>
        bool IsCheckable { get; set; }

        /// <summary>
        /// Gets or sets if menu represents a seperator.
        /// </summary>
        bool IsSeperator { get; set; }

        /// <summary>
        /// Gets menu id.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets menu parent id.
        /// </summary>
        int? ParentId { get; }

        /// <summary>
        /// Gets or sets command parameter.
        /// </summary>
        object CommandParameter { get; set; }

        /// <summary>
        /// Gets or sets shortcut command string.
        /// </summary>
        string Shortcut { get; set; }

        /// <summary>
        /// Gets or sets if menu should be hidden if command cannot execute.
        /// </summary>
        bool CantExecuteHide { get; set; } 

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Refresh menu binder.
        /// </summary>
        void Refresh();

        /// <summary>
        /// Deferr resfresh.
        /// </summary>
        void DeferrRefresh();

        /// <summary>
        /// Deferr resfresh.
        /// </summary>
        /// <param name="delay">Delay.</param>
        void DeferrRefresh(TimeSpan delay);

        /// <summary>
        /// Deferr resfresh.
        /// </summary>
        /// <param name="delay">Delay in milliseconds.</param>
        void DeferrRefresh(int delay); 

        #endregion
    }
}
