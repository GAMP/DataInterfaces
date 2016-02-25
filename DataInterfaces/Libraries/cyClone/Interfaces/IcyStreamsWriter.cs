using System;
using System.Collections.Generic;
using System.IO;
using SharedLib.Dispatcher;

namespace CyClone.Core
{
    public interface IcyStreamsWriter : IEnumerable<Stream>
    {
        /// <summary>
        /// Adds the stream to the stream list.
        /// </summary>
        /// <param name="stream">Stream object.</param>
        void Add(System.IO.Stream stream);
        /// <summary>
        /// Adds the stream to the list.
        /// </summary>
        /// <param name="stream">Stream object.</param>
        /// <param name="operation">Control operation.</param>
        void Add(Stream stream, ISyncOperation operation);
        /// <summary>
        /// Closes all the underlying streams.
        /// </summary>
        void Close();
        /// <summary>
        /// Gets the list of failed streams.
        /// </summary>
        Dictionary<Stream, Exception> FailedStreams { get; }
        /// <summary>
        /// Removes the stream from the list.
        /// </summary>
        /// <param name="stream">Stream object.</param>
        void Remove(System.IO.Stream stream);
        /// <summary>
        /// Sets the stream length.
        /// </summary>
        /// <param name="length"></param>
        void SetLength(long length);
        /// <summary>
        /// Seeks the underlying streams.
        /// </summary>
        /// <param name="offset">Offset.</param>
        /// <param name="origin">Origin.</param>
        void Seek(long offset, SeekOrigin origin);
        /// <summary>
        /// Writes the specified byte array buffer to the underlying streams.
        /// </summary>
        /// <param name="buffer">Byte array.</param>
        /// <param name="offset">Start offset.</param>
        /// <param name="count">Length.</param>
        void Write(byte[] buffer, int offset, int count);
        /// <summary>
        /// Write the specified data array to the contained stream list.
        /// </summary>
        /// <param name="buffer">Byte data array.</param>
        /// <param name="offset">Offset in the byte array to begin from.</param>
        /// <param name="count">Ammoount of data to be written.</param>
        /// <param name="streamList">Destination strem list.</param>
        void Write(byte[] buffer, int offset, int count, List<IcyRemoteFileStream> streamList);
        int Count
        {
            get;
        }
        long LastWriteAmount
        {
            get;
        }
        IAsyncResult AsyncWrite(byte[] buffer, int offset, int count, AsyncCallback WriteCallBack, object @state);
        void EndWriteAsync(IAsyncResult result);
        /// <summary>
        /// Selects the internal streams for writing.
        /// </summary>
        void SelectStreams();
        /// <summary>
        /// Resets the writer.
        /// </summary>
        void Reset();
    }
}
