using SharedLib.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Manager.Services
{
    /// <summary>
    /// Manager service manager service interface.
    /// Responsible of managing Gizmo server service instances.
    /// </summary>
    public interface IServicesManagerService
    {
        #region PROPERTIES

        /// <summary>
        /// Gets instance of current service.
        /// </summary>
        IRemoteGizmoService Current { get; set; }

        /// <summary>
        /// Gets read only collection of currently configured services.
        /// </summary>
        IReadOnlyCollection<IRemoteGizmoService> Services { get; } 

        #endregion

        #region EVENTS

        /// <summary>
        /// Occurs when services collection changes.
        /// </summary>
        event EventHandler<CollectionChangeEventArgs> Changed;

        /// <summary>
        /// Occurs once current service instance changes.
        /// </summary>
        event EventHandler<CurrentServiceChangedEventArgs> CurrentChanged;

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Tries to obtain service instance for specified configuration.
        /// </summary>
        /// <param name="config">Conifugration instance.</param>
        /// <param name="service">Service instance.</param>
        /// <returns>True or false.</returns>
        bool TryGetByConfig(ServiceConnectionConfig config, out IRemoteGizmoService service); 
        
        #endregion
    }
}
