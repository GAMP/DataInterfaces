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
    #region KeyHook
    /// <summary>
    /// Key hook configuration class.
    /// </summary>
    public class KeyHook
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="modifiers">Key Modifiers.</param>
        public KeyHook(Keys key,ModifierKeys modifiers,KeyState state)
        {
            this.Key = key;
            this.Modifiers = modifiers;
            this.State = state;
        }
        #endregion
       
        #region PROPERTIES

        /// <summary>
        /// Hook key.
        /// </summary>
        public Keys Key
        {
            get;
            protected set;
        }
        
        /// <summary>
        /// Key modifiers.
        /// </summary>
        public ModifierKeys Modifiers
        {
            get;
            protected set;
        }
        
        /// <summary>
        /// Key state.
        /// </summary>
        public KeyState State
        {
            get;
            protected set;
        }
        
        #endregion
        
        #region FUNCTIONS
        public bool IsMatch(KeyboardHookEventArgs args)
        {
            return args!=null && args.Key == this.Key && (args.State == this.State || args.State == KeyState.Any) && args.Modifiers.HasFlag(this.Modifiers); 
        }
        #endregion
    } 
    #endregion
}