using System;
using System.Net;

namespace NetLib
{
    /// <summary>
    /// Connection/Disconnection event args.
    /// </summary>
    public class ConnectDisconnectEndpointEventArgs : ConnectDisconnectEventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="ep">Connection endpoint.</param>
        public ConnectDisconnectEndpointEventArgs(EndPoint ep)
        {
            Endpoint = ep ?? throw new ArgumentNullException(nameof(ep));
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets endpoint.
        /// </summary>
        public EndPoint Endpoint
        {
            get; protected set;
        }

        #endregion
    } 
}

