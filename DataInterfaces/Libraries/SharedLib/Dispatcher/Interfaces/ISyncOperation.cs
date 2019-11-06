using SharedLib.Commands;
using System.Threading.Tasks;
using System.Threading;

namespace SharedLib.Dispatcher
{
    /// <summary>
    /// Dispatcher operation interface implementation.
    /// </summary>
    public interface ISyncOperation
    {
        #region FUNCTIONS

        /// <summary>
        /// Starts the operation.
        /// </summary>
        void Start();

        /// <summary>
        /// Starts the operation and waits for start completion.
        /// </summary>
        void StartEx();

        /// <summary>
        /// Starts the operation and waits for start completion asynchronously.
        /// </summary>
        Task StartAsync();

        /// <summary>
        /// Starts the operation and waits for start completion asynchronously.
        /// <param name="token">Cancellation token.</param>
        /// </summary>
        Task StartAsync(CancellationToken token);

        /// <summary>
        /// Aborts the operation.
        /// </summary>
        void Abort();

        /// <summary>
        /// Aborts operation and waits for abort completion.
        /// </summary>
        void AbortEx();

        /// <summary>
        /// Aborts operation and waits for abort completion asynchronously.
        /// </summary>
        Task AbortAsync();

        /// <summary>
        /// Aborts operation and waits for abort completion asynchronously.
        /// <param name="token">Cancellation token.</param>
        /// </summary>
        Task AbortAsync(CancellationToken token);

        /// <summary>
        /// Releases the operation.
        /// </summary>
        void Release();

        /// <summary>
        /// Releases the operation and waits for release completion asynchronously.
        /// </summary>
        Task ReleaseAsync();

        /// <summary>
        /// Releases the operation and waits for release completion asynchronously.
        /// <param name="token">Cancellation token.</param>
        /// </summary>
        Task ReleaseAsync(CancellationToken token);

        /// <summary>
        /// Sends operation update.
        /// </summary>
        /// <param name="param">Operation parameters.</param>
        void SendUpdate(params object[] param);

        /// <summary>
        /// Sends operation update asynchronously.
        /// </summary>
        /// <param name="param">Update parameters.</param>
        Task SendUpdateAsync(params object[] param);

        /// <summary>
        /// Sends operation update.
        /// </summary>
        /// <param name="param">Update parameters.</param>
        void SendUpdate(object param);

        /// <summary>
        /// Sends operation update asynchronously.
        /// </summary>
        /// <param name="param">Update parameters.</param>
        Task SendUpdateAsync(object param);

        /// <summary>
        /// Sends operation update.
        /// </summary>
        /// <param name="buffer">Parameters buffer.</param>
        /// <param name="offset">Start offset.</param>
        /// <param name="count">Count.</param>
        void SendUpdate(byte[] buffer, int offset, int count);

        /// <summary>
        /// Sends operation update asynchronously.
        /// </summary>
        /// <param name="buffer">Parameters buffer.</param>
        /// <param name="offset">Start offset.</param>
        /// <param name="count">Count.</param>
        Task SendUpdateAsync(byte[] buffer, int offset, int count);

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
        /// Waits for operation completion asynchronously.
        /// </summary>
        Task WaitCompleteAsync();

        /// <summary>
        /// Waits for operation completion asynchronously.
        /// <param name="token">Cancellation token.</param>
        /// </summary>
        Task WaitCompleteAsync(CancellationToken token);

        /// <summary>
        /// Waits for operation update.
        /// </summary>
        /// <returns>True if operation update received false if operation timed out.</returns>
        bool WaitUpdate();

        /// <summary>
        /// Waits for operation update.
        /// </summary>
        void WaitUpdateEx();

        /// <summary>
        /// Waits for operation update asynchronously.
        /// </summary>
        Task WaitUpdateAsync();

        /// <summary>
        /// Waits for operation update asynchronously.
        /// <param name="token">Cancellation token.</param>
        /// </summary>
        Task WaitUpdateAsync(CancellationToken token);

        /// <summary>
        /// Validates operation state and throws appropriate exception.
        /// </summary>
        void Validate();

        #endregion

        #region PROPERTIES

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
        /// Gets data array instance of last update received.
        /// </summary>
        object[] Data { get; }

        /// <summary>
        /// Gets data instance of last update received.
        /// </summary>
        object DataObject { get; }

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
}
