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

        /// <summary>
        /// Rised on new connection.
        /// </summary>
        event NewConnectionDelegate NewConnection;

        /// <summary>
        /// Raised on endpoint bound.
        /// </summary>
        event EndpointEventDelegate EndpointBound;

        /// <summary>
        /// Raised on endpoint connecting.
        /// </summary>
        event EndpointEventDelegate EndpointConnecting;

        /// <summary>
        /// Raised on endpoint connection failure.
        /// </summary>
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

        /// <summary>
        /// Starts listening.
        /// </summary>
        /// <param name="backlog">Connection backlog.</param>
        void Listen(int backlog);

        /// <summary>
        /// Binds socket to specified endpoint.
        /// </summary>
        /// <param name="localEP">Endpoint.</param>
        void Bind(EndPoint localEP);

        /// <summary>
        /// Binds socket to specified address and port.
        /// </summary>
        /// <param name="address">IP Address.</param>
        /// <param name="port">Port.</param>
        void Bind(IPAddress address, int port);

        /// <summary>
        /// Binds socket to specified address and port.
        /// </summary>
        /// <param name="address">IP Address.</param>
        /// <param name="port">Port.</param>
        void Bind(string address, int port);

        /// <summary>
        /// Closes connection.
        /// </summary>
        /// <param name="timeOut">Close timeout.</param>
        void Close(int timeOut);

        /// <summary>
        /// Connects to sepcified endpoint.
        /// </summary>
        /// <param name="remoteEP">Endpoint.</param>
        void Connect(EndPoint remoteEP);

        /// <summary>
        /// Connects to specified address.
        /// </summary>
        /// <param name="address">IP Address.</param>
        /// <param name="port">Port.</param>
        void Connect(IPAddress address, int port);

        /// <summary>
        /// Connects to specified ip or host name.
        /// </summary>
        /// <param name="host">IP Address or hostname.</param>
        /// <param name="port">Port.</param>
        void Connect(string host, int port);

        /// <summary>
        /// Disconnects.
        /// </summary>
        /// <param name="reuseSocket">Indicates if socket should be reused.</param>
        void Disconnect(bool reuseSocket);

        /// <summary>
        /// Receives.
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <returns>Amount of bytes read from socket.</returns>
        int Receive(byte[] buffer);

        /// <summary>
        /// Receives.
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <param name="offset">Buffer offset.</param>
        /// <param name="size">Amount to read from socket.</param>
        /// <param name="socketFlags">Socket flags.</param>
        /// <returns>Amount of bytes read from socket.</returns>
        int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags);

        /// <summary>
        /// Receives.
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <param name="size">Amount to read from socket.</param>
        /// <param name="socketFlags">Socket flags.</param>
        /// <returns></returns>
        int Receive(byte[] buffer, int size, SocketFlags socketFlags);

        /// <summary>
        /// Sends.
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <returns>Amount of bytes sent.</returns>
        int Send(byte[] buffer);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <param name="size">Amount to write to socket.</param>
        /// <param name="socketFlags">Socket flags.</param>
        /// <returns>Amount of bytes sent.</returns>
        int Send(byte[] buffer, int size, SocketFlags socketFlags);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <param name="socketFlags">Socket flags.</param>
        /// <returns>Amount of bytes sent.</returns>
        int Send(byte[] buffer, SocketFlags socketFlags);

        /// <summary>
        /// Sends to.
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <param name="remoteEP">Endpoint.</param>
        /// <returns>Amount of bytes sent.</returns>
        int SendTo(byte[] buffer, ref EndPoint remoteEP);

        #endregion
    }
}
