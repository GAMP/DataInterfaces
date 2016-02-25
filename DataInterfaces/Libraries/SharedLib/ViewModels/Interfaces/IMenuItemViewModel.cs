using SkinInterfaces;
using System.Collections.Generic;

namespace SharedLib.ViewModels
{
    public interface IMenuBinder
    {
        /// <summary>
        /// Gets child items.
        /// </summary>
        IEnumerable<IMenuBinder> Children { get; }

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
        int ParentId { get; }

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

        /// <summary>
        /// Refresh menu binder.
        /// </summary>
        void Refresh();
    }
}
