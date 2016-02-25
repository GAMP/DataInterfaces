using IntegrationLib;
using SharedLib.Dispatcher;
using System;
using System.Collections.Generic;

namespace ServerService
{
    /// <summary>
    /// Service authentication plugin interface.
    /// </summary>
    public interface IServiceAuthenticationPlugin : IServicePlugin
    {
        AuthResult Authenticate(IDictionary<string, object> authHeaders, IMessageDispatcher dispatcher);
        void PostAuthenticate(AuthResult result,IMessageDispatcher dispatcher);
    }
}
