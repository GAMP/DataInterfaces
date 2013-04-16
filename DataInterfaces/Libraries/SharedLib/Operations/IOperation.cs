using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.Commands;

namespace SharedLib.Dispatcher
{
    #region Delegates
    public delegate void StateChangeDelegate(IOperation sender, OperationState state, params object[] param);
    public delegate void OperationUpdateDelegate(IOperation sender, params object[] param);
    #endregion

    #region IOperation
    /// <summary>
    /// IOperation interface.
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// Gets operation id.
        /// </summary>
        int Id
        {
            get;
        }

        /// <summary>
        /// Gets or Sets the operations parent command.
        /// </summary>
        IDispatcherCommand Command
        {
            get;
        }

        /// <summary>
        /// Gets or Sets if operation can be aborted.
        /// </summary>
        bool CanAbort{ get; }

        /// <summary>
        /// Aborts the current operation.
        /// </summary>
        /// <returns></returns>
        void Abort();

        /// <summary>
        /// Disposes the operation and any used resources.
        /// </summary>
        void Release();

        void Update(params object[] parameters);

        /// <summary>
        /// Execute the assigned operation in sync mode.
        /// </summary>
        /// <returns></returns>
        void Execute();

        /// <summary>
        /// Execute the assigned operation in sync mode and passese the command parameters.
        /// </summary>
        /// <returns></returns>
        void Execute(params object[] param);

        /// <summary>
        /// Gets or sets state of the current operation.
        /// </summary>
        OperationState State
        {
            get;
            set;
        }

        /// <summary>
        /// Occurs on operation update.
        /// </summary>
        event OperationUpdateDelegate OperationUpdate;

        /// <summary>
        /// Occurs on operation state change.
        /// </summary>
        event StateChangeDelegate StateChange;

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

        /// <summary>
        /// Gets operation dispatcher.
        /// </summary>
        IMessageDispatcher Dispatcher
        {
            get;
        }
    } 
    #endregion

}
