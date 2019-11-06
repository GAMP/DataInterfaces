using System.Windows.Forms;

namespace CoreLib.Hooking
{
    /// <summary>
    /// Mouse low level hook event arguments.
    /// </summary>
    public class MouseLowLevelHookEventArgs : HookEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="button">Button.</param>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <param name="flags">Flags.</param>
        /// <param name="clickCount">Click count.</param>
        public MouseLowLevelHookEventArgs(MouseButtons button, int x, int y, uint flags, int clickCount)
        {
            Button = button;
            X = x;
            Y = y;
            Flags = flags;
            ClickCount = clickCount;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets click count.
        /// </summary>
        public int ClickCount
        {
            get; protected set;
        }

        /// <summary>
        /// Gets mouse button.
        /// </summary>
        public MouseButtons Button
        {
            get; protected set;
        }

        /// <summary>
        /// Gets X position.
        /// </summary>
        public int X
        {
            get; protected set;
        }

        /// <summary>
        /// Gets Y position.
        /// </summary>
        public int Y
        {
            get; protected set;
        }

        /// <summary>
        /// Gets flags.
        /// </summary>
        public uint Flags
        {
            get; protected set;
        }

        /// <summary>
        /// Gets if key is injected.
        /// </summary>
        public bool IsInjected
        {
            get { return (Flags & 0x1) != 0; }
        }

        #endregion
    }
}
