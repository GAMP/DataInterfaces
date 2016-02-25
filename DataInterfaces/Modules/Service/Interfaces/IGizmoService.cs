using GizmoDALV2;
using Manager;
using NetLib;
using SharedLib;
using SharedLib.Configuration;
using SharedLib.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServerService
{
    #region IGizmoService
    /// <summary>
    /// Gizmo Service Interface.
    /// </summary>
    public interface IGizmoService :
        IHostService,
        ILicenseManagmentService,
        IConfigurableService,
        IUserService
    {
        #region EVENTS
        /// <summary>
        /// Occours on server startup.
        /// <remarks>
        /// This event is called once service is fully initialized.
        /// </remarks>
        /// </summary>
        event EventHandler<StartUpEventArgs> Startup;

        /// <summary>
        /// Occours on service shutdown.
        /// </summary>
        event EventHandler<ShutDownEventArgs> Shutdown;

        /// <summary>
        /// Occours on one of network connections change.
        /// </summary>
        event EventHandler<ConnectionChangedArgs> ConnectionChanged;
        #endregion
    } 
    #endregion

    #region IRemoteGizmoService
    /// <summary>
    /// Remote Gizmo Service implementation iterface.
    /// </summary>
    public interface IRemoteGizmoService :
        IRemoteService,
        IHostService,
        IConfigurableService,
        IUserService,
        ILogService
    {
        event EventHandler<AuthEventArgs> Authenticated;
        event EventHandler<IEntityEventArgs> EntityEvent;
    }  
    #endregion

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
        /// <returns></returns>
        IDictionary<HostPropertyType, object> HostGetProperties(int hostId, HashSet<HostPropertyType> types);

        /// <summary>
        /// Gets properties for specified host.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <returns></returns>
        IDictionary<HostPropertyType, object> HostGetProperties(int hostId);

        #endregion
    } 
    #endregion

    #region ILicenseManagmentService
    public interface ILicenseManagmentService
    {
        #region EVENTS
        /// <summary>
        /// Occours on license reservation change.
        /// </summary>
        event EventHandler<ReservationEventArgs> ReservationChange;
        #endregion
    } 
    #endregion

    #region IConfigurableService
    public interface IConfigurableService
    {
        /// <summary>
        /// Gets service configuration.
        /// </summary>
        /// <returns>Root service configuration.</returns>
        ConfigurationRoot ConfigurationGet();

        /// <summary>
        /// Sets service configuration.
        /// </summary>
        /// <param name="configuration">Service configuration root.</param>
        void ConfigurationSet(ConfigurationRoot configuration);
    } 
    #endregion

    #region IUserService
    public interface IUserService
    {
        #region EVENTS
        /// <summary>
        /// Occurs on user state change.
        /// </summary>
        event EventHandler<UserStateChangeEventArgs> UserStateChange;

        /// <summary>
        /// Occurs on user state change completed.
        /// </summary>
        event EventHandler<UserStateChangeEventArgs> UserStateChangeCompleted;

        /// <summary>
        /// Occurs on user profile change.
        /// </summary>
        event EventHandler<UserProfileChangeEventArgs> UserProfileChange;
        #endregion
    } 
    #endregion

    #region ILogService
    public interface ILogService
    {
        /// <summary>
        /// Occurs on log change.
        /// </summary>
        event EventHandler<LogChangeEventArgs> LogChange;
    } 
    #endregion
}
