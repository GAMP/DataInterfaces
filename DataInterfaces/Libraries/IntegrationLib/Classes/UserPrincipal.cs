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
            : base(idenity, new string[] { idenity.Role.ToString() })
        {
        }

        #endregion
    }
    #endregion
}
