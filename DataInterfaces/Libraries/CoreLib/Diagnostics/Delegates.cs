using SharedLib.Dispatcher;

namespace CoreLib.Diagnostics
{
    public delegate void BeginProcessKillDelegate(ICoreProcessKillInfo killInfo, IMessageDispatcher dispatcher = null);
    public delegate ICoreProcess BeginProcessStartDelegate(ICoreProcessStartInfo startInfo, IMessageDispatcher dispatcher = null);
}
