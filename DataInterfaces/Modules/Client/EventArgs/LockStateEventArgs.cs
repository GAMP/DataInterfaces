using System;

namespace Client
{
    /// <summary>
    /// Lock state change event args.
    /// </summary>
    [Serializable()]
    public class LockStateEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="isLocked">Indicates if locked.</param>
        public LockStateEventArgs(bool isLocked)
        {
            IsLocked = isLocked;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if the lock is active.
        /// </summary>
        public bool IsLocked
        {
            get;
            protected set;
        }

        #endregion
    }
}
