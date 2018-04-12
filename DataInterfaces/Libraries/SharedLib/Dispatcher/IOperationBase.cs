using System;
using SharedLib.Commands;
using SharedLib.Dispatcher.Exceptions;
using CoreLib;

namespace SharedLib.Dispatcher
{
    #region IOperationBase
    /// <summary>
    /// Dispatcher operation base class.
    /// </summary>
    public class IOperationBase : IOperation
    {
        #region CONSTRUCTORS
        public IOperationBase(IDispatcherCommand cmd)
        {
            this.Command = cmd ?? throw new ArgumentNullException(nameof(cmd));
            this.Dispatcher = cmd.Dispatcher;
        }
        #endregion

        #region EVENTS

        /// <summary>
        /// Occours when state of the operation has changed.
        /// </summary>
        public event EventHandler<OperationStateEventArgs> StateChange;

        /// <summary>
        /// Occours when operation has been updated.
        /// </summary>
        public event EventHandler<OperationUpdateArgs> OperationUpdate;

        #endregion

        #region FIELDS
        private OperationState state;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the command of this operation.
        /// </summary>
        public IDispatcherCommand Command
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the dispatcher of this operation.
        /// </summary>
        public IMessageDispatcher Dispatcher
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the current state of the operation.
        /// </summary>
        public virtual OperationState State
        {
            get { return this.state; }
            set
            {
                this.state = value;
                this.RaiseOperationStateChange(value);
            }
        }

        /// <summary>
        /// Gets total parameters count of the current command.
        /// </summary>
        public int ParametersCount
        {
            get
            {
                return this.Command.ParamsArray.Length;
            }
        }

        #endregion

        #region VIRTUAL FUNCTIONS

        /// <summary>
        /// Aborts operation.
        /// </summary>
        public virtual void Abort() { RaiseOperationStateChange(OperationState.Aborted); }

        /// <summary>
        /// Releases operation.
        /// </summary>
        public virtual void Release() { RaiseOperationStateChange(OperationState.Released); }

        /// <summary>
        /// Executes operation.
        /// </summary>
        public virtual void Execute() { RaiseOperationStateChange(OperationState.Completed); }

        /// <summary>
        /// Updates operation.
        /// </summary>
        /// <param name="parameters">Operation parameters.</param>
        public virtual void Update(params object[] parameters) { RaiseOperationUpdateWithParam(parameters); }

        /// <summary>
        /// Updates operation.
        /// </summary>
        /// <param name="data">Operation data parameters.</param>
        public virtual void Update(byte[] data) { RaiseOperationUpdateWithParam(data); }

        /// <summary>
        /// Raises operation update event.
        /// </summary>
        /// <param name="parameters">Optional parameters.</param>
        public void RaiseOperationUpdate(params object[] parameters)
        {
            RaiseOperationUpdateWithParam(parameters);
        }     

        /// <summary>
        /// Raises operation update.
        /// </summary>
        /// <param name="paramBuffer">Param buffer.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="count">Count.</param>
        public void RaiseOperationUpdate(byte[] paramBuffer, int offset, int count)
        {
            paramBuffer.ThrowIfInvalid(offset, count);
            RaiseOperationUpdateWithArgs(new OperationUpdateArgs(paramBuffer, offset, count));
        }

        /// <summary>
        /// Raises operation update event.
        /// </summary>
        /// <param name="param">Optional parameter.</param>
        public virtual void RaiseOperationUpdateWithParam(object param)
        {
            RaiseOperationUpdateWithArgs(new OperationUpdateArgs(param));
        }

        /// <summary>
        /// Raises operation state change.
        /// </summary>
        /// <param name="state">New state.</param>
        public virtual void RaiseOperationStateChange(OperationState state)
        {
            RaiseOperationStateChangeWithParam(state);
        }

        /// <summary>
        /// Raises operation state change event.
        /// </summary>
        /// <param name="state">New state.</param>
        /// <param name="param">Optional parameters.</param>
        public virtual void RaiseOperationStateChange(OperationState state, params object[] param)
        {
            RaiseOperationStateChangeWithParam(state, param);
        }

        /// <summary>
        /// Raises operation state event.
        /// </summary>
        /// <param name="state">New state.</param>
        /// <param name="param">Optional parameter.</param>
        public virtual void RaiseOperationStateChangeWithParam(OperationState state, object param = null)
        {
            var previousState = this.state;
            this.state = state;

           RaiseOperationStateChangeWithArgs(new OperationStateEventArgs(previousState, state, param));
        }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Checks if the current operation command has exact paramters count.
        /// </summary>
        /// <param name="count">Paramters count.</param>
        /// <returns>True or false.</returns>
        public bool HasParamsCount(int count)
        {
            return Command.ParamsArray.Length >= count;
        }

        /// <summary>
        /// Checks if the current operation command has a exact operation paramters count.
        /// </summary>
        /// <param name="count">Paramters count.</param>
        /// <returns>True or false.</returns>
        public bool HasOpParametersCount(int count)
        {
            return Command.ParamsArray.Length - 1 >= count;
        }

