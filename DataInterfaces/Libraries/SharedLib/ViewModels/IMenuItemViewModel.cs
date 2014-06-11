using SkinInterfaces.Code;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SharedLib.ViewModels
{
    public interface IMenuBinder
    {
        /// <summary>
        /// Gets current child items.
        /// </summary>
        IEnumerable<IMenuBinder> Children { get; }

        /// <summary>
        /// Gets execution command.
        /// </summary>
        IExecutionChangedAwareCommand Command { get; set; }

        /// <summary>
        /// Gets icon resource.
        /// </summary>
        string IconResource { get; set; }

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
    }
}
