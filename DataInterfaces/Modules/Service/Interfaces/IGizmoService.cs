using GizmoDALV2;
using NetLib;
using SharedLib;
using System;

namespace ServerService
{
    /// <summary>
    /// Gizmo Service Interface.
    /// </summary>
    public interface IGizmoService :
        IHostService,
        IGizmoServiceLog,
        ILicenseManagmentService,
        IConfigurableService,
        IUserService,
        IDbContextProvider<IGizmoDBContext>,
        IReportsService,
        IBackupService,
        ISettingsService
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Schedules a user balance event.
        /// This event is used to notify modules of user balance change.
        /// </summary>
        /// <param name="userId">User id.</param>
        void ScheduleUserBalanceEvent(int? userId); 

        #endregion

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

        #endregion
    }      
}
