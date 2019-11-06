using SharedLib.Commands;

namespace SharedLib.Dispatcher
{
    /// <summary>
    /// Operation state event args.
    /// </summary>
    public class OperationStateEventArgs : OperationEventArgsBase
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="previousState">Previous state.</param>
        /// <param name="currentState">Current state.</param>
        /// <param name="param">Operation parameter.</param>
        public OperationStateEventArgs(OperationState previousState, OperationState currentState, object param) :
            base(param)
        {
            CurrentState = currentState;
            PreviousState = previousState;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="previousState">Previous state.</param>
        /// <param name="currentState">Current state.</param>
        /// <param name="buffer">Buffer.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="count">Count.</param>
        public OperationStateEventArgs(OperationState previousState, OperationState currentState, byte[] buffer, int offset, int count) :
            base(buffer, offset, count)
        {
            CurrentState = currentState;
            PreviousState = previousState;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets current state.
        /// </summary>
        public OperationState CurrentState
        {
            get; protected set;
        }

        /// <summary>
        /// Gets previous state.
        /// </summary>
        public OperationState PreviousState
        {
            get; protected set;
        }

        #endregion
    }
}
