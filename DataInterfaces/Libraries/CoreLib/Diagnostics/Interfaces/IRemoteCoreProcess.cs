using System;

namespace CoreLib.Diagnostics
{
    #region IRemoteCoreProcess
    public interface IRemoteCoreProcess
    {
        SharedLib.Dispatcher.IMessageDispatcher Dispatcher { get; }
    } 
    #endregion
}
