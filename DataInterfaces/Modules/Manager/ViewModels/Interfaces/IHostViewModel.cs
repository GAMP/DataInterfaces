using SharedLib;
using System.Collections.Generic;
using System.ComponentModel;

namespace Manager.ViewModels
{
    /// <summary>
    /// Generic interface implemented by all host view models.
    /// </summary>
    public interface IHostViewModel : INotifyPropertyChanged
    {
        #region BASE

        /// <summary>
        /// Gets database id.
        /// </summary>
        int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets host number.
        /// </summary>
        int Number
        {
            get;
            set;
        }

        /// <summary>
        /// Gets name.
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets host state.
        /// </summary>
        HostState State
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets host group id.
        /// </summary>
        int? HostGroupId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets host group name.
        /// </summary>
        string GroupName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets if host is out of order.
        /// </summary>
        bool IsOutOfOrder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets maximum users.
        /// </summary>
        int MaximumUsers
        {
            get;
            set;
        }

        /// <summary>
        /// Gets if host is deleted.
        /// </summary>
        bool IsDeleted { get; }

        #endregion

        #region HOST COMPUTER

        /// <summary>
        /// Gets dispatcher id.
        /// </summary>
        int? DispatcherId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets host name.
        /// </summary>
        string HostName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets mac address.
        /// </summary>
        string MacAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets ip address.
        /// </summary>
        string IPAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets port.
        /// </summary>
        int Port { get; set; }

        /// <summary>
        /// Gets if host is locked.
        /// </summary>
        bool IsLocked
        {
            get;
            set;
        }

        /// <summary>
        /// Gets if security enabled.
        /// </summary>
        bool IsSecurityEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets if host is in maintenance mode.
        /// </summary>
        bool IsMaintenanceMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets if host is connected.
        /// </summary>
        bool IsConnected
        {
            get;
            set;
        }

        /// <summary>
        /// Gets if computer operating system is 64 bit.
        /// </summary>
        bool? Is64BitOperatingSystem { get; }

        #endregion

        #region VISUAL

        /// <summary>
        /// Gets or sets icon id.
        /// </summary>
        int? IconId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets x position.
        /// </summary>
        int X
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets y position.
        /// </summary>
        int Y
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets width.
        /// </summary>
        int Width
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets height.
        /// </summary>
        int Height
        {
            get;
            set;
        }

        /// <summary>
        /// Gets if host has at least one reserved guest account.
        /// </summary>
        bool HasReservedGuest { get; set; }

        #endregion

        #region USER MANAGEMENT

        /// <summary>
        /// Gets user collection.
        /// </summary>
        IEnumerable<IUserMemberViewModel> Users { get; }

        /// <summary>
        /// Adds user to the host view model.
        /// </summary>
        /// <param name="user"></param>
        void AddUser(IUserMemberViewModel user);

        /// <summary>
        /// Removes user from host view model.
        /// </summary>
        /// <param name="user"></param>
        void RemoveUser(IUserMemberViewModel user);

        /// <summary>
        /// Gets current user.
        /// </summary>
        /// <remarks>
        /// When multiple users logged on host then this value is equal to null.
        /// </remarks>
        IUserMemberViewModel CurrentUser { get; }

        /// <summary>
        /// Gets logged in users count.
        /// </summary>
        int UsersCount { get; }

        #endregion
    }
}
