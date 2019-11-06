using System;

namespace SharedLib.Dispatcher
{
    /// <summary>
    /// Dispatcher operation event args base.
    /// </summary>
    public abstract class OperationEventArgsBase : EventArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="param">Parameter.</param>
        protected OperationEventArgsBase(object param)
        {
            Param = param;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="paramBuffer">Parameter buffer.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="count">Count.</param>
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
}
