#nullable enable

using CoreLib;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetLib
{
    /// <summary>
    /// Generic network connection interface.
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// Raised on exception.
        /// </summary>
        event EventHandler<ExceptionEventArgs>? Exception;

        /// <summary>
        /// Raised on disconnection.
        /// </summary>
        event EventHandler<ConnectDisconnectEventArgs>? EndpointDisconnected;

        /// <summary>
        /// Raised on connection.
        /// </summary>
        event EventHandler<ConnectDisconnectEventArgs>? EndpointConnected;

        /// <summary>
        /// Raised once all data is sent.
        /// </summary>
        event EventHandler<SentReceivedEventArgs>? Sent;

        /// <summary>
        /// Raised once all data is received.
        /// </summary>
        event EventHandler<SentReceivedEventArgs>? Received;

        /// <summary>
        /// Raised on data reception.
        /// </summary>
        event EventHandler<SendReceiveArgs>? Receiving;

        /// <summary>
        /// Raised on data sending.
        /// </summary>
        event EventHandler<SendReceiveArgs>? Sending;

        /// <summary>
        /// Gets or sets if chunking enabled.
        /// </summary>
        /// <exception cref="NotSupportedException"> thrown on attempt to enable chunking on connection that does not support it.</exception>
        bool IsChunkingEnabled { get; set; }

        /// <summary>
        /// Gets if chunking supported.
        /// </summary>
        bool IsChunkingSupported { get; }

        /// <summary>
        /// Gets if connecting.
        /// </summary>
        bool IsConnecting { get; }

        /// <summary>
        /// Gets if connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets if receiving.
        /// </summary>
        bool IsReceiving { get; }

        /// <summary>
        /// Gets or sets receive chunk size.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        uint ReceiveChunkSize { get; set; }

        /// <summary>
        /// Gets send chunk size.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        uint SendChunkSize { get; set; }

        /// <summary>
        /// Gets total received bytes.
        /// </summary>
        ulong BytesReceived { get; }

        /// <summary>
        /// Gets total sent bytes.
        /// </summary>
        ulong BytesSent { get; }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        void Close();

        /// <summary>
        /// Starts reception.
        /// </summary>
        void Receive();

        /// <summary>
        /// Shuts down the connection.
        /// </summary>
        void ShutDown();

        /// <summary>
        /// Sends data over connection.
        /// </summary>
        /// <param name="buffer">Data buffer.</param>
        /// <param name="offset">Buffer offset.</param>
        /// <param name="size">Size.</param>
        /// <returns>Bytes transferred.</returns>
        int Send(byte[] buffer, int offset, int size);

        /// <summary>
        /// Asynchronously sends data over connection.
        /// </summary>
        /// <param name="buffer">Data buffer.</param>
        /// <param name="offset">Buffer offset.</param>
        /// <param name="size">Size.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Bytes transferred.</returns>
        Task<int> SendAsync(byte[] buffer, int offset, int size, CancellationToken cancellationToken = default);

        /// <summary>
        /// Connects to specified URI.
        /// </summary>
        /// <param name="uri">Connection URI.</param>
        public void Connect(Uri uri);
    }
}
