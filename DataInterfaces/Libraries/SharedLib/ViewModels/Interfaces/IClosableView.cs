using System;
using System.ComponentModel;
using System.Security;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shell;

namespace SharedLib.Views
{
    /// <summary>
    /// Reperesents a closable view.
    /// </summary>
    public interface IClosableView : IView
    {
        double Height { get; set; }
        double Width { get; set; }

        //
        // Summary:
        //     Gets or sets the outer margin of an element.
        //
        // Returns:
        //     Provides margin values for the element. The default value is a System.Windows.Thickness
        //     with all properties equal to 0 (zero).
        Thickness Margin { get; set; }
        //
        // Summary:
        //     Gets or sets the maximum height constraint of the element.
        //
        // Returns:
        //     The maximum height of the element, in device-independent units (1/96th inch
        //     per unit). The default value is System.Double.PositiveInfinity. This value
        //     can be any value equal to or greater than 0.0. System.Double.PositiveInfinity
        //     is also valid.
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        [TypeConverter(typeof(LengthConverter))]
        double MaxHeight { get; set; }
        //
        // Summary:
        //     Gets or sets the maximum width constraint of the element.
        //
        // Returns:
        //     The maximum width of the element, in device-independent units (1/96th inch
        //     per unit). The default value is System.Double.PositiveInfinity. This value
        //     can be any value equal to or greater than 0.0. System.Double.PositiveInfinity
        //     is also valid.
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        [TypeConverter(typeof(LengthConverter))]
        double MaxWidth { get; set; }
        //
        // Summary:
        //     Gets or sets the minimum height constraint of the element.
        //
        // Returns:
        //     The minimum height of the element, in device-independent units (1/96th inch
        //     per unit). The default value is 0.0. This value can be any value equal to
        //     or greater than 0.0. However, System.Double.PositiveInfinity is NOT valid,
        //     nor is System.Double.NaN.
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        [TypeConverter(typeof(LengthConverter))]
        double MinHeight { get; set; }
        //
        // Summary:
        //     Gets or sets the minimum width constraint of the element.
        //
        // Returns:
        //     The minimum width of the element, in device-independent units (1/96th inch
        //     per unit). The default value is 0.0. This value can be any value equal to
        //     or greater than 0.0. However, System.Double.PositiveInfinity is not valid,
        //     nor is System.Double.NaN.
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        [TypeConverter(typeof(LengthConverter))]
        double MinWidth { get; set; }
        // Summary:
        //     Gets or sets a value that indicates whether a window's client area supports
        //     transparency.
        //
        // Returns:
        //     true if the window supports transparency; otherwise, false.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.Window.AllowsTransparency is changed after a window has been
        //     shown.
        //
        //   System.InvalidOperationException:
        //     A window that has a System.Windows.Window.WindowStyle value of anything other
        //     than System.Windows.WindowStyle.None.
        bool AllowsTransparency { get; set; }
        //
        // Summary:
        //     Gets or sets the dialog result value, which is the value that is returned
        //     from the System.Windows.Window.ShowDialog() method.
        //
        // Returns:
        //     A System.Nullable<T> value of type System.Boolean. The default is false.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.Window.DialogResult is set before a window is opened by calling
        //     System.Windows.Window.ShowDialog(). -or-System.Windows.Window.DialogResult
        //     is set on a window that is opened by calling System.Windows.Window.Show().
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [TypeConverter(typeof(DialogResultConverter))]
        bool? DialogResult { get; set; }
        //
        // Summary:
        //     Gets or sets a window's icon.
        //
        // Returns:
        //     An System.Windows.Media.ImageSource object that represents the icon.
        ImageSource Icon { get; set; }
        //
        // Summary:
        //     Gets a value that indicates whether the window is active.
        //
        // Returns:
        //     true if the window is active; otherwise, false. The default is false.
        bool IsActive { get; }
        //
        // Summary:
        //     Gets or sets the position of the window's left edge, in relation to the desktop.
        //
        // Returns:
        //     The position of the window's left edge, in logical units (1/96th of an inch).
        [TypeConverter("System.Windows.LengthConverter, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
        double Left { get; set; }

        //
        // Summary:
        //     Gets a collection of windows for which this window is the owner.
        //
        // Returns:
        //     A System.Windows.WindowCollection that contains references to the windows
        //     for which this window is the owner.
        WindowCollection OwnedWindows { get; }
        //
        // Summary:
        //     Gets or sets the System.Windows.Window that owns this System.Windows.Window.
        //
        // Returns:
        //     A System.Windows.Window object that represents the owner of this System.Windows.Window.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     A window tries to own itself-or-Two windows try to own each other.
        //
        //   System.InvalidOperationException:
        //     The System.Windows.Window.Owner property is set on a visible window shown
        //     using System.Windows.Window.ShowDialog()-or-The System.Windows.Window.Owner
        //     property is set with a window that has not been previously shown.
        [DefaultValue("")]
        Window Owner { get; set; }
        //
        // Summary:
        //     Gets or sets the resize mode.
        //
        // Returns:
        //     A System.Windows.ResizeMode value specifying the resize mode.
        ResizeMode ResizeMode { get; set; }
        //
        // Summary:
        //     Gets the size and location of a window before being either minimized or maximized.
        //
        // Returns:
        //     A System.Windows.Rect that specifies the size and location of a window before
        //     being either minimized or maximized.
        Rect RestoreBounds { get; }
        //
        // Summary:
        //     Gets or sets a value that indicates whether a window is activated when first
        //     shown.
        //
        // Returns:
        //     true if a window is activated when first shown; otherwise, false. The default
        //     is true.
        bool ShowActivated { get; set; }
        //
        // Summary:
        //     Gets or sets a value that indicates whether the window has a task bar button.
        //
        // Returns:
        //     true if the window has a task bar button; otherwise, false. Does not apply
        //     when the window is hosted in a browser.
        bool ShowInTaskbar { get; set; }
        //
        // Summary:
        //     Gets or sets a value that indicates whether a window will automatically size
        //     itself to fit the size of its content.
        //
        // Returns:
        //     A System.Windows.SizeToContent value. The default is System.Windows.SizeToContent.Manual.
        SizeToContent SizeToContent { get; set; }
        //
        // Summary:
        //     Gets or sets the Windows 7 taskbar thumbnail for the System.Windows.Window.
        //
        // Returns:
        //     The Windows 7 taskbar thumbnail for the System.Windows.Window.
        TaskbarItemInfo TaskbarItemInfo { get; set; }
        //
        // Summary:
        //     Gets or sets a window's title.
        //
        // Returns:
        //     A System.String that contains the window's title.
        [Localizability(LocalizationCategory.Title)]
        string Title { get; set; }
        //
        // Summary:
        //     Gets or sets the position of the window's top edge, in relation to the desktop.
        //
        // Returns:
        //     The position of the window's top, in logical units (1/96").
        [TypeConverter("System.Windows.LengthConverter, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
        double Top { get; set; }
        //
        // Summary:
        //     Gets or sets a value that indicates whether a window appears in the topmost
        //     z-order.
        //
        // Returns:
        //     true if the window is topmost; otherwise, false.
        bool Topmost { get; set; }
        //
        // Summary:
        //     Gets or sets the position of the window when first shown.
        //
        // Returns:
        //     A System.Windows.WindowStartupLocation value that specifies the top/left
        //     position of a window when first shown. The default is System.Windows.WindowStartupLocation.Manual.
        WindowStartupLocation WindowStartupLocation { get; set; }
        //
        // Summary:
        //     Gets or sets a value that indicates whether a window is restored, minimized,
        //     or maximized.
        //
        // Returns:
        //     A System.Windows.WindowState that determines whether a window is restored,
        //     minimized, or maximized. The default is System.Windows.WindowState.Normal
        //     (restored).
        WindowState WindowState { get; set; }
        //
        // Summary:
        //     Gets or sets a window's border style.
        //
        // Returns:
        //     A System.Windows.WindowStyle that specifies a window's border style. The
        //     default is System.Windows.WindowStyle.SingleBorderWindow.
        WindowStyle WindowStyle { get; set; }

        // Summary:
        //     Occurs when a window becomes the foreground window.
        event EventHandler Activated;
        //
        // Summary:
        //     Occurs when the window is about to close.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.UIElement.Visibility is set, or System.Windows.Window.Show(),
        //     System.Windows.Window.ShowDialog(), or System.Windows.Window.Hide() is called
        //     while a window is closing.
        event EventHandler Closed;
        //
        // Summary:
        //     Occurs directly after System.Windows.Window.Close() is called, and can be
        //     handled to cancel window closure.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.UIElement.Visibility is set, or System.Windows.Window.Show(),
        //     System.Windows.Window.ShowDialog(), or System.Windows.Window.Close() is called
        //     while a window is closing.
        event CancelEventHandler Closing;
        //
        // Summary:
        //     Occurs after a window's content has been rendered.
        event EventHandler ContentRendered;
        //
        // Summary:
        //     Occurs when a window becomes a background window.
        event EventHandler Deactivated;
        //
        // Summary:
        //     Occurs when the window's location changes.
        event EventHandler LocationChanged;
        //
        // Summary:
        //     This event is raised to support interoperation with Win32. See System.Windows.Interop.HwndSource.
        event EventHandler SourceInitialized;
        //
        // Summary:
        //     Occurs when the window's System.Windows.Window.WindowState property changes.
        event EventHandler StateChanged;

        // Summary:
        //     Attempts to bring the window to the foreground and activates it.
        //
        // Returns:
        //     true if the System.Windows.Window was successfully activated; otherwise,
        //     false.
        [SecurityCritical]
        bool Activate();

        //
        // Summary:
        //     Manually closes a System.Windows.Window.
        [SecurityCritical]
        void Close();
        //
        // Summary:
        //     Allows a window to be dragged by a mouse with its left button down over an
        //     exposed area of the window's client area.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The left mouse button is not down.
        [SecurityCritical]
        void DragMove();
        //
        // Summary:
        //     Makes a window invisible.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.Window.Hide() is called on a window that is closing (System.Windows.Window.Closing)
        //     or has been closed (System.Windows.Window.Closed).
        void Hide();

        //
        // Summary:
        //     Opens a window and returns without waiting for the newly opened window to
        //     close.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.Window.Show() is called on a window that is closing (System.Windows.Window.Closing)
        //     or has been closed (System.Windows.Window.Closed).
        void Show();
        //
        // Summary:
        //     Opens a window and returns only when the newly opened window is closed.
        //
        // Returns:
        //     A System.Nullable<T> value of type System.Boolean that specifies whether
        //     the activity was accepted (true) or canceled (false). The return value is
        //     the value of the System.Windows.Window.DialogResult property before a window
        //     closes.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.Window.ShowDialog() is called on a System.Windows.Window that
        //     is visible-or-System.Windows.Window.ShowDialog() is called on a visible System.Windows.Window
        //     that was opened by calling System.Windows.Window.ShowDialog().
        //
        //   System.InvalidOperationException:
        //     System.Windows.Window.ShowDialog() is called on a window that is closing
        //     (System.Windows.Window.Closing) or has been closed (System.Windows.Window.Closed).
        [SecurityCritical]
        bool? ShowDialog();

        object Content { get; set; }

        double ActualWidth {get;}

        double ActualHeight { get; }

        event RoutedEventHandler Loaded;

        System.Windows.Threading.Dispatcher Dispatcher { get; }
    }
}
