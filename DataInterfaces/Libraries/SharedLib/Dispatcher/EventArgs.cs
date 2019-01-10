using NetLib;
using SharedLib.Commands;
using SharedLib.Dispatcher.Exceptions;
using System;

namespace SharedLib.Dispatcher
{
    #region OperationEventArgsBase
    public abstract class OperationEventArgsBase : EventArgs
    {
        #region CONSTRUCTOR

        protected OperationEventArgsBase(object param)
        {
            Param = param;
        }

        protected OperationEventArgsBase(byte[] paramBuffer, int offset, int count)
        {
            Param = paramBuffer;
            ParamBuffer = paramBuffer;
            BufferOffset = offset;
            BufferCount = count;
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
    #endregion

    #region OperationStateEventArgs
    public class OperationStateEventArgs : OperationEventArgsBase
    {
        #region CONSTRUCTOR

        public OperationStateEventArgs(OperationState previous, OperationState current, object param) :
            base(param)
        {
            CurrentState = current;
            PreviousState = previous;
        }

        public OperationStateEventArgs(OperationState previous, OperationState current, byte[] buffer, int offset, int count) :
            base(buffer, offset, count)
        {
            CurrentState = current;
            PreviousState = previous;
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
    #endregion

    #region OperationUpdateArgs
    public class OperationUpdateArgs : OperationEventArgsBase
    {
        #region CONSTRUCTOR

        public OperationUpdateArgs(object param) : base(param)
        { }

        public OperationUpdateArgs(byte[] buffer, int offset, int count) : base(buffer, offset, count)
        { }

        #endregion
    } 
    #endregion

    #region DispatcherExceptionEventArgs
    public class DispatcherExceptionEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public DispatcherExceptionEventArgs(DispatcherException exception, IDispatcherCommand command = default)
        {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));
            Command = command;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets dispatcher exception.
        /// </summary>
        public DispatcherException Exception
        {
            get; protected set;
        }

        /// <summary>
        /// Gets optional command associated with exception event.
        /// </summary>
        public IDispatcherCommand Command
        {
            get; protected set;
        }

        #endregion
    }
    #endregion

    #region DispatcherStateEventArgs
    public class DispatcherStateEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public DispatcherStateEventArgs(bool state)
        {
            IsConnected = state;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if dispatcher is connected.
        /// </summary>
        public bool IsConnected
        {
            get; protected set;
        }

        #endregion
    }
    #endregion

    #region DispatcherConnectionEventArgs
    public class DispatcherConnectionEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public DispatcherConnectionEventArgs(IConnection connection)
        {
            Connection = connection ?? throw new ArgumentException(nameof(connection));
        } 
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets associated connection.
        /// </summary>
        public IConnection Connection
        {
            get; protected set;
        }

        #endregion
    } 
    #endregion
}
