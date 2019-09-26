using System.Windows.Input;

namespace SkinInterfaces
{
    /// <summary>
    /// Interface that is used for ICommands that notify when can execute status changes.
    /// </summary>
    public interface IExecutionChangedAwareCommand : ICommand
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Raises can execute changed event.
        /// </summary>
        void RaiseCanExecuteChanged(); 

        #endregion
    }
}
