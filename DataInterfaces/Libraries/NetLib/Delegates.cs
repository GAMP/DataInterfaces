using System.Net;
using System.Net.Sockets;

namespace NetLib
{
    /// <summary>
    /// Endpoint event delegate.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="endpoint">Endpoint.</param>
    public delegate void EndpointEventDelegate(IConnection sender, EndPoint endpoint);

    /// <summary>
    /// New connection event delegate.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="socket">Socket.</param>
    public delegate void NewConnectionDelegate(IConnection sender, Socket socket);
}
