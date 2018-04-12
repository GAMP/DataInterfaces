using SharedLib.Commands;
using System;

namespace SharedLib.Dispatcher
{
    public abstract class OperationEventArgsBase :EventArgs
    {
        #region CONSTRUCTOR

        protected OperationEventArgsBase(object param)
        {
            this.Param = param;
        }

        protected OperationEventArgsBase(byte[] paramBuffer, int offset, int count)
        {
            this.Param = paramBuffer;
            this.ParamBuffer = paramBuffer;
            this.BufferOffset = offset;
            this.BufferCount = count;
        } 

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets param object.
        /// </summary>
        public object Param
        {
            get; protected set;
        }

        /// <summary>
        /// Gets param buffer.
        /// </summary>
        public byte[] ParamBuffer
        {
            get; protected set;
        }

        /// <summary>
        /// Gets param buffer start offset.
        /// </summary>
        public int BufferOffset
        {
            get; protected set;
        }

        /// <summary>
        /// Gets param buffer count.
        /// </summary>
        public int BufferCount
        {
            get; protected set;
        } 

        #endregion
    }

    public class OperationStateEventArgs : OperationEventArgsBase
    {
        #region CONSTRUCTOR

        public OperationStateEventArgs(OperationState previous, OperationState current,object param) : 
            base(param)
        {
            this.CurrentState = current;
            this.PreviousState = previous;
        }

        public OperationStateEventArgs(OperationState previous, OperationState current,byte[] buffer, int offset, int count) :
            base(buffer, offset, count)
        {
            this.CurrentState = current;
            this.PreviousState = previous;
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

    public class OperationUpdateArgs : OperationEventArgsBase
    {
        #region CONSTRUCTOR

        public OperationUpdateArgs(object param) : base(param)
        { }

        public OperationUpdateArgs(byte[] buffer, int offset, int count) : base(buffer, offset, count)
        { } 

        #endregion
    }
}
