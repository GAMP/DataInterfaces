using CoreLib.Diagnostics;
using CoreLib.Threading;

namespace SharedLib.Tasks
{
    /// <summary>
    /// Task implementation inteface.
    /// </summary>
    public interface ITask
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Executes the task.
        /// </summary>
        void Execute();

        /// <summary>
        /// Terminates active task.
        /// </summary>
        void Terminate();

        /// <summary>
        /// Executes the task.
        /// </summary>
        /// <param name="abortHandle">Abort handle.</param>
        void Execute(IAbortHandle abortHandle); 

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if task is currently active.
        /// </summary>
        bool IsActive { get; }

        /// <summary>
        /// Gets ICoreProcessStartInfo of task.
        /// </summary>
        ICoreProcessStartInfo StartInfo
        {
            get;
        } 

        #endregion
    } 
}
