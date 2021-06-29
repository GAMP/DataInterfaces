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
        /// Gets if context is alive.
        /// </summary>
        /// <remarks>
        /// <b>Context will be considered alive if there are still tracked processes that have not exited.</b>
        /// </remarks>
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
        /// Adds an existing process to execution context.
        /// </summary>
        /// <param name="process">Process instance.</param>
        /// <param name="isMain">Indicates that the process is main parent process.</param>
        /// <exception cref="ArgumentNullException">thrown in case the specified <paramref name="process"/> is equal to null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">thorwn in case the specified <paramref name="process"/> does not have associated process id (not running).</exception>
        /// <exception cref="InvalidOperationException">thorwn in case the System.Diagnostics.Process.Id property has not been set or there is no process associated with this System.Diagnostics.Process object.</exception>
        /// <remarks>The specified <paramref name="process"/> instance must be running and have process id associated with it.</remarks>
        void AddProcess(Process process, bool isMain);

        /// <summary>
        /// Adds a process to execution context if successfully started.
        /// </summary>
        /// <param name="process">Process instance.</param>
        /// <param name="isMain">Indicates that the process is main parent process.</param>
        /// <remarks>This function ensures that process will be started and added to the context and any child process created and terminated events will be handled.<br></br>
        /// <b>The process specified by <paramref name="process"/> parameter must not be running.</b>
        /// </remarks>
        /// <returns>True if new process was started and successfully added to the context.</returns>
        /// <exception cref="ArgumentNullException">thrown in case the specified <paramref name="process"/> is equal to null or there is no process file name set in Process.StartInfo.</exception>
        bool AddProcessIfStarted(Process process, bool isMain);

        /// <summary>
        /// Tries to obtain full executable file name.
        /// </summary>
        /// <param name="processId">Process id.</param>
        /// <param name="processFileName">Found file name.</param>
        /// <returns>True if process is tracked by context and full file name was obtained and not equal to null or empty string, otherwise false.</returns>
        /// <remarks>
        /// <b>This call is only valid for tracked processes that have not yet exited.</b><br/>
        /// The value of <paramref name="processFileName"/> might be null or empty string in case we have failed obtaining full process file name durring process addition.
        /// </remarks>
        bool TryGetProcessFileName(int processId, out string processFileName);

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
