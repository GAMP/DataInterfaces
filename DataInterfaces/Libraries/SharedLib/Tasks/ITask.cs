using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.Dispatcher;
using CoreLib.Diagnostics;
using CoreLib.Threading;

namespace SharedLib.Tasks
{
    #region ITask
    public interface ITask
    {
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
    } 
    #endregion
}
