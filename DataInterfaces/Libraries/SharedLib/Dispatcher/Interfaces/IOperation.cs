using System;
using SharedLib.Commands;

namespace SharedLib.Dispatcher
{
    #region IOperation
    /// <summary>
    /// IOperation interface.
    /// </summary>
    public interface IOperation
    {
        #region EVENTS
        /// <summary>
        /// Occurs on operation update.
        /// </summary>
        event EventHandler<OperationUpdateArgs> OperationUpdate;

        /// <summary>
        /// Occurs on operation state change.
        /// </summary>
        event EventHandler<OperationStateEventArgs> StateChange;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets the operations parent command.
        /// </summary>
        IDispatcherCommand Command
        {
            get;
        }

        /// <summary>
        /// Gets or sets operation state.
        /// </summary>
        OperationState State
        {
            get;
            set;
        }

        /// <summary>
        /// Gets operation dispatcher.
        /// </summary>
        IMessageDispatcher Dispatcher
        {
            get;
        }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Aborts the operation.
        /// </summary>
        void Abort();

        /// <summary>
        /// Releases the operation.
        /// </summary>
        void Release();

        /// <summary>
        /// Updates the operation.
        /// </summary>
        /// <param name="parameters">Update parameters.</param>
        void Update(params object[] parameters);

        /// <summary>
        /// Updates operation with binary data.
        /// </summary>
        /// <param name="data">Byte array parameters.</param>
        void Update(byte[] data);

        /// <summary>
        /// Execute the operation.
        /// </summary>
        void Execute();

        /// <summary>
        /// Raises operation update event.
        /// </summary>
        /// <param name="param">Parameters.</param>
        void RaiseOperationUpdate(params object[] param);

        /// <summary>
        /// Raises operation update event.
        /// </summary>
        /// <param name="paramBuffer">Parameter buffer.</param>
        /// <param name="offset">Start offset.</param>
        /// <param name="count">Count.</param>
        void RaiseOperationUpdate(byte[] paramBuffer, int offset, int count);

        /// <summary>
        /// Raises state change event and sets operation state.
        /// </summary>
        /// <param name="state">New state.</param>
        /// <param name="param">Parameters.</param>
        void RaiseOperationStateChange(OperationState state, params object[] param);

        /// <summary>
        /// Raises operation update with parameter/
        /// </summary>
        /// <param name="param">Parameter instance.</param>
        void RaiseOperationUpdateWithParam(object param);

        /// <summary>
        /// Raises state change event and sets operation state. 
        /// </summary>
        /// <param name="state">New state.</param>
        /// <param name="param">Parameter instance.</param>
        void RaiseOperationStateChangeWithParam(OperationState state, object param);

        #endregion
    }
    #endregion
}
