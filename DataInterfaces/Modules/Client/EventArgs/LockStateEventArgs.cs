using System;

namespace Client
{
    [Serializable()]
    public class LockStateEventArgs : EventArgs
    {
        #region CONSTRUCTOR
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
