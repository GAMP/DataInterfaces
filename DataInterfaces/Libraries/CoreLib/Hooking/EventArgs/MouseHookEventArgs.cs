using System;

namespace CoreLib.Hooking
{
    /// <summary>
    /// Mouse hook event arguments.
    /// </summary>
    public class MouseHookEventArgs : HookEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <param name="extra">Extra data.</param>
        /// <param name="hitTest">Hit test.</param>
        /// <param name="hWnd">Window handle.</param>
        public MouseHookEventArgs(int x, int y, int extra, int hitTest, IntPtr hWnd)
        {
            X = x;
            Y = y;
            Extra = extra;
            HitTest = hitTest;
            Hwnd = hWnd;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// The x-coordinate of the point.
        /// </summary>
        public int X
        {
            get;
            protected set;
        }

        /// <summary>
        /// The y-coordinate of the point.
        /// </summary>
        public int Y
        {
            get;
            protected set;
        }

        /// <summary>
        /// Additional information associated with the message. 
        /// </summary>
        public int Extra
        {
            get;
            protected set;
        }

        /// <summary>
        /// The hit-test value. For a list of hit-test values, see the description of the WM_NCHITTEST message. 
        /// </summary>
        public int HitTest
        {
            get;
            protected set;
        }

        /// <summary>
        /// A handle to the window that will receive the mouse message corresponding to the mouse event. 
        /// </summary>
        public IntPtr Hwnd
        {
            get;
            protected set;
        }

        #endregion

        #region OVERRIDES
        /// <summary>
        /// Converts to string.
        /// </summary>
        public override string ToString()
        {
            return string.Format("X:{0} Y{1} HWND{2} HITTEST{3} EXTRA{4}", X, Y, Hwnd, HitTest, Extra);
        }
        #endregion
    }
}
