using System;
using System.Windows.Input;
namespace GizmoShell
{
    public interface IShellNotifyIcon : IShellItemBase
    {
        void PopupClicked();
        System.Windows.Media.ImageSource BaloonIcon { get; }
        uint CallBackMessage { get; }
        void Dispose();
        void DoubleClick();
        void DoubleClick(MouseButton button);
        Guid Guid { get; }
        bool HasIcon { get; }
        IntPtr Hwnd { get; }
        System.Windows.Media.ImageSource Icon { get; }
        uint Id { get; }
        string Info { get; }
        string InfoTitle { get; }
        bool IsHidden { get; }
        bool IsShared { get; }
        bool IsStandartToolTip { get; }
        bool IsValid { get; }
        bool IsVisible { get; }
        void LeftClick();
        void MouseEnter();
        void MouseLeave();
        void MouseMove();
        void PopUpClose();
        System.Diagnostics.Process Process { get; }
        int ProcessId { get; }
        void RightClick();
        uint TimeOut { get; }
        string ToolTip { get; }
        System.Windows.Forms.ToolTipIcon ToolTipIcon { get; }
        bool PopupVisible { get; }
        uint Version { get; }
    }
}
