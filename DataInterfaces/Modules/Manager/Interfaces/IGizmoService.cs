using NetLib;
using ServerService;
using SharedLib;
using SharedLib.Dispatcher;
using SharedLib.Logging;
using SharedLib.Management;
using SharedLib.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Manager.Services
{
    public interface IGizmoService : IRemoteService, IUserManagerService
    {
        IDictionary<HostPropertyType, object> GetProperties(int hostId, HashSet<HostPropertyType> types);        
        IDictionary<HostPropertyType, object> GetProperties(int hostId);      

        IMessageDispatcher Dispatcher { get; }


        /// <summary>
        /// Occours when license reservation occours.
        /// </summary>
        event EventHandler<ReservationEventArgs> ReservationChange;

        /// <summary>
        /// Occurs when user state changes.
        /// </summary>
        event EventHandler<UserStateChangeEventArgs> UserStateChange;

        /// <summary>
        /// Occurs on user changed.
        /// <remarks>This event is fired on a seperate thread without blocking execution.</remarks>
        /// </summary>
        event EventHandler<UserProfileChangeEventArgs> UserProfileChange;


        /// <summary>
        /// Occurs on host event.
        /// </summary>
        event EventHandler<HostIdEventArgs> HostChange;

        /// <summary>
        /// Occurs when host properties changed.
        /// </summary>
        event EventHandler<HostPropertiesChangedEventArgs> HostPropertiesChange;

        /// <summary>
        /// Occurs when service connection state changed.
        /// </summary>
        event ConnectionStateDelegate ConnectionStateChange;
    } 
}
