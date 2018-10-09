using SharedLib.Applications;
using SharedLib.Dispatcher;
using NetLib;
using System.Windows;
using SharedLib.ViewModels;

namespace SharedLib
{
    public delegate MessageBoxResult NotifyUserDelegate(string message, WindowShowParams parameters, out INotifyWindowViewModel model);
    public delegate void ShutDownDelegate(object sender, ShutDownEventArgs e);
    public delegate void StartUpDelegate(object sender, StartUpEventArgs e);
    public delegate void ContainerChangedDelegate(object sender, ContainerChangedEventArgs e);    
    public delegate bool ContainerExternalFilterDelegate(object sender, IApplicationProfile profile);
    public delegate void ContainerItemsEventDelegate(object sender, ContainerItemEventArgs e);
    public delegate void LogMessageAddedDelegate(object sender, LogEventArgs e);
    public delegate void DispatcherChangedDelegate(IMessageDispatcher oldDispatcher, IMessageDispatcher newDispatcher);
    public delegate void ConnectionChanged(IConnection oldConnection, IConnection newConnection); 
}
