using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace GizmoShell
{
    public delegate void WindowEventDelegate(IntPtr hWnd);
    public delegate void WorkingAreaChnagedDelegate(Rectangle area);
    public delegate void UserIdleDelegate(UserIdleEventArgs args);
    public delegate void ShellCommandDelegate(ApplicationCommandType commandType);
    public delegate void ShellNotifyIconEventDelegate(IShellNotifyIcon icon);
    public delegate void WindowMessageDlegeate(Message m);
    public delegate void ShellExceptionDelegate(Exception ex);

}
