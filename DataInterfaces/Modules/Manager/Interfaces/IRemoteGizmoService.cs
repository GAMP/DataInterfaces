using GizmoDALV2;
using ServerService;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
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
}
