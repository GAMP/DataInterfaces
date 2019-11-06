using SharedLib.Dispatcher;
using System.Security.Claims;

namespace IntegrationLib
{
    /// <summary>
    /// Dispatcher principal.
    /// </summary>
    /// <remarks>
    /// Provides means for accessing current identity based on calling dispatcher.
    /// </remarks>
    public class DispatcherPrincipal : ClaimsPrincipal, IDispatcherPrincipal
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="dispatcher">Dispatcher.</param>
        /// <param name="identity">Identity.</param>
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
}
