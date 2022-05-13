using System;

namespace Client
{
    /// <summary>
    /// Client user lock change args.
    /// </summary>
    public class UserLockChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public UserLockChangeEventArgs()
        { }

        #endregion

        public bool IsLocked { get; set; }
    }
}
