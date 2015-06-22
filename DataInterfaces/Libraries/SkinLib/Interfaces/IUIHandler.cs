using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using GizmoShell;

namespace SkinLib
{
    public interface IUIHandler
    {
        #region EVENTS
        
        /// <summary>
        /// Occurs on each window message sent to the main window.
        /// </summary>
        event WindowMessageDlegeate MainWindowMessage;

        /// <summary>
        /// Occurs when visual state of ui module changes;
        /// </summary>
        event EventHandler<UIModuleVisualStateChangeArgs> UIModuleVisualStateChanged;

        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets list of assemblies.
        /// </summary>
        List<Assembly> Assemblies
        {
            get;
        }

        /// <summary>
        /// Gets current layout.
        /// </summary>
        IUILayout CurrentLayout
        {
            get;
        }

        /// <summary>
        /// Gets active control.
        /// </summary>
        UserControl ActiveControl
        {
            get;
        }

        /// <summary>
        /// Gets current mouse over control.
        /// </summary>
        UserControl MouseOverControl
        {
            get;
        }

        /// <summary>
        /// Gets current ui configuration.
        /// </summary>
        IUIConfiguration UIConfiguration
        {
            get;
        }

        /// <summary>
        /// Gets or sets if multiscreen.
        /// </summary>
        bool IsMultiScreen { get; set; } 
        
        #endregion
    }
}
