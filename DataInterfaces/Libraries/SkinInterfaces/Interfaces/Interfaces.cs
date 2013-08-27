using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Media;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Media.Animation;
using System;
using System.Collections.ObjectModel;

namespace SkinInterfaces
{
    #region ICustomComponent
    /// <summary>
    /// Interface that must be implemented by all skin componenents.
    /// </summary>
    public interface ICustomComponent
    {
        ComponentTypes Type
        {
            get;
        }
    }
    #endregion

    #region IMainWindow
    /// <summary>
    /// Interface that must be implemented by the main application window.
    /// </summary>
    public interface IMainWindow
    {
        /// <summary>
        /// Panel to display background items.
        /// <remarks>This panel must have lowest Z-Order in the shell window.</remarks>
        /// </summary>
        ItemsControl BackgroundPanel
        {
            get;
        }

        /// <summary>
        /// Panel to display desktop items.
        /// </summary>
        ItemsControl DesktopPanel
        {
            get;
        }

        /// <summary>
        /// Panel to display foreground items.
        /// </summary>
        ItemsControl ForegroundPanel
        {
            get;
        }
    }
    #endregion

    #region IOverlayDisplayWindow
    /// <summary>
    /// Overlay Window interface.
    /// <remarks>
    /// The purpose of the interface is to allow implementation of a window that would display an overlay over its contents.
    /// </remarks>
    /// </summary>
    public interface IOverlayDisplayWindow : IMainWindow
    {
        /// <summary>
        /// Gets if the overlay is currently shown on window.
        /// </summary>
        bool IsOverlayShown
        {
            get;
        }

        /// <summary>
        /// Sets overlay to specified UIElement.
        /// </summary>
        /// <param name="content">UIElement.</param>
        void SetOverlay(UIElement content);
    }
    #endregion    

    #region IControlBox
    /// <summary>
    /// Control box interface.
    /// </summary>
    public interface IControlBox
    {
        Button CloseButton
        {
            get;
        }

        Button MinimizeButton
        {
            get;
        }

        ToggleButton MaximizeButton
        {
            get;
        }

        ToggleButton SendToBackgroundButton
        {
            get;
        }

        Thumb DragThumb
        {
            get;
        }
    }
    #endregion

    #region ITaskBar
    /// <summary>
    /// System taskbar control interface.
    /// </summary>
    public interface ITaskBar
    {
        /// <summary>
        /// Gets the control that represents start button.
        /// <remarks>Native button name is Start.</remarks>
        /// </summary>
        Button StartButton
        {
            get;
        }

        /// <summary>
        /// Gets the control that represents the notification tary.
        /// <remarks>Native window name is TrayNotifyWnd.</remarks>
        /// </summary>
        ItemsControl NotificationTray
        {
            get;
        }

        /// <summary>
        /// Gets the control that represents the tasks tary.
        /// <remarks>Native window name is RebarWindow32.</remarks>
        /// </summary>
        ItemsControl TasksTray
        {
            get;
        }
    }
    #endregion

    #region IDesktopItemView
    public interface IDesktopItemView
    {
        string DisplayName { get; }
        global::System.Windows.Media.ImageSource ExtraLargeIcon { get; }
        string FileName { get; }
        string FullPath { get; }
        bool IsHidden { get; }
        bool IsVirtual { get; }
        global::SkinInterfaces.DesktopItemViewType ItemType { get; }
        global::System.Windows.Media.ImageSource JumboIcon { get; }
        global::System.Windows.Media.ImageSource LargeIcon { get; }
        global::System.Windows.Media.ImageSource SmallIcon { get; }
        int Left { get; set; }
        void Refresh();
        bool ShellExecute();       
        string ToolTip { get; }
        int Top { get; set; }
    }
    #endregion

    #region IValidatorControl
    public interface IValidatorControl
    {
        ObservableCollection<ValidationError> ValidationErrors { get; }
    }
    #endregion    
}
