using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Diagnostics;
using System.Security;

namespace CoreLib.Hooking
{
    #region Delegates
    public delegate void KeyboardHookEventHandler(Object sender, KeyboardHookEventArgs e);   
    public delegate void MouseHookEventHandler(Object sender, MouseHookEventArgs e);
    #endregion

    #region Classes

    /// <summary>
    /// Hook event arguments base class.
    /// </summary>
    public class HookEventArgsBase : EventArgs
    {
        /// <summary>
        /// Marks event as handled.
        /// </summary>
        public bool Handeled
        {
            get;
            set;
        }
    }
    
    /// <summary>
    /// Keyboard hook event arguments.
    /// </summary>
    public class KeyboardHookEventArgs : HookEventArgsBase
    {
        #region Constructor
        public KeyboardHookEventArgs(UInt32 keyCode,
            UInt32 scanCode,
            UInt32 flags,
            UInt32 time,
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

        #region Fields
        private KeyState state;
        private IntPtr extraInfo;
        private UInt32 keyCode,flags,time,scanCode;
        private ModifierKeys modifiers= ModifierKeys.None;
        #endregion

        #region Properties
        
        /// <summary>
        /// A virtual-key code. The code must be a value in the range 1 to 254. 
        /// </summary>
        public UInt32 KeyCode
        {
            get { return this.keyCode; }
            protected set { this.keyCode = value; }
        }
        
        /// <summary>
        /// Gets the state of the key event.
        /// </summary>
        public KeyState State
        {
            get { return this.state; }
            protected set { this.state = value; }
        }
        
        /// <summary>
        /// The extended-key flag, event-injected flag, context code, and transition-state flag. This member is specified as follows. 
        /// An application can use the following values to test the keystroke flags. 
        /// </summary>
        public UInt32 Flags
        {
            get { return this.flags; }
            protected set { this.flags = value; }
        }
        
        /// <summary>
        /// The time stamp for this message, equivalent to what GetMessageTime would return for this message.
        /// </summary>
        public UInt32 Time
        {
            get { return this.time; }
            protected set { this.time = value; }
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
            get { return this.modifiers; }
            private set { this.modifiers = value; }
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
            get { return this.extraInfo; }
            protected set { this.extraInfo = value; }
        }

        /// <summary>
        /// A hardware scan code for the key. 
        /// </summary>
        public UInt32 ScanCode
        {
            get { return this.scanCode; }
            protected set { this.scanCode = value; }
        }
        #endregion

        #region Imports
        
        [SuppressUnmanagedCodeSecurity()]
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetAsyncKeyState(int vkey);
        [SuppressUnmanagedCodeSecurity()]
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int nVirtKey);

        #endregion

        #region Functions

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

        #region Ovverides
        public override string ToString()
        {
            return String.Format("Key {0} Modifiers {1} State {2}", this.Key, this.Modifiers, this.State);
        }
        #endregion
    }

    #region MouseHookEventArgs
    /// <summary>
    /// Mouse hooked event arguments.
    /// </summary>
    public class MouseHookEventArgs : HookEventArgsBase
    {
        #region Constructor
        public MouseHookEventArgs(int x, int y, int extra, int hitTest, IntPtr hWnd)
        {
            this.X = x;
            this.Y = y;
            this.Extra = extra;
            this.HitTest = hitTest;
            this.Hwnd = hWnd;

        }
        #endregion
        
        #region Properties
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

        #region Ovverides
        public override string ToString()
        {
            return String.Format("X:{0} Y{1} HWND{2} HITTEST{3} EXTRA{4}", this.X, this.Y, this.Hwnd, this.HitTest, this.Extra);
        }
        #endregion
    } 
    #endregion

    #region KeyHook
    /// <summary>
    /// Key hook configuration class.
    /// </summary>
    public class KeyHook
    {
        #region Constructor
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="modifiers">Key Modifiers.</param>
        public KeyHook(Keys key,
            ModifierKeys modifiers,
            KeyState state)
        {
            this.Key = key;
            this.Modifiers = modifiers;
            this.State = state;
        }
        #endregion

        #region Fileds
        private Keys key = Keys.None;
        private ModifierKeys modifiers = ModifierKeys.None;
        private KeyState keyState;
        #endregion
        
        #region Properties
        /// <summary>
        /// Hook key.
        /// </summary>
        public Keys Key
        {
            get { return this.key; }
            protected set { this.key = value; }
        }
        /// <summary>
        /// Key modifiers.
        /// </summary>
        public ModifierKeys Modifiers
        {
            get { return this.modifiers; }
            protected set { this.modifiers = value; }
        }
        /// <summary>
        /// Key state.
        /// </summary>
        public KeyState State
        {
            get { return this.keyState; }
            private set { this.keyState = value; }
        }
        #endregion
        
        #region Functions
        public bool IsMatch(KeyboardHookEventArgs args)
        {
            if ((args.Key == this.Key) & (args.Modifiers == this.Modifiers) & (args.State == this.State | this.State == KeyState.Any))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    } 
    #endregion

    #endregion
}