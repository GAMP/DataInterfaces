using IntegrationLib;
using SharedLib;
using SharedLib.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    #region ManagerDispatcherPrincipal
    public class ManagerDispatcherPrincipal : ClaimsPrincipal
    {
        #region CONSTRUCTOR
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
                return this.UserIdentity;
            }
        }

        /// <summary>
        /// Gets claims.
        /// </summary>
        public override IEnumerable<Claim> Claims
        {
            get
            {
                if (this.UserIdentity == null)
                    return new List<Claim>();

                return this.UserIdentity.Claims;
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
            if (this.UserIdentity == null)
                return false;

            return this.UserIdentity.HasClaim(type, value);
        } 

        #endregion
    } 
    #endregion
}
