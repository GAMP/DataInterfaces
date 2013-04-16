using System;
using SharedLib.Commands;
namespace SharedLib.Dispatcher
{
    #region ISyncOperation
    public interface ISyncOperation
    {
        #region Functions
        /// <summary>
        /// Aborts the operation.
        /// </summary>
        void Abort();
        /// <summary>
        /// Aborts operation and waits for abort completion.
        /// </summary>
        void AbortEx();
        /// <summary>
        /// Releases the operation.
        /// </summary>
        void Release();
        /// <summary>
        /// Sends operation update.
        /// </summary>
        /// <param name="param">Operation parameters.</param>
        void SendUpdate(params object[] param);
        /// <summary>
        /// Starts the operation.
        /// </summary>
        void Start();
        /// <summary>
        /// Starts the operation and waits for start completion.
        /// </summary>
        void StartEx();
        /// <summary>
        /// Waits for operation completion.
        /// </summary>
        /// <returns>True if operation completed false if operation timed out.</returns>
        bool WaitComplete();
        /// <summary>
        /// Waits for operation completion.
        /// </summary>
        void WaitCompleteEx();
        /// <summary>
        /// Waits for operation update.
        /// </summary>
        /// <returns>True if operation update received false if operation timed out.</returns>
        bool WaitUpdate();
        /// <summary>
        /// Waits for operation update.
        /// </summary>
        void WaitUpdateEx();
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the operation functions timeout.
        /// <remarks>This is global parameter for all operation functions.</remarks>
        /// </summary>
        int Timeout { get; set; }
        /// <summary>
        /// Gets the command instance used for this operation.
        /// </summary>
        IDispatcherCommand Command { get; }
        /// <summary>
        /// Gets the instance of last data received.
        /// </summary>
        object[] Data { get; }
        /// <summary>
        /// Gets the message dispatcher of this operation.
        /// </summary>
        IMessageDispatcher Dispatcher { get; }
        /// <summary>
        /// Gets if operation was previously aborted.
        /// </summary>
        bool IsAborted { get; }
        /// <summary>
        /// Gets if operation was previously completed.
        /// </summary>
        bool IsCompleted { get; }
        /// <summary>
        /// Gets if operation was previously failed.
        /// </summary>
        bool IsFailed { get; }
        /// <summary>
        /// Gets if operation was previously released.
        /// </summary>
        bool IsReleased { get; }
        /// <summary>
        /// Gets if operation was previously started.
        /// </summary>
        bool IsStarted { get; }
        #endregion
    } 
    #endregion
}
