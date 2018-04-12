using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib
{
    public abstract class HttpContextIdentityProvider
    {
        public static HttpContextIdentityProvider Current
        {
            get;set;
        }

        public virtual ClaimsPrincipal CurrentPrincipal
        {
            get;
        }
    }
}
