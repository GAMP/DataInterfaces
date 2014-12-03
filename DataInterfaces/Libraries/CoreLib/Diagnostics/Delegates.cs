using SharedLib.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreLib.Diagnostics
{
    public delegate void BeginProcessKillDelegate(ICoreProcessKillInfo killInfo, IMessageDispatcher dispatcher = null);
    public delegate ICoreProcess BeginProcessStartDelegate(ICoreProcessStartInfo startInfo, IMessageDispatcher dispatcher = null);
}
