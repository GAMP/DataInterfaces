using SharedLib;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService
{
    #region IHostService
    public interface IHostService
    {
        #region EVENTS

        /// <summary>
        /// Occurs on one or more host properties change.
        /// </summary>
        event EventHandler<HostPropertiesChangedEventArgs> HostPropertiesChange;

        /// <summary>
        /// Occours on host connection sucessfully processed.
        /// </summary>
        event EventHandler<HostIdEventArgs> HostEvent;

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Gets specified property for host.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <param name="type">Property type.</param>
        /// <returns>Property value.</returns>
        object HostGetProperty(int hostId, HostPropertyType type);

        /// <summary>
        /// Gets properties for host.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <param name="types">Property types.</param>
        /// <returns>Properties dictionary.</returns>
        IDictionary<HostPropertyType, object> HostGetProperties(int hostId, HashSet<HostPropertyType> types);

        /// <summary>
        /// Gets properties for host.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <returns>Properties dictionary.</returns>
        IDictionary<HostPropertyType, object> HostGetProperties(int hostId);

        #endregion
    }
    #endregion

    public interface IHostServiceAsync : IHostService
    {
        /// <summary>
        /// Gets specified property for host.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <param name="type">Property type.</param>
        /// <returns>Associated task.</returns>
        Task<object> HostGetPropertyAsync(int hostId, HostPropertyType type);

        /// <summary>
        /// Gets properties for host.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <param name="types">Property types.</param>
        /// <returns>Associated task.</returns>
        Task<IDictionary<HostPropertyType, object>> HostGetPropertiesAsync(int hostId, HashSet<HostPropertyType> types);

        /// <summary>
        /// Gets properties for host.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <returns>Associated task.</returns>
        Task<IDictionary<HostPropertyType, object>> HostGetPropertiesAsync(int hostId);
    }

}
