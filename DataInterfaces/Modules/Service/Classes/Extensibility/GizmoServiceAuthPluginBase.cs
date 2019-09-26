using IntegrationLib;
using SharedLib.Dispatcher;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace ServerService
{
    /// <summary>
    /// Base class for authentication plugins. 
    /// </summary>
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IGizmoServiceAuthenticationPlugin))]
    public abstract class GizmoServiceAuthPluginBase : GizmoServicePluginBase, IGizmoServiceAuthenticationPlugin
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Called on user authentication.
        /// </summary>
        /// <param name="authHeaders">Authentication headers.</param>
        /// <param name="dispatcher">Calling dispatcher.</param>
        /// <returns>Authentication result instance.</returns>
        public virtual AuthResult Authenticate(IDictionary<string, object> authHeaders, IMessageDispatcher dispatcher)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called after user authentication.
        /// </summary>
        /// <param name="result">Authentication result.</param>
        /// <param name="dispatcher">Calling dispatcher.</param>
        /// <remarks>Here you can modify the final result that will be returned to authenticated party.</remarks>
        public virtual void PostAuthenticate(AuthResult result, IMessageDispatcher dispatcher)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
