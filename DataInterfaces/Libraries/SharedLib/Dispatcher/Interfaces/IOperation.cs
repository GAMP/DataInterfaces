using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        event OperationUpdateDelegate OperationUpdate;

        /// <summary>
        /// Occurs on operation state change.
        /// </summary>
        event StateChangeDelegate StateChange;
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
        /// Disposes the operation and any used resources.
        /// </summary>
        void Release();

        /// <summary>
        /// Updates the operation.
        /// </summary>
        /// <param name="parameters">Update parameters.</param>
        void Update(params object[] parameters);

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
        /// Raises state change event and sets operation state.
        /// </summary>
        /// <param name="state">New state.</param>
        /// <param name="param">Parameters.</param>
        void RaiseStateUpdate(OperationState state, params object[] param); 
        #endregion
    }
    #endregion
}
