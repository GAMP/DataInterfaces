using SharedLib.Dispatcher;

namespace CoreLib.Diagnostics
{
    /// <summary>
    /// Kill process delegate.
    /// </summary>
    /// <param name="killInfo">Kill info.</param>
    /// <param name="dispatcher">Dispatcher.</param>
    public delegate void BeginProcessKillDelegate(ICoreProcessKillInfo killInfo, IMessageDispatcher dispatcher = null);

    /// <summary>
    /// Start process delegate.
    /// </summary>
    /// <param name="startInfo">Start info.</param>
    /// <param name="dispatcher">Dispatcher.</param>
    /// <returns>Created <see cref="ICoreProcess"/> instance.</returns>
    public delegate ICoreProcess BeginProcessStartDelegate(ICoreProcessStartInfo startInfo, IMessageDispatcher dispatcher = null);
}
