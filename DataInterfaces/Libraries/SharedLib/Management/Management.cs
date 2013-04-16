using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetLib;
using SharedLib.Dispatcher;

namespace SharedLib.Management
{
    #region Delegates
    public delegate void DispatcherChangedDelegate(IMessageDispatcher oldDispatcher, IMessageDispatcher newDispatcher);
    public delegate void ConnectionChanged(IConnection oldConnection, IConnection newConnection); 
    #endregion

    #region IHostGroup
    public interface IHostGroup
    {
        int Id { get; set; }
        int ApplicationProfileId { get; set; }
        string Name { get; set; }
        int SecurityProfileId { get; set; }
    } 
    #endregion

    #region ISecurityProfile
    public interface ISecurityProfile
    {
        int Id { get; set; }
        int DisabledDrives { get; set; }
        string Name { get; set; }
        System.Collections.Generic.List<ISecurityPolicy> Policies { get; set; }
        System.Collections.Generic.List<IRestriction> Restrictions { get; set; }
    }
    #endregion

    #region IUserGroup
    public interface IUserGroup
    {
        int Id { get; set; }
        int ApplicationProfileId { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        UserInfoTypes RequiredUserInfo { get; set; }
        int SecurityProfileId { get; set; }
    } 
    #endregion
}
