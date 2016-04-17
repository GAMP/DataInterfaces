using Manager.Services;
using ServerService;
using SharedLib;
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

    #region CurrentServiceChangedEventArgs
    public class CurrentServiceChangedEventArgs : SelectedChangeEventArgs<IRemoteGizmoService>
    {
        #region CONSTRUCTOR
        public CurrentServiceChangedEventArgs(IRemoteGizmoService current, IRemoteGizmoService previous)
        {
            this.Current = current;
            this.Previous = previous;
        }
        #endregion
    }
    #endregion    
}
