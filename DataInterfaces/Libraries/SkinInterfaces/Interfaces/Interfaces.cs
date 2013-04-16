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
    #region IBindingTarget
    /// <summary>
    /// By implementing this interface you can explicitly specify tha data source that
    /// you want to recieve as DataContext upon module creation.
    /// </summary>
    public interface IBindingTarget
    {
        BindingSources TargetType
        {
            get;
        }

        object DataContext
        {
            get;
            set;
        }

    }
    #endregion

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

    #region IConfigurableComponent
    /// <summary>
    /// Interface for implementing custom settings inside of your controls.
    /// </summary>
    public interface IConfigurableComponent
    {
        /// <summary>
        /// This method is called when componenet is loaded or when new settings is passed to the custom componenent.
        /// </summary>
        /// <param name="settings">Settings Instance.</param>
        void SetSettings(IComponentConfiguration settings);
        /// <summary>
        /// This method is called when the skin engine requires the settings from the componenet.
        /// </summary>
        /// <returns>IComponentConfiguration instance.</returns>
        IComponentConfiguration GetSettings();
        /// <summary>
        /// This method is called when skin engine requires the settings of the componenet to be reset to the default values.
        /// </summary>
        void ResetSettings();
    }
    #endregion

    #region IComponentConfiguration
    /// <summary>
    /// Component configuration interface.
    /// </summary>
    public interface IComponentConfiguration
    {

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
        int Left { get; set; }
        void Refresh();
        bool ShellExecute();
        global::System.Windows.Media.ImageSource SmallIcon { get; }
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
