using SharedLib;
using System;

namespace Client
{
    /// <summary>
    /// Execution context arguments.
    /// </summary>
    [Serializable()]
    public class ExecutionContextStateArgs : EventArgs
    {
        #region CONSTRUCTOR

        public ExecutionContextStateArgs(int exeId, ContextExecutionState newState,
            ContextExecutionState oldState,
            object stateObject)
        {
            ExecutableId = exeId;
            NewState = newState;
            OldState = oldState;
            StateObject = stateObject;
        }

        public ExecutionContextStateArgs(int exeId, ContextExecutionState newState,
          ContextExecutionState oldState)
            : this(exeId, newState, oldState, null)
        {
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets executable id.
        /// </summary>
        public int ExecutableId
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the instance of the state object.
        /// </summary>
        public object StateObject
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the new state.
        /// </summary>
        public ContextExecutionState NewState
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the old state.
        /// </summary>
        public ContextExecutionState OldState
        {
            get;
            protected set;
        }

        #endregion
    }
}
