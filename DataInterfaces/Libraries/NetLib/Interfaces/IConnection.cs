using System;
using System.Net;
using System.Net.Sockets;

namespace NetLib
{
    #region IConnection
    /// <summary>
    /// Base network connection interface.
    /// </summary>
    public interface IConnection
    {
        #region EVENTS

        event EndpointEventDelegate EndpointBound;

        event EndpointEventDelegate EndpointConnected;

        event EndpointEventDelegate EndpointConnecting;

        event EndpointEventDelegate EndpointConnectionFailed;

        event ConnectionEventDelegate EndpointDisconnected;

        event ConnectionExceptionDelegate Exception;

        event NewConnectionDelegate NewConnection;

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
        /// Enables or disables keep alive.
        /// </summary>
        bool KeepAlive { get; set; }

        /// <summary>
        /// Gets or sets keep-alive interval.
        /// </summary>
        uint KeepAliveInterval { get; set; }

        /// <summary>
        /// Gets or sets keep-alive timeout.
        /// </summary>
        uint KeepAliveTimeOut { get; set; }

        /// <summary>
        /// Enables or disables socket no-delay.
        /// </summary>
        bool NoDelay { get; set; }

        /// <summary>
        /// Gets or sets socket receive buffer size.
        /// </summary>
        int ReceiveBufferSize { get; set; }

        /// <summary>
        /// Gets or sets receive chunk size.
        /// </summary>
        uint ReceiveChunkSize { get; set; }

        /// <summary>
        /// Gets internal socket instance.
        /// </summary>
        Socket Socket { get; }

        /// <summary>
        /// Gets or sets socket send buffer size.
        /// </summary>
        int SendBufferSize { get; set; }

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
        /// Starts to listen for connections..
        /// </summary>
        /// <param name="backlog">Backlog.</param>
        void Listen(int backlog);

        void Bind(EndPoint localEP);

        void Bind(IPAddress address, int port);

        void Bind(string address, int port);

        void Close();

        void Close(int timeOut);

        void Connect(EndPoint remoteEP);

        void Connect(IPAddress address, int port);

        void Connect(string host, int port);

        void Disconnect(bool reuseSocket);

        void Receive();

        int Receive(byte[] buffer);

        int Receive(byte[] buffer, int offset, int size, System.Net.Sockets.SocketFlags socketFlags);

        int Receive(byte[] buffer, int size, System.Net.Sockets.SocketFlags socketFlags);

        int Send(byte[] buffer);

        int Send(byte[] buffer, int offset, int size, System.Net.Sockets.SocketFlags socketFlags);

        int Send(byte[] buffer, int size, System.Net.Sockets.SocketFlags socketFlags);

        int Send(byte[] buffer, System.Net.Sockets.SocketFlags socketFlags);

        int SendTo(byte[] buffer, ref EndPoint remoteEP);

        void ShutDown(System.Net.Sockets.SocketShutdown how);

        #endregion
    }
    #endregion
}
