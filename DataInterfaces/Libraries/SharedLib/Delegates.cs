using SharedLib.Applications;
using System.Windows;
using SharedLib.ViewModels;

namespace SharedLib
{
    public delegate MessageBoxResult NotifyUserDelegate(string message, WindowShowParams parameters, out INotifyWindowViewModel model); 
    public delegate bool ContainerExternalFilterDelegate(object sender, IApplicationProfile profile);
    public delegate void ContainerItemsEventDelegate(object sender, ContainerItemEventArgs e);
}
