using System;
using System.Net;

namespace NetLib
{
    public class ConnectDisconnectEndpointEventArgs : ConnectDisconnectEventArgs
    {
        #region CONSTRUCTOR
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

