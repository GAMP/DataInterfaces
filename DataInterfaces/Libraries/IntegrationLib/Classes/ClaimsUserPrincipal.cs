using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib
{
    #region ClaimsUserPrincipal
    public class ClaimsUserPrincipal : ClaimsPrincipal
    {
        #region CONSTRUCTOR
        public ClaimsUserPrincipal(IIdentity identity)
            : base(identity)
        {
        }
        #endregion
    }
    #endregion
}
