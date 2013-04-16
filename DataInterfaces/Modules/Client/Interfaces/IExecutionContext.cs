using System;
using System.Collections.ObjectModel;
using SharedLib.Applications;
using System.Diagnostics;
using SharedLib;

namespace Client
{
    public interface IExecutionContext
    {
        /// <summary>
        /// Initiates execution abort.
        /// </summary>
        void BeginAbort(bool async);
        /// <summary>
        /// Asynchronosly executes context.
        /// </summary>
        /// <param name="reinstall">Indicates if reprocessing should occour.</param>
        void BeginExecute(bool reinstall);
        /// <summary>
        /// Destroys context.
        /// </summary>
        void Destroy();
        /// <summary>
        /// Releases context without destroying it.
        /// </summary>
        void Release();
        /// <summary>
        /// Gets executable instance of this context.
        /// </summary>
        IExecutable Executable { get; }
        /// <summary>
        /// Occours when execution state changes.
        /// </summary>
        event global::Client.ExecutionContextStateChangedDelegate ExecutionStateChaged;
        /// <summary>
        /// Gets if aborting is initiated.
        /// </summary>
        bool IsAborting { get; }
        /// <summary>
        /// Gets if context is alive (have running processes).
        /// </summary>
        bool IsAlive { get; }
        /// <summary>
        /// Gets if execution is currently active.
        /// </summary>
        bool IsExecuting { get; }
        /// <summary>
        /// Gets Application Profile of this context.
        /// </summary>
        IApplicationProfile Profile { get; }
        /// <summary>
        /// Gets the last execution state.
        /// </summary>
        ContextExecutionState State { get; }
        /// <summary>
        /// Gets total execution time.
        /// </summary>
        TimeSpan TotalExecutionTime { get; }
        /// <summary>
        /// Tries to activate main windows of context processes.
        /// </summary>
        /// <returns>True if at leas one window was activated.</returns>
        bool TryActivate();
        /// <summary>
        /// Adds a process to execution context.
        /// </summary>
        /// <param name="process">Process instance.</param>
        /// <param name="isMain">Indicates that the process is main parent process.</param>
        void AddProcess(Process process, bool isMain);
        /// <summary>
        /// Kills context.
        /// </summary>
        void Kill();
        /// <summary>
        /// Tries to obtain full executable file name.
        /// </summary>
        /// <param name="processId">Process id.</param>
        /// <param name="fileName">Found file name.</param>
        /// <returns>True if process name found else false.</returns>
        bool TryGetProcessFileName(int processId, out string fileName);
        /// <summary>
        /// Writes a message to client log.
        /// </summary>
        /// <param name="message">Message string.</param>
        void WriteMessage(string message);
        /// <summary>
        /// Gets if context currently waiting for finalization.
        /// </summary>
        bool IsWaitingFinalization { get; }
        /// <summary>
        /// Gets the execution context client.
        /// </summary>
        IClient Client { get; }
        /// <summary>
        /// Indicates that execution was previously completed with success.
        /// </summary>
        bool HasCompleted { get; }
        /// <summary>
        /// Gets if the executable should be autolaunched.
        /// </summary>
        bool AutoLaunch { get; }

    }

}
