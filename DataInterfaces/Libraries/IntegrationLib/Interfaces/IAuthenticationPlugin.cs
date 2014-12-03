using SharedLib.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationLib
{
    [Obsolete()]
    public interface IAuthenticationPlugin : IServicePlugin
    {
        AuthResult Authenticate(IDictionary<string, object> authHeaders, IMessageDispatcher dispatcher);
        void PostAuthenticate(AuthResult result,IMessageDispatcher dispatcher);
    }
}
