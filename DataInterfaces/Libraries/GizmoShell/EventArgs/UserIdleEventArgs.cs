using System;

namespace GizmoShell
{
    #region UserIdleEventArgs
    public class UserIdleEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public UserIdleEventArgs(bool isIdle)
        {
            IsIdle = isIdle;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets if the user is idle or not.
        /// </summary>
        public bool IsIdle
        {
            get;
            protected set;
        }
        #endregion
    } 
    #endregion
}
