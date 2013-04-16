using System;
namespace GizmoShell
{
    public interface IWindowInfo
    {
        bool Activate();
        void BringToFront();
        string ClassName { get; }
        bool Close();
        bool Destroy();
        bool EndTask(bool force);
        void FitToScreen();
        void FitToScreen(int x, int y, int width, int height);
        IntPtr Handle { get; }
        int Height { get; set; }
        System.Windows.Media.ImageSource Icon { get; }
        bool IsActive { get; }
        bool IsChild(IntPtr hWnd);
        bool IsEnabled { get; set; }
        bool IsMaximized { get; }
        bool IsMinimized { get; }
        bool IsParent(IntPtr hWnd);
        bool IsVisible { get; set; }
        bool IsVisibleTask { get; }
        int Left { get; set; }
        System.Drawing.Point Location { get; set; }
        bool Maximize();
        uint MessageTimeout { get; set; }
        bool Minimize(bool force = false);
        string ModuleName { get; }
        bool MoveWindow(System.Drawing.Rectangle rectangle);
        bool NotResponding { get; }
        void PostClose();
        bool PostMessage(uint msg, IntPtr wParam, IntPtr lParam);
        bool PostMessage(System.Windows.Forms.Message m);
        System.Diagnostics.Process Process { get; }
        int ProcessId { get; }
        System.Drawing.Rectangle Rectangle { get; set; }
        System.Drawing.Region Region { get; set; }
        bool Restore(bool previousActive = false);
        IntPtr SendMessage(uint msg, IntPtr wParam, IntPtr lParam);
        IntPtr SendMessage(System.Windows.Forms.Message m);
        void SendToBack();
        void SetTopMost(bool topMost);
        bool ShowContextMenu();
        System.Drawing.Size Size { get; set; }
        void SwitchTo();
        void SwitchTo(bool altTab);
        int ThreadId { get; }
        string Title { get; set; }
        System.Drawing.Bitmap ToBitmap();
        int Top { get; set; }
        string ToString();
        int Width { get; set; }
    }
}