        /// <summary>
        /// Gets if operation parameter count is in range.
        /// </summary>
        /// <param name="lowIndex">Low range.</param>
        /// <param name="highIndex">High range.</param>
        /// <returns>True or false.</returns>
        public bool HasOpParametersBetween(int lowIndex, int highIndex)
        {
            var parametersLength = this.Command.ParamsArray.Length - 1;
            return parametersLength >= lowIndex && parametersLength >= highIndex;
        }

        /// <summary>
        /// Gets the parameter of type T at specified index.
        /// </summary>
        /// <typeparam name="T">Parameter type.</typeparam>
        /// <param name="index">Paramter index.</param>
        /// <remarks>
        /// If there are no parameter at specified index default value of T type is returned.
        /// </remarks>
        /// <returns>Parameter of type T.</returns>
        public T GetParameterAt<T>(int index)
        {
            if (HasOpParametersBetween(0, index))
            {
                return (T)Command.ParamsArray[index];
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Tries to obtain parameter at specified index.
        /// </summary>
        /// <typeparam name="T">Parameter type.</typeparam>
        /// <param name="index">Parameter index.</param>
        /// <param name="parameter">Parameter value.</param>
        /// <returns>True or false.</returns>
        public bool TryGetParameterAt<T>(int index, out T parameter)
        {
            parameter = default(T);

            if (!HasOpParametersBetween(0, index))
                return false;

            if (Command.ParamsArray[index] is T value)
            {
                parameter = value;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Tries to obtain parameter at specified index.
        /// </summary>
        /// <typeparam name="T">Parameter type.</typeparam>
        /// <param name="parameters">Parameters array.</param>
        /// <param name="index">Parameter index.</param>
        /// <param name="parameter">Parameter value.</param>
        /// <returns>True or false.</returns>
        public bool TryGetParameterAt<T>(object[] parameters, int index, out T parameter)
        {
            parameter = default(T);

            if (parameters == null)
                return false;

            var parametersLength = parameters.Length - 1;

            if (parametersLength < 0 || parametersLength < index)
                return false;

            if (parameters[index] is T value)
            {
                parameter = value;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the parameter at specified index.
        /// </summary>
        /// <typeparam name="T">Parameter type.</typeparam>
        /// <param name="index">Parameter index.</param>
        /// <param name="parameters">Parameters array.</param>
        /// <returns>Found parameter value.</returns>
        public T GetParameterAt<T>(int index, object[] parameters)
        {
            return (T)parameters[index];
        }

        /// <summary>
        /// Gets if parameter at specified index equals specified type.
        /// </summary>
        /// <typeparam name="T">Parameter type.</typeparam>
        /// <param name="index">Parameter index.</param>
        /// <returns>True or false.</returns>
        public bool IsParameterAtEquals<T>(int index)
        {
            return HasOpParametersBetween(0, index) ? Command.ParamsArray[index] is T : false;
        }

        /// <summary>
        /// Checks if parameter at specified index equal to null.
        /// </summary>
        /// <param name="index">Parameter index.</param>
        /// <remarks>
        /// This function will return false if there is no parameter at specified index.
        /// </remarks>
        /// <returns>True or false.</returns>
        public bool IsParameterAtEqualsNull(int index)
        {
            return HasOpParametersBetween(0, index) ? Command.ParamsArray[index] == null : false;
        }

        #endregion

        #region PROTECTED FUNCTIONS

        protected void RaiseOperationStateChangeWithArgs(OperationStateEventArgs args)
        {
            StateChange?.Invoke(this, args);
        }

        protected void RaiseOperationUpdateWithArgs(OperationUpdateArgs args)
        {
            OperationUpdate?.Invoke(this, args);
        }

        protected void RaiseInvalidParams()
        {
            RaiseInvalidParamsWithParam();
        }

        protected void RaiseInvalidParamsWithParam(object param = null)
        {
            RaiseOperationStateChangeWithParam(OperationState.InvalidParameters, param);
        }

        protected void RaiseInvalidParams(params object[] parameters)
        {
            RaiseInvalidParamsWithParam(parameters);
        }

        protected void RaiseStarted()
        {
            RaiseStartedWithParam();
        }

        protected void RaiseStartedWithParam(object param = null)
        {
            RaiseOperationStateChangeWithParam(OperationState.Started, param);
        }

        protected void RaiseStarted(params object[] parameters)
        {
            RaiseStartedWithParam(parameters);
        }

        protected void RaiseFailed()
        {
            RaiseFailedWithParam();
        }

        protected void RaiseFailedWithParam(object param = null)
        {
            RaiseOperationStateChangeWithParam(OperationState.Failed, param);
        }

        protected void RaiseFailed(params object[] parameters)
        {
            RaiseFailedWithParam(parameters);
        }

        protected void RaiseCompleted()
        {
            RaiseCompletedWithParam();
        }

        protected void RaiseCompletedWithParam(object param = null)
        {
            RaiseOperationStateChangeWithParam(OperationState.Completed, param);
        }

        protected void RaiseCompleted(params object[] parameters)
        {
            RaiseCompletedWithParam(parameters);
        }

        /// <summary>
        /// Throws access denied exception.
        /// </summary>
        protected void ThrowAccessDenied()
        {
            throw new AccessDeniedException();
        }

        #endregion        
    }
    #endregion
}
