using System;
using System.Windows;

namespace SkinLib
{
    #region IUIComponent
    public interface IUIComponent
    {
        /// <summary>
        /// Gets or sets component assembly name.
        /// </summary>
        string AssemblyName { get; set; }

        /// <summary>
        /// Gets or sets component description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets framework element associated with this component.
        /// </summary>
        FrameworkElement Instance { get; set; }

        /// <summary>
        /// Gets or sets GUID.
        /// </summary>
        string GUID { get; set; }

        /// <summary>
        /// Gets or sets component title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets component type.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Gets if compoenent instance is created.
        /// </summary>
        bool HasInstance { get; }
    }
    #endregion
}
