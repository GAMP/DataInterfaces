namespace SkinInterfaces
{
    /// <summary>
    /// Interface that is used for ICommands that notify when they are completed.
    /// </summary>
    public interface ICompletionAwareCommand
    {
        #region PROPERTIES
        
        /// <summary>
        /// Notifies that the command has completed
        /// </summary>
        WeakActionEvent<object> CommandCompleted { get; set; } 

        #endregion
    }
}
