using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Collections.ObjectModel;

namespace SkinLib
{
    public interface IUIConfiguration
    {
        /// <summary>
        /// Gets user controls.
        /// </summary>
        IEnumerable<FrameworkElement> UserControls
        {
            get;
        }

        /// <summary>
        /// Gets components.
        /// </summary>
        IEnumerable<IUIComponent> Components
        {
            get;
        }

        /// <summary>
        /// Gets layouts.
        /// </summary>
        IEnumerable<IUILayout> Layouts
        {
            get;
        }

        /// <summary>
        /// Gets task bar component.
        /// </summary>
        IUIComponent TaskBarComponent
        {
            get;
        }

        /// <summary>
        /// Gets application list component.
        /// </summary>
        IUIComponent ApplicationListComponent
        {
            get;
        }

        /// <summary>
        /// Gets main window component.
        /// </summary>
        IUIComponent MainWindowComponent
        {
            get;
        }
    }
}
