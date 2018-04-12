using System.ComponentModel;

namespace Manager.ViewModels
{
    /// <summary>
    /// Implemented by host view models that represent a host computer.
    /// </summary>
    public interface IHostComputerViewModel : IHostViewModel, INotifyPropertyChanged
    {
    }
}
