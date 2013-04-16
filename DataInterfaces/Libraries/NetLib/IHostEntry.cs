using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreLib;
using SharedLib.Management;

namespace NetLib
{
    public interface IHostEntry
    {
        /// <summary>
        /// Gets the host id.
        /// </summary>
        int ID { get; }

        /// <summary>
        /// Gets the host connection.
        /// </summary>
        IConnection Connection
        {
            get;
            set;
        }

        /// <summary>
        /// Attaches current connection.
        /// </summary>
        void AttachConnection();

        /// <summary>
        /// Attaches specified connection.
        /// </summary>
        /// <param name="clientconnection">Connection instance.</param>
        void AttachConnection(IConnection clientconnection);

        /// <summary>
        /// Occours when host connection changed.
        /// </summary>
        event ConnectionChanged ConnectionChanged;

        /// <summary>
        ///Detaches ccurrent connection.
        /// </summary>
        void DetachConnection();

        /// <summary>
        /// Detaches specified connection.
        /// </summary>
        /// <param name="clientconnection">Connection instance.</param>
        void DetachConnection(IConnection clientconnection);

        /// <summary>
        /// Gets or sets host command dispatcher.
        /// </summary>
        SharedLib.Dispatcher.IMessageDispatcher Dispatcher { get; set; }

        /// <summary>
        /// Occours when host dispatcher changes.
        /// </summary>
        event DispatcherChangedDelegate DispatcherChanged;

        /// <summary>
        /// Gets if valid dispatcher set for the host.
        /// </summary>
        bool HasValidDispatcher { get; }

        /// <summary>
        /// Gets or sets hostname.
        /// </summary>
        string HostName { get; set; }

        /// <summary>
        /// Gets or sets ip address.
        /// </summary>
        string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets if host is remote.
        /// </summary>
        bool IsRemote { get; set; }

        /// <summary>
        /// Gets or sets hosts physical address.
        /// </summary>
        string MacAddress { get; set; }

        /// <summary>
        /// Gets or sets host number.
        /// </summary>
        int Number { get; set; }

        /// <summary>
        /// Gets or sets host port.
        /// </summary>
        int Port { get; set; }

        /// <summary>
        /// Gets or sets if host is registered.
        /// </summary>
        bool Registered { get; set; }

        /// <summary>
        /// Checks if passed host matches current host.
        /// </summary>
        /// <param name="host">Host entry instance.</param>
        /// <returns>True or false.</returns>
        bool IsMatch(IHostEntry host);

        /// <summary>
        /// Gets hosts group id.
        /// </summary>
        int GroupId { get; }
    }
}
