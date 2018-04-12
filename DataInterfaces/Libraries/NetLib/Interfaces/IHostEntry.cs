using System;
using Client;
using SharedLib;
using SharedLib.Dispatcher;

namespace NetLib
{
    /// <summary>
    /// Remote host entry interface.
    /// </summary>
    public interface IHostEntry
    {
        #region EVENTS

        /// <summary>
        /// Occours when host connection changed.
        /// </summary>
        event ConnectionChanged ConnectionChanged;

        /// <summary>
        /// Occurs when host out of order state changes.
        /// </summary>
        event EventHandler<OutOfOrderStateEventArgs> OrderStateChanged;

        /// <summary>
        /// Occours when host dispatcher changes.
        /// </summary>
        event DispatcherChangedDelegate DispatcherChanged;

        /// <summary>
        /// Occurs when host maintenance mode changes.
        /// </summary>
        event EventHandler<MaintenanceEventArgs> MaintenanceModeChanged;

        #endregion

        #region FUNCTIONS

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
        ///Detaches ccurrent connection.
        /// </summary>
        void DetachConnection();

        /// <summary>
        /// Detaches specified connection.
        /// </summary>
        /// <param name="clientconnection">Connection instance.</param>
        void DetachConnection(IConnection clientconnection);

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the host id.
        /// </summary>
        int ID { get; }

        /// <summary>
        /// Gets the host connection.
        /// </summary>
        IConnection Connection { get; set; }

        /// <summary>
        /// Gets or sets host command dispatcher.
        /// </summary>
        IMessageDispatcher Dispatcher { get; set; }

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
        /// Gets hosts group id.
        /// </summary>
        int GroupId { get; }

        #endregion
    }
}
