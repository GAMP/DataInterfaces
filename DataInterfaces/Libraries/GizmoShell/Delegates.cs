using System;
using System.Drawing;
using System.Windows.Forms;

namespace GizmoShell
{
    /// <summary>
    /// Window event delegate.
    /// </summary>
    /// <param name="hWnd">Window handle.</param>
    public delegate void WindowEventDelegate(IntPtr hWnd);

    /// <summary>
    /// Working area change delegate.
    /// </summary>
    /// <param name="area">Working are rect.</param>
    public delegate void WorkingAreaChnagedDelegate(Rectangle area);

    /// <summary>
    /// User idle change delegate.
    /// </summary>
    /// <param name="args">Event arguments.</param>
    public delegate void UserIdleDelegate(UserIdleEventArgs args);

    /// <summary>
    /// Shell command delegate.
    /// </summary>
    /// <param name="commandType">Command type.</param>
    public delegate void ShellCommandDelegate(ApplicationCommandType commandType);

    /// <summary>
    /// Shell notify icon event delegate.
    /// </summary>
    /// <param name="icon">Shell notify icon.</param>
    public delegate void ShellNotifyIconEventDelegate(IShellNotifyIcon icon);

    /// <summary>
    /// Window message delegate.
    /// </summary>
    /// <param name="m">Window message.</param>
    public delegate void WindowMessageDlegeate(Message m);

    /// <summary>
    /// Shell exception delegate.
    /// </summary>
    /// <param name="ex">Exception instance.</param>
    public delegate void ShellExceptionDelegate(Exception ex);
}
