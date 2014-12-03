using System;

namespace IntegrationLib
{
    public interface IDispatcherPrincipal
    {
        global::SharedLib.Dispatcher.IMessageDispatcher Dispacther { get; }
        global::IntegrationLib.IUserIdentity UserIdentity { get; }
    }
}
