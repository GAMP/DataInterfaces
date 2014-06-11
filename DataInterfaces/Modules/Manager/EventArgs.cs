using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Manager
{
    #region AuthEventArgs
    public class AuthEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public AuthEventArgs(IIdentity identity)
        {
            if (identity == null)
                throw new ArgumentNullException("IIdentity");

            this.Identity = identity;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets the event user identity.
        /// </summary>
        public IIdentity Identity
        {
            get;
            private set;
        }
        #endregion
    }
    #endregion
}
