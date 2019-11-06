using CoreLib;
using System;

namespace NetLib
{
    /// <summary>
    /// Base network connection interface.
    /// </summary>
    public interface IConnection
    {
        #region EVENTS   

        /// <summary>
        /// Occurs on exception.
        /// </summary>
        event EventHandler<ExceptionEventArgs> Exception;

        /// <summary>
        /// Occurs on disconnection.
        /// </summary>
        event EventHandler<ConnectDisconnectEventArgs> EndpointDisconnected;

        /// <summary>
        /// Occurs on connection.
        /// </summary>
        event EventHandler<ConnectDisconnectEventArgs> EndpointConnected;

        /// <summary>
        /// Occurs once all data is received.
        /// </summary>
        event EventHandler<SentReceivedEventArgs> Received;

        /// <summary>
        /// Occurs on data reception.
        /// </summary>
        event EventHandler<SendReceiveArgs> Receiving;

        /// <summary>
        /// Occurs on data sending.
        /// </summary>
        event EventHandler<SendReceiveArgs> Sending;

        /// <summary>
        /// Occurs once all data is sent.
        /// </summary>
        event EventHandler<SentReceivedEventArgs> Sent;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets if chunking enabled.
        /// </summary>
        bool IsChunkingEnabled { get; set; }

        /// <summary>
        /// Gets if chunking supported.
        /// </summary>
        bool IsChunkingSupported { get; }

        /// <summary>
        /// Gets if connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets if connecting.
        /// </summary>
        bool IsConnecting { get; }

        /// <summary>
        /// Gets if receiving.
        /// </summary>
        bool IsReceiving { get; }

        /// <summary>
        /// Gets or sets receive chunk size.
        /// </summary>
        uint ReceiveChunkSize { get; set; }

        /// <summary>
        /// Gets send chunk size.
        /// </summary>
        uint SendChunkSize { get; set; }

        /// <summary>
        /// Gets total received bytes.
        /// </summary>
        ulong BytesReceived { get; }

        /// <summary>
        /// Gets total sent bytes.
        /// </summary>
        ulong BytesSent { get; }

        #endregion

        #region FUNCTIONS

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
        /// <returns>Bytes transfered.</returns>
        int Send(byte[] buffer, int offset, int size);

        #endregion
    }
}
