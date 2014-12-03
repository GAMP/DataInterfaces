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
   
    public delegate void CurrentManagementViewTypeChangedDelegate(ManagementTypesEnum oldType, ManagementTypesEnum newType);
   
    public delegate void CommandExecuteDelegate(object parameter, IHostManagerView manager);
   
    public delegate void ReservationEventDelegate(object sender, ReservationEventArgs e);
   
    public delegate void HostEventDelegate(object sender, HostEventArgs e);
   
    public delegate void UserProfileChangeDelegate(object sender,UserProfileChangeEventArgs e);

    public delegate void UserStateChangeDelegate(object sender,UserStateEventArgs e);

    #endregion
}
