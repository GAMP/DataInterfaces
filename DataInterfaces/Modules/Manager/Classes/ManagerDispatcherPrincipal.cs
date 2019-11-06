using IntegrationLib;
using SharedLib.Dispatcher;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Manager
{
    /// <summary>
    /// Manager dispatcher principal.
    /// </summary>
    public class ManagerDispatcherPrincipal : ClaimsPrincipal
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public ManagerDispatcherPrincipal()
        { }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets message dispatcher.
        /// </summary>
        public IMessageDispatcher Dispacther
        {
            get;
            set;
        }

        /// <summary>
        /// Gets user identity.
        /// </summary>
        public ClaimsUserIdentity UserIdentity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets identity.
        /// </summary>
        public override IIdentity Identity
        {
            get
            {
                return UserIdentity;
            }
        }

        /// <summary>
        /// Gets claims.
        /// </summary>
        public override IEnumerable<Claim> Claims
        {
            get
            {
                if (UserIdentity == null)
                    return Enumerable.Empty<Claim>();

                return UserIdentity.Claims;
            }
        }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Checks if specified claim is set.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="value">Value.</param>
        /// <returns>True or false.</returns>
        public override bool HasClaim(string type, string value)
        {
            if (UserIdentity == null)
                return false;

            return UserIdentity.HasClaim(type, value);
        } 

        #endregion
    } 
}
