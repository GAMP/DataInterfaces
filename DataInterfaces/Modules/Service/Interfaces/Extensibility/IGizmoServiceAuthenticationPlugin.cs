using IntegrationLib;
using SharedLib.Dispatcher;
using System.Collections.Generic;

namespace ServerService
{
    /// <summary>
    /// Gizmo service authentication plugin interface.
    /// </summary>
    public interface IGizmoServiceAuthenticationPlugin : IGizmoServicePlugin
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Called upon authentication.
        /// </summary>
        /// <param name="authHeaders">Authentication headers.</param>
        /// <param name="dispatcher">Authentication source dispatcher.</param>
        /// <returns>Authentication result.</returns>
        AuthResult Authenticate(IDictionary<string, object> authHeaders, IMessageDispatcher dispatcher);

        /// <summary>
        /// Called after authentication.
        /// </summary>
        /// <param name="result">Authentication result.</param>
        /// <param name="dispatcher">Authentication source dispatcher.</param>
        void PostAuthenticate(AuthResult result, IMessageDispatcher dispatcher); 

        #endregion
    }
}
