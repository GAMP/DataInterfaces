using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.Applications;

namespace SharedLib
{
    public delegate void ShutDownDelegate(object sender, ShutDownEventArgs e);
    public delegate void StartUpDelegate(object sender, StartUpEventArgs e);
    public delegate void CurrentActivityDelegate(StartupModuleActivity current);
    public delegate void ContainerChangedDelegate(object sender,ContainerChangedEventArgs e);
    public delegate void ManagerLoginDelegate(object sender,ManagerLoginEventArgs e);
    public delegate void LogMessageAddedDelegate(object sender,LogEventArgs e);
}
