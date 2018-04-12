using System;
using System.Net;
using System.Net.Sockets;

namespace NetLib
{
    public delegate void ConnectionEventDelegate(IConnection sender);
    public delegate void EndpointEventDelegate(IConnection sender, EndPoint endpoint);
    public delegate void NewConnectionDelegate(IConnection sender, Socket socket);
    public delegate void ConnectionExceptionDelegate(IConnection sender, Exception ex);
}
