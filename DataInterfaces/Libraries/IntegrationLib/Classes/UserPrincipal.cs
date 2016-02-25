using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationLib
{
    #region UserPrincipal
    public class UserPrincipal : GenericPrincipal
    {
        #region Constructor
        public UserPrincipal(UserIdentity idenity, string[] roles)
            : base(idenity, roles)
        {
        }

        public UserPrincipal(UserIdentity idenity)
            : this(idenity, new string[] { idenity.Role.ToString() })
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets current thread Principal.
        /// </summary>
        public static UserPrincipal Current
        {
            get { return Thread.CurrentPrincipal as UserPrincipal; }
        }

        /// <summary>
        /// Gets user identity.
        /// </summary>
        public UserIdentity UserIdentity
        {
            get { return this.Identity as UserIdentity; }
        }

        #endregion
    }
    #endregion
}
