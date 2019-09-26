using System;

namespace CoreLib.Hooking
{
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
}
