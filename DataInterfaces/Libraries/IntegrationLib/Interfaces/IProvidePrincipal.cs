using System.Security.Principal;

namespace IntegrationLib
{
    public interface IProvidePrincipal
    {
        #region FUNCTIONS

        /// <summary>
        /// Creates principal from http credentials.
        /// </summary>
        /// <param name="cr">Http credentials.</param>
        /// <returns>Resulted IPrincipal.</returns>
        IPrincipal CreatePrincipal(HttpCredentials cr);

        #endregion
    }
}
