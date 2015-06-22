using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkinInterfaces.Code
{
    #region ICompletionAwareCommand
    /// <summary>
    /// Interface that is used for ICommands that notify when they are completed.
    /// </summary>
    public interface ICompletionAwareCommand
    {
        /// <summary>
        /// Notifies that the command has completed
        /// </summary>
        WeakActionEvent<object> CommandCompleted { get; set; }
    }
    #endregion
}
