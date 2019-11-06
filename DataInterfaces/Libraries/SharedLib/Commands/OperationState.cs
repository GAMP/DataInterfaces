using System;

namespace SharedLib.Commands
{
    /// <summary>
    /// Dispatcher operation states.
    /// </summary>
    [Flags()]
    public enum OperationState : uint
    {
        /// <summary>
        /// Default operation state.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// This flag is set as soon as operation enters executing state.
        /// </summary>
        Started = 1,

        /// <summary>
        /// This flags the operation completion.
        /// </summary>
        /// <remarks>
        /// This should be only set when operation has fully completed.
        /// </remarks>
        Completed = 2,

        /// <summary>
        /// Operation aborted.
        /// </summary>
        Aborted = 16,

        /// <summary>
        /// Operation released.
        /// </summary>
        Released = 32,

        /// <summary>
        /// Operation update.
        /// </summary>
        Update = 128,

        /// <summary>
        /// When calling an execute or update with invalid parameters this flag is used.
        /// </summary>
        InvalidParameters = 512,

        /// <summary>
        /// This is set when operation is failed in case of critical exception for example.
        /// <remarks>
        /// This state should only be set when operation is fully aborted and cannot recover.
        /// This will also lead to operation completeion when SyncOperation class is used.
        /// In case of recoverable error you can simply send an update to the requesting party or log it.
        /// </remarks>
        /// </summary>
        Failed = 1024,

        /// <summary>
        /// This flag is set when the operation was automatically aborted due disconnection.
        /// </summary>
        ConnectionLostAbort = 2048,

        /// <summary>
        /// Connection changed.
        /// </summary>
        ConnectionChange = 4096,
    }
}
