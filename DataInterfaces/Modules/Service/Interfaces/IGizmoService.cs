using GizmoDALV2;
using IntegrationLib;
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
        /// Occours on one of network connection change.
        /// </summary>
        event EventHandler<ConnectionChangedArgs> ConnectionChanged;

        /// <summary>
        /// Occurs on user session change.
        /// </summary>
        event EventHandler<UserSessionChangedEventArgs> UserSessionChange;

        #endregion
    } 
    #endregion       
}
