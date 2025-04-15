namespace NetLib
{
    /// <summary>
    /// Send receive args.
    /// </summary>
    public sealed class SendReceiveArgs : SentReceivedEventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="transferred">Transferred.</param>
        /// <param name="totalSize">Total size.</param>
        /// <param name="dataLeft">Data left.</param>
        /// <param name="flags">Flags.</param>
        public SendReceiveArgs(byte[] buffer, int offset, int transferred, int totalSize, int dataLeft, DataFlags flags) : base(buffer, offset, totalSize, flags)
        {
            Transferred = transferred;
            DataLeft = dataLeft;
        }

        /// <summary>
        /// Gets transferred amount.
        /// </summary>
        public int Transferred
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
    }
}
