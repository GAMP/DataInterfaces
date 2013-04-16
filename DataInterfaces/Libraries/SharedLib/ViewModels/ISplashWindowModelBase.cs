using System;
using System.Windows;

namespace SharedLib.ViewModels
{
    public delegate MessageBoxResult NotifyUserDelegate(string message, WindowShowParams parameters, out ISplashWindowModelBase model);

    #region ISplashWindowModelBase
    public interface ISplashWindowModelBase
    {
        bool AllowClosing { get; set; }
        bool AllowDrag { get; set; }
        void Hide();
        void HideAsync();
        bool IsLoaded { get; }
        void Show();
        void Show(IntPtr owner);
        void ShowDialog();
        void ShowDialog(IntPtr owner);
        void ShowDialogAsync(IntPtr owner);
        bool WasClosed { get; }
        bool WasShown { get; }
        System.Windows.Window Window { get; }
        IntPtr WindowHandle { get; }
        event EventHandler<EventArgs> Closed;
    } 
    #endregion
}
