﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.Commands;

namespace SharedLib.Dispatcher
{
    #region IOperationBase
    /// <summary>
    /// Dispatcher operation base class.
    /// </summary>
    public class IOperationBase : ItemObject, IOperation
    {
        #region Constructors
        public IOperationBase(IDispatcherCommand cmd)
        {
            #region Validation
            if (cmd == null)
                throw new ArgumentNullException("Cmd", "Command instance may not be null");            
            #endregion

            this.Command = cmd;
            this.Dispatcher = cmd.Dispatcher;
        }
        #endregion

        #region Events

        /// <summary>
        /// Occours when state of the operation has changed.
        /// </summary>
        public event StateChangeDelegate StateChange;

        /// <summary>
        /// Occours when operation has been updated.
        /// </summary>
        public event OperationUpdateDelegate OperationUpdate;

        #endregion

        #region Fileds
        private OperationStateSupport supportedStates;
        private OperationState state;
        private IDispatcherCommand command;
        private IMessageDispatcher dispatcher;
        #endregion

        #region Properties

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
        /// Gets if operation can abort.
        /// </summary>
        public virtual bool CanAbort
        {
            get { return (this.SupportedStates & OperationStateSupport.Abort) == OperationStateSupport.Abort; }
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
                this.RaiseStateUpdate();
            }
        }

        /// <summary>
        /// Gets the supported states of this operation.
        /// </summary>
        public OperationStateSupport SupportedStates
        {
            get { return this.supportedStates; }
            protected set
            {
                this.supportedStates = value;
            }
        }

        /// <summary>
        /// Gets the parameters count of the current operation.
        /// </summary>
        public int ParametersCount
        {
            get
            {
                if (this.Command != null)
                {
                    return Command.ParamsArray.Length;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Gets the parameters count of the current operation.
        /// </summary>
        public int OpParametersCount
        {
            get
            {
                if (this.Command != null)
                {
                    if (this.ParametersCount <= 1)
                    {
                        return 0;
                    }
                    else
                    {
                        return Command.ParamsArray.Length - 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Raises operation update.
        /// </summary>
        /// <param name="param">Parameters.</param>
        public void RaiseOperationUpdate(params object[] param)
        {
            if (this.OperationUpdate != null)
            {
                this.OperationUpdate(this, param);
            }
        }

        /// <summary>
        /// Raises state update and sets it as current state.
        /// </summary>
        /// <param name="state">New state.</param>
        /// <param name="param">Parameters.</param>
        public void RaiseStateUpdate(OperationState state, params object[] param)
        {
            this.state = state;
            if (this.StateChange != null)
            {
                this.StateChange(this, state, param);
            }
        }

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
        public bool HasOpParametersBetwen(int low, int high)
        {
            return this.Command != null && ((this.Command.ParamsArray.Length - 1) >= low & (this.Command.ParamsArray.Length - 1) >= high | high == 0);
        }

        /// <summary>
        /// Gets the parameter of type T at specified index.
        /// </summary>
        /// <typeparam name="T">Parameter type.</typeparam>
        /// <param name="index">Paramter index.</param>
        /// <returns>Parameter of type T.</returns>
        public T GetParameterAt<T>(int index)
        {
            if (this.HasOpParametersBetwen(0, index))
            {
                return (T)this.Command.ParamsArray[index];
            }
            else
            {
                return default(T);
            }
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
            return this.HasOpParametersBetwen(0, index) ? this.Command.ParamsArray[index] is T : false;
        }

        #endregion

        #region Protected Functions

        /// <summary>
        /// Raises and sets invalid parameters state state
        /// </summary>
        protected void RaiseInvalidParams(params object[] parameters)
        {
            this.RaiseStateUpdate(OperationState.InvalidParameters, parameters);
        }

        /// <summary>
        ///Raises and sets starter state
        /// </summary>
        protected void RaiseStarted(params object[] parameters)
        {
            this.RaiseStateUpdate(OperationState.Started, parameters);
        }

        /// <summary>
        /// Raises and sets failed state.
        /// </summary>
        protected void RaiseFailed(params object[] parameters)
        {
            this.RaiseStateUpdate(OperationState.Failed, parameters);
        }

        /// <summary>
        /// Raises and set completed state.
        /// </summary>
        protected void RaiseCompleted(params object[] parameters)
        {
            this.RaiseStateUpdate(OperationState.Completed, parameters);
        }

        /// <summary>
        /// Raises state update.
        /// <remarks>Current operation state is raised.</remarks>
        /// </summary>
        protected void RaiseStateUpdate()
        {
            this.RaiseStateUpdate(this.State);
        }

        #endregion

        #region Virtual Functions

        public virtual void Abort(){this.RaiseStateUpdate(OperationState.Aborted);}

        public virtual void Release(){this.RaiseStateUpdate(OperationState.Released);}

        public virtual void Update(params object[] parameters) { }

        public virtual void Execute(){ }

        public virtual void Execute(params object[] param) { }

        #endregion
    }
    #endregion
}
