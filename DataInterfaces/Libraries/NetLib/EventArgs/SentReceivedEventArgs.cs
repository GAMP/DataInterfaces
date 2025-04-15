using System;
using System.Buffers;

namespace NetLib
{
    /// <summary>
    /// <see cref="IConnection"/> Sent/Received event args.
    /// </summary>
    /// <remarks>
    /// The arguments will only have one of the buffer values set, to check if buffer provided compare buffer values to <see cref="Array.Empty{Byte}"/> or <see cref="ReadOnlySequence{Byte}.Empty"/>.<br></br><br></br>
    /// <b>
    /// Both <see cref="Buffer"/> and <see cref="BufferSequence"/> are only valid during <see cref="IConnection.Received"/> event callback.
    /// </b>
    /// </remarks>
    public class SentReceivedEventArgs : EventArgs
    {
        private readonly ReadOnlySequence<byte> _bufferSequence = ReadOnlySequence<byte>.Empty;
        private readonly byte[] _buffer = Array.Empty<byte>();

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="size">Size.</param>
        /// <param name="flags">Flags.</param>
        public SentReceivedEventArgs(byte[] buffer, int offset, int size, DataFlags flags)
        {
            _buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
            DataOffset = offset;
            DataSize = size;
            DataFlags = flags;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="bufferSequence">Buffer.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="size">Size.</param>
        /// <param name="flags">Flags.</param>
        public SentReceivedEventArgs(ReadOnlySequence<byte> bufferSequence, int offset, int size, DataFlags flags)
        {
            _bufferSequence = bufferSequence;
            DataOffset = offset;
            DataSize = size;
            DataFlags = flags;
        }

        /// <summary>
        /// Gets buffer.
        /// </summary>
        public byte[] Buffer => _buffer;

        /// <summary>
        /// Gets data buffer sequence.
        /// </summary>
        public ReadOnlySequence<byte> BufferSequence => _bufferSequence;

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
    }
}
