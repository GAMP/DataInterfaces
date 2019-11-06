using System.Security.Claims;

namespace IntegrationLib
{
    /// <summary>
    /// HTTP Context identity provider.
    /// </summary>
    public abstract class HttpContextIdentityProvider
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets current instance.
        /// </summary>
        public static HttpContextIdentityProvider Current
        {
            get; set;
        }

        /// <summary>
        /// Gets current principal.
        /// </summary>
        public virtual ClaimsPrincipal CurrentPrincipal
        {
            get;
        } 

        #endregion
    }
}
