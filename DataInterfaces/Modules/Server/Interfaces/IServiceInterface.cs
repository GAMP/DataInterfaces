using System;
using SharedLib.Applications;
using NetLib;
using SharedLib;
using System.Collections.Generic;
using SharedLib.Configuration;
using CoreLib;
using System.Collections.ObjectModel;
using SharedLib.User;
using CyClone.Core;
using SharedLib.Dispatcher;

namespace ServerService
{
    /// <summary>
    /// Exposes Main Server Service interface.
    /// </summary>
    public interface IService
    {
        #region EVENTS

        /// <summary>
        /// Occours on server startup.
        /// </summary>
        event StartUpDelegate Startup;

        /// <summary>
        /// Occours on service shutdown.
        /// </summary>
        event ShutDownDelegate Shutdown;

        /// <summary>
        /// Occours when host connection is sucessfully processed.
        /// </summary>
        event HostEventDelegate HostEvent;

        /// <summary>
        /// Occours when mappings configuration changes.
        /// </summary>
        event MappingsConfigurationChnagedDelegate MappingsConfigurationChanged;

        /// <summary>
        /// Occours on current initialization activity change.
        /// </summary>
        event CurrentActivityDelegate ActivityChanged;

        /// <summary>
        /// Occours when license reservation occours.
        /// </summary>
        event ReservationEventDelegate ReservationChanged;

        /// <summary>
        /// Occurs when user state changes.
        /// </summary>
        event UserStateChangeDelegate UserStateChange;

        /// <summary>
        /// Occurs on user changed.
        /// <remarks>This event is fired on a seperate thread without blocking execution.</remarks>
        /// </summary>
        event UserProfileChangeDelegate UserProfileChange;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the service application container.
        /// </summary>
        IApplicationContainer ApplicationContainer { get; }

        /// <summary>
        /// Gets a new instance of host entry.
        /// </summary>
        /// <returns></returns>
        IHostEntry GetHostClassInstance();

        IEnumerable<IHostEntry> GetHostList();

        /// <summary>
        /// Gets system status.
        /// </summary>
        ISystemStatus SystemStatus { get; }

        /// <summary>
        /// Gets version info.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Gets application module.
        /// </summary>
        IApplicationModule Module { get; }

        /// <summary>
        /// Gets server license.
        /// </summary>
        ILicense License { get; }

        /// <summary>
        /// Gets system hardware id.
        /// </summary>
        string HardwareId { get; }

        /// <summary>
        /// Gets read only user collection.
        /// </summary>
        ReadOnlyCollection<IUserProfile> Users { get; } 

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Restarts the service.
        /// </summary>
        void Restart();

        /// <summary>
        /// Stops the service.
        /// </summary>
        void Stop();

        IHostEntry GetHost(IMessageDispatcher dispatcher);

        #endregion
    }
}
