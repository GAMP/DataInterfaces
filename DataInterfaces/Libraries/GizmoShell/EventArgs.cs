using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GizmoShell
{
    public class UserIdleEventArgs : EventArgs
    {
        #region Constructor
        public UserIdleEventArgs(bool isIdle)
        {
            this.IsIdle = isIdle;
        } 
        #endregion

        #region Fields
        private bool isIdle;
        #endregion

        #region Properties
        /// <summary>
        /// Gets if the user is idle or not.
        /// </summary>
        public bool IsIdle
        {
            get { return this.isIdle; }
            protected set { this.isIdle = value; }
        } 
        #endregion
    }
}
