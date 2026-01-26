using SharedLib;
using System;
using System.Collections.Generic;

namespace ServerService
{
    /// <summary>
    /// Host service.
    /// </summary>
    public interface IHostService
    {
        /// <summary>
        /// Occurs on one or more host properties change.
        /// </summary>
        event EventHandler<HostPropertiesChangedEventArgs> HostPropertiesChange;

        /// <summary>
        /// Occurs on host connection successfully processed.
        /// </summary>
        event EventHandler<HostIdEventArgs> HostEvent;


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
        Dictionary<HostPropertyType, object> HostGetProperties(int hostId, HashSet<HostPropertyType> types);

        /// <summary>
        /// Gets properties for host.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <returns>Properties dictionary.</returns>
        Dictionary<HostPropertyType, object> HostGetProperties(int hostId);

        /// <summary>
        /// Gets host ids where property equals to specified value.
        /// </summary>
        /// <param name="type">Property type.</param>
        /// <param name="value">Property value.</param>
        /// <returns>Host id set.</returns>
        ISet<int> HostGetWherePropertyEquals(HostPropertyType type, object value);        
    }
}
