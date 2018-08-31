using System.Security.Claims;

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
