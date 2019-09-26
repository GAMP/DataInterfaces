using System;

namespace NetLib
{
    public class SentReceivedEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        public SentReceivedEventArgs(byte[] buffer, int offset, int size, DataFlags flags)
        {
            Buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
            DataOffset = offset;
            DataSize = size;
            DataFlags = flags;
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
}
