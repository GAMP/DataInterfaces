using CoreLib;
using System;

namespace NetLib
{
    #region IConnection
    /// <summary>
    /// Base network connection interface.
    /// </summary>
    public interface IConnection
    {
        #region EVENTS   

        event EventHandler<ExceptionEventArgs> Exception;

        event EventHandler<ConnectDisconnectEventArgs> EndpointDisconnected;

        event EventHandler<ConnectDisconnectEventArgs> EndpointConnected;

        event EventHandler<SentReceivedEventArgs> Received;

        event EventHandler<SendReceiveArgs> Receiving;

        event EventHandler<SendReceiveArgs> Sending;

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

        void Close();

        void Receive();   

        void ShutDown();

        int Send(byte[] buffer, int offset, int size);

        #endregion
    }
    #endregion
}
