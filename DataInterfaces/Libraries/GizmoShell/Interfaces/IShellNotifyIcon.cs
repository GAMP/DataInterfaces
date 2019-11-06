using System;
using System.Windows.Input;

namespace GizmoShell
{
    /// <summary>
    /// Shell notification icon.
    /// </summary>
    public interface IShellNotifyIcon
    {
        #region PROPERTIES

        /// <summary>
        /// Gets baloon icon image source.
        /// </summary>
        System.Windows.Media.ImageSource BaloonIcon { get; }

        /// <summary>
        /// Gets callback message id.
        /// </summary>
        uint CallBackMessage { get; }

        /// <summary>
        /// Gets icon guid.
        /// </summary>
        Guid Guid { get; }

        /// <summary>
        /// Gets if icon is present.
        /// </summary>
        bool HasIcon { get; }

        /// <summary>
        /// Gets handle.
        /// </summary>
        IntPtr Hwnd { get; }

        /// <summary>
        /// Gets icon image.
        /// </summary>
        System.Windows.Media.ImageSource Icon { get; }

        /// <summary>
        /// Gets icon id.
        /// </summary>
        uint Id { get; }

        /// <summary>
        /// Gets icon info.
        /// </summary>
        string Info { get; }

        /// <summary>
        /// Gets icon info title.
        /// </summary>
        string InfoTitle { get; }

        /// <summary>
        /// Gets if icon is hidden.
        /// </summary>
        bool IsHidden { get; }

        /// <summary>
        /// Gets if icon is shared.
        /// </summary>
        bool IsShared { get; }

        /// <summary>
        /// Gets if icon tooltip is standart.
        /// </summary>
        bool IsStandartToolTip { get; }

        /// <summary>
        /// Gets if icon is valid.
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Gets if icon is visible.
        /// </summary>
        bool IsVisible { get; }

        /// <summary>
        /// Gets icon process.
        /// </summary>
        System.Diagnostics.Process Process { get; }

        /// <summary>
        /// Gets icon process id.
        /// </summary>
        int ProcessId { get; }

        /// <summary>
        /// Gets icon timeout.
        /// </summary>
        uint TimeOut { get; }

        /// <summary>
        /// Gets tooltip.
        /// </summary>
        string ToolTip { get; }

        /// <summary>
        /// Gets tooltip icon.
        /// </summary>
        System.Windows.Forms.ToolTipIcon ToolTipIcon { get; }

        /// <summary>
        /// Gets if popup is visibile.
        /// </summary>
        bool PopupVisible { get; }

        /// <summary>
        /// Gets icon version.
        /// </summary>
        uint Version { get; }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Simulates popup click.
        /// </summary>
        void PopupClicked();

        /// <summary>
        /// Simulates double click.
        /// </summary>
        void DoubleClick();

        /// <summary>
        /// Simulates mouse button click.
        /// </summary>
        /// <param name="button">Mouse button.</param>
        void DoubleClick(MouseButton button);

        /// <summary>
        /// Simulates left click.
        /// </summary>
        void LeftClick();

        /// <summary>
        /// Simulates right click.
        /// </summary>
        void RightClick();

        /// <summary>
        /// Simulates mouse enter.
        /// </summary>
        void MouseEnter();

        /// <summary>
        /// Simulates mouse leave.
        /// </summary>
        void MouseLeave();

        /// <summary>
        /// Simulates mouse move.
        /// </summary>
        void MouseMove();

        /// <summary>
        /// Simulate popup close.
        /// </summary>
        void PopUpClose();    

        #endregion
    }
}
