using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GizmoShell
{
    #region UserIdleEventArgs
    public class UserIdleEventArgs : EventArgs
    {
        #region Constructor
        public UserIdleEventArgs(bool isIdle)
        {
            this.IsIdle = isIdle;
        }
        #endregion

        #region Properties
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
