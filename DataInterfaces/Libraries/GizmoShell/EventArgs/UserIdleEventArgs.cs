using System;

namespace GizmoShell
{
    /// <summary>
    /// User idle event args.
    /// </summary>
    public class UserIdleEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="isIdle">Indicates if user is idle.</param>
        public UserIdleEventArgs(bool isIdle)
        {
            IsIdle = isIdle;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if the user is idle.
        /// </summary>
        public bool IsIdle
        {
            get;
            protected set;
        }
        
        #endregion
    } 
}
