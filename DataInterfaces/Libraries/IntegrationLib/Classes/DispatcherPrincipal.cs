using SharedLib.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib
{
    #region DispatcherPrincipal
    public class DispatcherPrincipal : ClaimsPrincipal, IDispatcherPrincipal
    {
        #region CONSTRUCTOR

        public DispatcherPrincipal(IMessageDispatcher dispatcher, IUserIdentity identity)
            : base(identity)
        {
            dispatcher.ThrowDispatcherNull();
            this.Dispacther = dispatcher;
        }

        public DispatcherPrincipal()
        {
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets message dispatcher.
        /// </summary>
        public IMessageDispatcher Dispacther
        {
            get;
            private set;
        }

        public IUserIdentity UserIdentity
        {
            get { return this.Identity as IUserIdentity; }
        }

        #endregion
    }
    #endregion
}
