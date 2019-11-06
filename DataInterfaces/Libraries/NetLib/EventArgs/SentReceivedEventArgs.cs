using System;

namespace NetLib
{
    /// <summary>
    /// <see cref="IConnection"/> Sent/Received event args.
    /// </summary>
    public class SentReceivedEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="size">Size.</param>
        /// <param name="flags">Flags.</param>
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
