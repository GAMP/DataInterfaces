using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using System.Windows.Input;

namespace CoreLib.Hooking
{
    #region HookEventArgsBase
    /// <summary>
    /// Hook event arguments base class.
    /// </summary>
    public abstract class HookEventArgsBase : EventArgs
    {
        #region PROPERTIES
        /// <summary>
        /// Marks event as handled.
        /// </summary>
        public bool Handled
        {
            get;
            set;
        }
        #endregion
    }
    #endregion

    #region KeyboardHookEventArgs
    /// <summary>
    /// Keyboard hook event arguments.
    /// </summary>
    public class KeyboardHookEventArgs : HookEventArgsBase
    {
        #region CONSTRUCTOR
        public KeyboardHookEventArgs(uint keyCode,
            uint scanCode,
            uint flags,
            uint time,
            IntPtr extraInfo,
            KeyState state,
            bool getModifiers = true)
        {
            this.KeyCode = keyCode;
            this.State = state;
            this.ScanCode = scanCode;
            this.Flags = flags;
            this.Time = time;
            this.ExtraInfo = extraInfo;
            if (getModifiers)
            {
                this.GetModifers();
            }
            this.CapsOn = GetAsyncKeyState((int)Keys.CapsLock) != 0;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// A virtual-key code. The code must be a value in the range 1 to 254. 
        /// </summary>
        public uint KeyCode
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the state of the key event.
        /// </summary>
        public KeyState State
        {
            get;
            protected set;
        }

        /// <summary>
        /// The extended-key flag, event-injected flag, context code, and transition-state flag. This member is specified as follows. 
        /// An application can use the following values to test the keystroke flags. 
        /// </summary>
        public uint Flags
        {
            get;
            protected set;
        }

        /// <summary>
        /// The time stamp for this message, equivalent to what GetMessageTime would return for this message.
        /// </summary>
        public uint Time
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the key of the event.
        /// </summary>
        public Keys Key
        {
            get { return (Keys)this.KeyCode; }
        }

        /// <summary>
        /// Gets the modifiers of the event.
        /// </summary>
        public ModifierKeys Modifiers
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets if caps lock was on when event occurred.
        /// </summary>
        public bool CapsOn
        {
            get;
            protected set;
        }

        /// <summary>
        /// Additional information associated with the message. 
        /// </summary>
        public IntPtr ExtraInfo
        {
            get;
            protected set;
        }

        /// <summary>
        /// A hardware scan code for the key. 
        /// </summary>
        public uint ScanCode
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets if key is injected.
        /// </summary>
        public bool IsInjected
        {
            get { return (this.Flags & 0x10) != 0; }
        }

        #endregion

        #region IMPORTS

        [SuppressUnmanagedCodeSecurity()]
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetAsyncKeyState(int vkey);
        [SuppressUnmanagedCodeSecurity()]
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int nVirtKey);

        #endregion

        #region FUNCTIONS

        private void GetModifers()
        {
            if (KeyboardHookEventArgs.IsKeyPushedDown(Keys.LShiftKey))
            {
                this.Modifiers |= ModifierKeys.Shift;
            }
            if (KeyboardHookEventArgs.IsKeyPushedDown(Keys.LControlKey))
            {
                this.Modifiers |= ModifierKeys.Control;
            }
            if (KeyboardHookEventArgs.IsKeyPushedDown(Keys.LMenu))
            {
                this.Modifiers |= ModifierKeys.Alt;
            }
            if (KeyboardHookEventArgs.IsKeyPushedDown(Keys.LWin))
            {
                this.Modifiers |= ModifierKeys.Windows;
            }
        }

        public static bool IsKeyPushedDown(Keys vKey)
        {
            return 0 != (GetKeyState((int)vKey) & 0x8000);
        }

        #endregion

        #region OVERRIDES
        public override string ToString()
        {
            return String.Format("Key {0} Modifiers {1} State {2}", this.Key, this.Modifiers, this.State);
        }
        #endregion
    }
    #endregion

    #region MouseHookEventArgs
    /// <summary>
    /// Mouse hook event arguments.
    /// </summary>
    public class MouseHookEventArgs : HookEventArgsBase
    {
        #region CONSTRUCTOR
        public MouseHookEventArgs(int x, int y, int extra, int hitTest, IntPtr hWnd)
        {
            this.X = x;
            this.Y = y;
            this.Extra = extra;
            this.HitTest = hitTest;
            this.Hwnd = hWnd;
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
        public override string ToString()
        {
            return String.Format("X:{0} Y{1} HWND{2} HITTEST{3} EXTRA{4}", this.X, this.Y, this.Hwnd, this.HitTest, this.Extra);
        }
        #endregion
    }
    #endregion

    #region MouseLowLevelHookEventArgs
    /// <summary>
    /// Mouse low level hook event arguments.
    /// </summary>
    public class MouseLowLevelHookEventArgs : HookEventArgsBase
    {
        #region CONSTRUCTOR
        public MouseLowLevelHookEventArgs(MouseButtons button, int x,int y, uint flags,int clickCount)
        {
            this.Button = button;
            this.X = x;
            this.Y = y;
            this.Flags = flags;
            this.ClickCount = clickCount;
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
            get { return (this.Flags & 0x1) != 0; }
        } 

        #endregion
    } 
    #endregion
}
