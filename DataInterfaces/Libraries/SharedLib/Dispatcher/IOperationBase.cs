using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.Commands;
using SharedLib.Dispatcher.Exceptions;

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
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            this.Command = cmd;
            this.Dispatcher = cmd.Dispatcher;
        }
        #endregion

        #region EVENTS

        /// <summary>
        /// Occours when state of the operation has changed.
        /// </summary>
        public event StateChangeDelegate StateChange;

        /// <summary>
        /// Occours when operation has been updated.
        /// </summary>
        public event OperationUpdateDelegate OperationUpdate;

        #endregion

        #region FIELDS
        private OperationState state;
        private IDispatcherCommand command;
        private IMessageDispatcher dispatcher;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the command of this operation.
        /// </summary>
        public IDispatcherCommand Command
        {
            get { return this.command; }
            protected set { this.command = value; }
        }

        /// <summary>
        /// Gets the dispatcher of this operation.
        /// </summary>
        public IMessageDispatcher Dispatcher
        {
            get { return this.dispatcher; }
            protected set { this.dispatcher = value; }
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
                this.RaiseStateUpdate(value);
            }
        }

        /// <summary>
        /// Gets total parameters count of the current command.
        /// </summary>
        public int ParametersCount
        {
            get
            {
                return this.Command != null ? this.Command.ParamsArray.Length : 0;
            }
        }

        /// <summary>
        /// Gets parameters count of the current operation.
        /// </summary>
        public int OpParametersCount
        {
            get
            {          
                return this.ParametersCount > 1 ? this.ParametersCount -1 : 0;
            }
        }

        #endregion

        #region VIRTUAL FUNCTIONS

        public virtual void Abort() { this.RaiseStateUpdate(OperationState.Aborted); }

        public virtual void Release() { this.RaiseStateUpdate(OperationState.Released); }

        public virtual void Execute() { this.RaiseStateUpdate(OperationState.Completed); }

        public virtual void Update(params object[] parameters) { this.RaiseOperationUpdate(parameters); }

        public virtual void Update(byte[] data) { this.RaiseOperationUpdate(data); }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Checks if the current operation command has a valid paramters count.
        /// </summary>
        /// <param name="count">Paramters count.</param>
        /// <returns>True or false.</returns>
        public bool HasParamsCount(int count)
        {
            return this.Command != null && (this.Command.ParamsArray.Length >= count);
        }

        /// <summary>
        /// Checks if the current operation command has a valid paramters count without counting the operation type command.
        /// </summary>
        /// <param name="count">Paramters count.</param>
        /// <returns>True or false.</returns>
        public bool HasOpParametersCount(int count)
        {
            return this.Command != null && ((this.Command.ParamsArray.Length - 1) >= count);
        }

        /// <summary>
        /// Gets if operation parameter count is in range.
        /// </summary>
        /// <param name="low">Low range.</param>
        /// <param name="high">High range.</param>
        /// <returns>True or false.</returns>
        public bool HasOpParametersBetween(int low, int high)
        {
            return this.Command != null && ((this.Command.ParamsArray.Length - 1) >= low & (this.Command.ParamsArray.Length - 1) >= high | high == 0);
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
            if (this.HasOpParametersBetween(0, index))
            {
                return (T)this.Command.ParamsArray[index];
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
        public bool TryGetParameterAt<T>(int index,out T parameter)
        {
            parameter = default(T);

            if (!this.HasOpParametersBetween(0, index))
                return false;

            parameter = (T)this.Command.ParamsArray[index];

            return true;
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
            return this.HasOpParametersBetween(0, index) ? this.Command.ParamsArray[index] is T : false;
        }

        #endregion

        #region PROTECTED FUNCTIONS

        public void RaiseOperationUpdateWithParam(object param)
        {
            var handler = this.OperationUpdate;
            if (handler != null)
                handler(this, param);
        }

        public void RaiseStateUpdateWithParam(OperationState state, object param)
        {
            this.state = state;

            var handler = this.StateChange;
            if (handler != null)
                handler(this, state, param);
        }
        
        public void RaiseOperationUpdate(params object[] parameters)
        {
            this.RaiseOperationUpdateWithParam(parameters);
        }
        
        public void RaiseStateUpdate(OperationState state, params object[] param)
        {
            this.RaiseStateUpdateWithParam(state, param);
        }       
        
        protected void RaiseInvalidParams(params object[] parameters)
        {
            this.RaiseStateUpdateWithParam(OperationState.InvalidParameters, parameters);
        }
        
        protected void RaiseInvalidParamsWithParam(object param)
        {
            this.RaiseStateUpdateWithParam(OperationState.InvalidParameters, param);
        }

        protected void RaiseStarted(params object[] parameters)
        {
            this.RaiseStateUpdateWithParam(OperationState.Started, parameters);
        }

        protected void RaiseStartedWithParam(object param)
        {
            this.RaiseStateUpdateWithParam(OperationState.Started, param);
        }
        
        protected void RaiseFailed(params object[] parameters)
        {
            this.RaiseStateUpdateWithParam(OperationState.Failed, parameters);
        }

        protected void RaiseFailedWithParam(object param)
        {
            this.RaiseStateUpdateWithParam(OperationState.Failed, param);
        }
        
        protected void RaiseCompleted(params object[] parameters)
        {
            this.RaiseStateUpdateWithParam(OperationState.Completed, parameters);
        }

        protected void RaiseCompletedWithParam(object param)
        {
            this.RaiseStateUpdateWithParam(OperationState.Completed, param);
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
