using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace SkinInterfaces.Code
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
