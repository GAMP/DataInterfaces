using System;

namespace NetLib
{
    #region ConnectionChangedArgs
    public class ConnectionChangedArgs : EventArgs
    {
        #region CONSTUCTOR
        public ConnectionChangedArgs(IConnection oldConnection, IConnection newConnection)
        {
            this.OldConnection = oldConnection;
            this.NewConnection = newConnection;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets old connection.
        /// <remarks>
        /// This value can be null if no connection previously existed.
        /// </remarks>
        /// </summary>
        public IConnection OldConnection
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets new connection.
        /// </summary>
        public IConnection NewConnection
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region SentReceivedEventArgs
    public class SentReceivedEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        public SentReceivedEventArgs(byte[] buffer, int offset, int size, DataFlags flags)
        {
            this.Buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
            this.DataOffset = offset;
            this.DataSize = size;
            this.DataFlags = flags;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets buffer.
        /// </summary>
        public byte[] Buffer
        {
            get; protected set;
        }

        /// <summary>
        /// Gets data start offset in provided buffer.
        /// </summary>
        public int DataOffset
        {
            get; protected set;
        }

        /// <summary>
        /// Gets total data size.
        /// </summary>
        public int DataSize
        {
            get; protected set;
        }

        /// <summary>
        /// Gets data flags.
        /// </summary>
        public DataFlags DataFlags
        {
            get; protected set;
        }

        #endregion
    }
    #endregion

    #region SendReceiveArgs
    public class SendReceiveArgs : SentReceivedEventArgs
    {
        #region CONSTRUCTOR

        public SendReceiveArgs(byte[] buffer, int offset, int transfered, int totalSize, int dataLeft, DataFlags flags) : base(buffer, offset, totalSize, flags)
        {
            this.Transfered = transfered;
            this.DataLeft = dataLeft;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets transfered amount.
        /// </summary>
        public int Transfered
        {
            get; protected set;
        }

        /// <summary>
        /// Gets total data left.
        /// </summary>
        public int DataLeft
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets if full message received.
        /// </summary>
        public bool IsFullMessage
        {
            get { return this.DataLeft == 0; }
        }

        #endregion
    } 
    #endregion
}
