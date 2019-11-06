using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using System.Windows.Input;

namespace CoreLib.Hooking
{
    /// <summary>
    /// Keyboard hook event arguments.
    /// </summary>
    public class KeyboardHookEventArgs : HookEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="keyCode">Key code.</param>
        /// <param name="scanCode">Scan code.</param>
        /// <param name="flags">Flags.</param>
        /// <param name="time">Time.</param>
        /// <param name="extraInfo">Extra info.</param>
        /// <param name="state">State.</param>
        /// <param name="getModifiers">Indicates if modfires should be obtained.</param>
        public KeyboardHookEventArgs(uint keyCode,
            uint scanCode,
            uint flags,
            uint time,
            IntPtr extraInfo,
            KeyState state,
            bool getModifiers = true)
        {
            KeyCode = keyCode;
            State = state;
            ScanCode = scanCode;
            Flags = flags;
            Time = time;
            ExtraInfo = extraInfo;
            if (getModifiers)
            {
                GetModifers();
            }
            CapsOn = GetAsyncKeyState((int)Keys.CapsLock) != 0;
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
            get { return (Keys)KeyCode; }
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
            get { return (Flags & 0x10) != 0; }
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

        /// <summary>
        /// Gets modifiers.
        /// </summary>
        private void GetModifers()
        {
            if (IsKeyPushedDown(Keys.LShiftKey))
            {
                Modifiers |= ModifierKeys.Shift;
            }
            if (IsKeyPushedDown(Keys.LControlKey))
            {
                Modifiers |= ModifierKeys.Control;
            }
            if (IsKeyPushedDown(Keys.LMenu))
            {
                Modifiers |= ModifierKeys.Alt;
            }
            if (IsKeyPushedDown(Keys.LWin))
            {
                Modifiers |= ModifierKeys.Windows;
            }
        }

        /// <summary>
        /// Gets if key is pushed down.
        /// </summary>
        /// <param name="vKey">Key.</param>
        /// <returns>True or false.</returns>
        public static bool IsKeyPushedDown(Keys vKey)
        {
            return 0 != (GetKeyState((int)vKey) & 0x8000);
        }

        #endregion

        #region OVERRIDES
        /// <summary>
        /// Converts to string.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Key {0} Modifiers {1} State {2}", Key, Modifiers, State);
        }
        #endregion
    }
}
