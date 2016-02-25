using System.Windows.Input;

namespace SkinInterfaces
{
    #region IExecutionChangedAwareCommand
    /// <summary>
    /// Interface that is used for ICommands that notify when can execute status changes.
    /// </summary>
    public interface IExecutionChangedAwareCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
    #endregion
}
