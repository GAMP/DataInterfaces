using System;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.Serialization;

namespace CoreLib.Hooking
{
    /// <summary>
    /// Key hook configuration class.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class KeyHook
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="modifiers">Key Modifiers.</param>
        /// <param name="state">Key state.</param>
        public KeyHook(Keys key, ModifierKeys modifiers, KeyState state)
        {
            Key = key;
            Modifiers = modifiers;
            State = state;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Hook key.
        /// </summary>
        [DataMember()]
        public Keys Key
        {
            get;
            protected set;
        }

        /// <summary>
        /// Key modifiers.
        /// </summary>
        [DataMember()]
        public ModifierKeys Modifiers
        {
            get;
            protected set;
        }

        /// <summary>
        /// Key state.
        /// </summary>
        [DataMember()]
        public KeyState State
        {
            get;
            protected set;
        }

        #endregion

        #region FUNCTIONS
        /// <summary>
        /// Check if this instance matches event arguments.
        /// </summary>
        /// <param name="args">Keyboard event arguments.</param>
        /// <returns>True or false.</returns>
        public bool IsMatch(KeyboardHookEventArgs args)
        {
            return args != null && args.Key == Key && (args.State == State || args.State == KeyState.Any) && args.Modifiers.HasFlag(Modifiers);
        }
        #endregion
    }
}
