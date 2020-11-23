using System;
using SharedLib.Applications;
using System.Diagnostics;
using SharedLib;

namespace Client
{
    /// <summary>
    /// Execution context interface.
    /// </summary>
    /// <remarks>
    /// Provides access and interactivity with client application executables.
    /// </remarks>
    public interface IExecutionContext
    {
        #region EVENTS

        /// <summary>
        /// Occours when execution state changes.
        /// </summary>
        event EventHandler<ExecutionContextStateArgs> ExecutionStateChaged;

        #endregion        

        #region PROPERTIES

        /// <summary>
        /// Gets executable instance of this context.
        /// </summary>
        IExecutable Executable { get; }

        /// <summary>
        /// Gets application instance of this context.
        /// </summary>
        IApplicationProfile Profile { get; }

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
        /// Gets if context is ready for execution.
        /// </summary>
        bool IsReady { get; }

        /// <summary>
        /// Gets the last execution state.
        /// </summary>
        ContextExecutionState State { get; }

        /// <summary>
        /// Gets total execution time.
        /// </summary>
        TimeSpan TotalExecutionSpan { get; }

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

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Destroys context.
        /// </summary>
        void Destroy();

        /// <summary>
        /// Releases context without destroying it.
        /// </summary>
        void Release();

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
        /// Adds a process to execution context if successfully started.
        /// </summary>
        /// <param name="process">Process instance.</param>
        /// <param name="isMain">Indicates that the process is main parent process.</param>
        /// <remarks>This function ensures that process will be started and added to the context and any child process created and terminated events will be handled.<br></br>
        /// <b>The process specified by <paramref name="process"/> parameter must not be running.</b>
        /// </remarks>
        /// <returns><a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process.start">Process.Start()</a> return value.</returns>
        bool AddProcessIfStarted(Process process, bool isMain);

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
        /// Kills context.
        /// </summary>
        void Kill();

        #endregion
    }
}
