using SharedLib.Dispatcher;
using System.Security.Claims;

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
            Dispacther = dispatcher;
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

        /// <summary>
        /// Gets user identity.
        /// </summary>
        public IUserIdentity UserIdentity
        {
            get { return Identity as IUserIdentity; }
        }

        #endregion
    }
    #endregion
}
