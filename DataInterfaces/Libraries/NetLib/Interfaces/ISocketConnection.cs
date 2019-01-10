using System.Net;
using System.Net.Sockets;

namespace NetLib
{
    /// <summary>
    /// Socket connection inteface.
    /// </summary>
    public interface ISocketConnection : IConnection
    {
        #region EVENTS

        event NewConnectionDelegate NewConnection;

        event EndpointEventDelegate EndpointBound;

        event EndpointEventDelegate EndpointConnecting;

        event EndpointEventDelegate EndpointConnectionFailed;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets internal socket instance.
        /// </summary>
        Socket Socket { get; }

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
        /// Gets or sets socket send buffer size.
        /// </summary>
        int SendBufferSize { get; set; }

        #endregion

        #region FUNCTIONS

        void Listen(int backlog);

        void Bind(EndPoint localEP);

        void Bind(IPAddress address, int port);

        void Bind(string address, int port);

        void Close(int timeOut);

        void Connect(EndPoint remoteEP);

        void Connect(IPAddress address, int port);

        void Connect(string host, int port);

        void Disconnect(bool reuseSocket);

        int Receive(byte[] buffer);

        int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags);

        int Receive(byte[] buffer, int size, SocketFlags socketFlags);

        int Send(byte[] buffer);        

        int Send(byte[] buffer, int size, SocketFlags socketFlags);

        int Send(byte[] buffer, SocketFlags socketFlags);

        int SendTo(byte[] buffer, ref EndPoint remoteEP);

        #endregion
    }
}
