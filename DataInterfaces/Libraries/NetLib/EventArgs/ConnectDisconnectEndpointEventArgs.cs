using System;
using System.Net;

namespace NetLib
{
    /// <summary>
    /// Connection/Disconnection event args.
    /// </summary>
    public sealed class ConnectDisconnectEndpointEventArgs : ConnectDisconnectEventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="ep">Connection endpoint.</param>
        public ConnectDisconnectEndpointEventArgs(EndPoint ep)
        {
            Endpoint = ep ?? throw new ArgumentNullException(nameof(ep));
        }
 
        /// <summary>
        /// Gets endpoint.
        /// </summary>
        public EndPoint Endpoint
        {
            get; private set;
        }
    } 
}

