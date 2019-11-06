using System;
namespace GizmoShell
{
    /// <summary>
    /// Window info interface.
    /// </summary>
    public interface IWindowInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets window class name.
        /// </summary>
        string ClassName { get; }

        /// <summary>
        /// Gets window handle.
        /// </summary>
        IntPtr Handle { get; }

        /// <summary>
        /// Gets window height.
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// Gets window icon.
        /// </summary>
        System.Windows.Media.ImageSource Icon { get; }

        /// <summary>
        /// Gets if window is active.
        /// </summary>
        bool IsActive { get; }

        /// <summary>
        /// Gets or sets if window is enabled.
        /// </summary>
        bool IsEnabled { get; set; }

        /// <summary>
        /// Gets if window is maximized.
        /// </summary>
        bool IsMaximized { get; }

        /// <summary>
        /// Gets if window is minimized.
        /// </summary>
        bool IsMinimized { get; }

        /// <summary>
        /// Gets or sets if window is visible.
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// Gets if window is visible task.
        /// </summary>
        bool IsVisibleTask { get; }

        /// <summary>
        /// Gets or sets window left position.
        /// </summary>
        int Left { get; set; }

        /// <summary>
        /// Gets or sets window location point.
        /// </summary>
        System.Drawing.Point Location { get; set; }

        /// <summary>
        /// Gets or sets window message timeout.
        /// </summary>
        uint MessageTimeout { get; set; }

        /// <summary>
        /// Gets window process module name.
        /// </summary>
        string ModuleName { get; }

        /// <summary>
        /// Gets if window is not responding.
        /// </summary>
        bool NotResponding { get; }

        /// <summary>
        /// Gets window process instance.
        /// </summary>
        System.Diagnostics.Process Process { get; }

        /// <summary>
        /// Gets window process id.
        /// </summary>
        int ProcessId { get; }

        /// <summary>
        /// Gets or sets window rectangle.
        /// </summary>
        System.Drawing.Rectangle Rectangle { get; set; }

        /// <summary>
        /// Gets or sets window region.
        /// </summary>
        System.Drawing.Region Region { get; set; }

        /// <summary>
        /// Gets or sets window size.
        /// </summary>
        System.Drawing.Size Size { get; set; }

        /// <summary>
        /// Converts window to bitmap image.
        /// </summary>
        /// <returns></returns>
        System.Drawing.Bitmap ToBitmap();

        /// <summary>
        /// Gets window thread id.
        /// </summary>
        int ThreadId { get; }

        /// <summary>
        /// Gets or sets window title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets window top location.
        /// </summary>
        int Top { get; set; }

        /// <summary>
        /// Gets window width.
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Gets if window is valid.
        /// </summary>
        bool IsValidWindow { get; }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Activates window.
        /// </summary>
        /// <returns>True for success, otherwise false.</returns>
        bool Activate();

        /// <summary>
        /// Brings window to front.
        /// </summary>
        void BringToFront();

        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <returns>True for success, otherwise false.</returns>
        bool Close();

        /// <summary>
        /// Checks if specified window is parent of this window.
        /// </summary>
        /// <param name="hWnd">Window handle.</param>
        bool IsParent(IntPtr hWnd);

        /// <summary>
        /// Destroys window.
        /// </summary>
        /// <returns>True for success, otherwise false.</returns>
        bool Destroy();

        /// <summary>
        /// End tasks window.
        /// </summary>
        /// <param name="force">Force parameter.</param>
        /// <returns>True for success, otherwise false.</returns>
        bool EndTask(bool force);

        /// <summary>
        /// Fits window to screen.
        /// </summary>
        void FitToScreen();

        /// <summary>
        /// Fits window to screen.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        void FitToScreen(int x, int y, int width, int height);

        /// <summary>
        /// Checks if specified handle belongs to this window.
        /// </summary>
        /// <param name="hWnd">Child window handle.</param>
        /// <returns>True for succsess, otherwise false.</returns>
        bool IsChild(IntPtr hWnd);

        /// <summary>
        /// Maximizes the window.
        /// </summary>
        /// <returns>True for sucsess, otherwise false.</returns>
        bool Maximize();

        /// <summary>
        /// Minimizes the window.
        /// </summary>
        /// <param name="force">Force parameter.</param>
        /// <returns>True for sucsess, otherwise false.</returns>
        bool Minimize(bool force = false);

        /// <summary>
        /// Moves window.
        /// </summary>
        /// <param name="rectangle">Move rectangle.</param>
        /// <returns>True for sucsess, otherwise false.</returns>
        bool MoveWindow(System.Drawing.Rectangle rectangle);

        /// <summary>
        /// Posts window close message.
        /// </summary>
        void PostClose();

        /// <summary>
        /// Posts window message.
        /// </summary>
        /// <param name="msg">Window message.</param>
        /// <param name="wParam">Optional parameter.</param>
        /// <param name="lParam">Optional parameter.</param>
        /// <returns>True for sucsess, otherwise false.</returns>
        bool PostMessage(uint msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Posts window message.
        /// </summary>
        /// <param name="m">Window message.</param>
        /// <returns>True for success, otherwise false.</returns>
        bool PostMessage(System.Windows.Forms.Message m);

        /// <summary>
        /// Restores window.
        /// </summary>
        /// <param name="previousActive">Previous active option.</param>
        /// <returns>True for success, otherwise false.</returns>
        bool Restore(bool previousActive = false);

        /// <summary>
        /// Sends window message.
        /// </summary>
        /// <param name="msg">Message.</param>
        /// <param name="wParam">Optional parameter.</param>
        /// <param name="lParam">Optional parameter.</param>
        /// <returns>Message result.</returns>
        IntPtr SendMessage(uint msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Sends window message.
        /// </summary>
        /// <param name="m">Window message.</param>
        /// <returns>Message result.</returns>
        IntPtr SendMessage(System.Windows.Forms.Message m);

        /// <summary>
        /// Sends window to background.
        /// </summary>
        void SendToBack();

        /// <summary>
        /// Attempts to make the window topmost.
        /// </summary>
        /// <param name="topMost">Topmost option.</param>
        void SetTopMost(bool topMost);

        /// <summary>
        /// Shows window context menu.
        /// </summary>
        /// <returns>True for sucsess, otherwise false.</returns>
        bool ShowContextMenu();

        /// <summary>
        /// Switches to this window.
        /// </summary>
        void SwitchTo();

        /// <summary>
        /// True for sucsess, otherwise false.
        /// </summary>
        /// <param name="altTab">Use alt-tab behaviour.</param>
        void SwitchTo(bool altTab);

        /// <summary>
        /// Convert window info to string.
        /// </summary>
        /// <returns>Window info string.</returns>
        string ToString();

        #endregion        
    }
}
