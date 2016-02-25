using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.Tasks;
using SharedLib;
using NetLib;
using SharedLib.ViewModels;

namespace ServerService
{
    #region Delegates

    [Obsolete()]
    public delegate void CurrentManagementViewTypeChangedDelegate(ManagementTypesEnum oldType, ManagementTypesEnum newType);

    [Obsolete()]
    public delegate void HostEventDelegate(object sender, HostEventArgs e);

    [Obsolete()]
    public delegate void UserStateChangeDelegate(object sender, UserStateEventArgs e);

    [Obsolete()]
    public delegate void CommandExecuteDelegate(object parameter, IHostManagerView manager);

    [Obsolete()]
    public delegate void ReservationEventDelegate(object sender, ReservationEventArgs e);

    [Obsolete()]
    public delegate void UserProfileChangeDelegate(object sender, UserProfileChangeEventArgs e);

    #endregion
}
