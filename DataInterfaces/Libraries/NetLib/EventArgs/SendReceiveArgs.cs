namespace NetLib
{
    /// <summary>
    /// Send receive args.
    /// </summary>
    public class SendReceiveArgs : SentReceivedEventArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="transfered">Transfered.</param>
        /// <param name="totalSize">Total size.</param>
        /// <param name="dataLeft">Data left.</param>
        /// <param name="flags">Flags.</param>
        public SendReceiveArgs(byte[] buffer, int offset, int transfered, int totalSize, int dataLeft, DataFlags flags) : base(buffer, offset, totalSize, flags)
        {
            Transfered = transfered;
            DataLeft = dataLeft;
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
            get { return DataLeft == 0; }
        }

        #endregion
    }
}
