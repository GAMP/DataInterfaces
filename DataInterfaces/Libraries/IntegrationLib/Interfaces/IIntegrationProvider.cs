using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.Dispatcher;
using IntegrationLib;
using System.Windows.Controls;
using SharedLib.User;
using Client;

namespace IntegrationLib
{
    #region IIntegrationProvider
    public interface IIntegrationProvider
    {
        /// <summary>
        /// Gets if the integration available.
        /// </summary>
        bool IsAvailable { get; }

        /// <summary>
        /// Occours when Availability changes.
        /// </summary>
        event AvailabilityChangedDelegate AvailabilityChanged;

        /// <summary>
        /// Activates the plugin.
        /// </summary>
        /// <param name="ip">Server Ip Address string.</param>
        /// <param name="port">Server Port.</param>
        void Activate(string ip, int port);

        /// <summary>
        /// Deactivates the plugin.
        /// </summary>
        void Deactivate();

        /// <summary>
        /// Gets if provider is active.
        /// </summary>
        bool IsActivated { get; }
    }
    #endregion
}
