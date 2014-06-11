using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SharedLib
{
    public interface IRemoteService
    {
        /// <summary>
        /// Gets if remote service is currently connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Connects to remote service.
        /// </summary>
        void Connect();

        /// <summary>
        /// Disconnects from remote service.
        /// </summary>
        void Disconnect();

    }
}
