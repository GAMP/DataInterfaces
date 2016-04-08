using ServerService;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// Gets properties for specified host.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <param name="types">Property types.</param>
        /// <returns>Properties dictionary.</returns>
        IDictionary<HostPropertyType, object> HostGetProperties(int hostId, HashSet<HostPropertyType> types);

        /// <summary>
        /// Gets properties for specified host.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <returns>Properties dictionary.</returns>
        IDictionary<HostPropertyType, object> HostGetProperties(int hostId);

        #endregion
    }
    #endregion
}
