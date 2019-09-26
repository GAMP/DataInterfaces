namespace NetLib
{
    public class SendReceiveArgs : SentReceivedEventArgs
    {
        #region CONSTRUCTOR

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
