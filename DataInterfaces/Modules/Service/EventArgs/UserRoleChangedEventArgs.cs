using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User role changed event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserRoleChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="oldRole">Old role.</param>
        /// <param name="newRole">New role.</param>
        public UserRoleChangedEventArgs(int userId, UserRoles oldRole, UserRoles newRole)
            : base(userId, UserChangeType.Role)
        {
            OldRole = oldRole;
            NewRole = newRole;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Old role.
        /// </summary>
        [DataMember()]
        public UserRoles OldRole
        {
            get;
            protected set;
        }

        /// <summary>
        /// New role.
        /// </summary>
        [DataMember()]
        public UserRoles NewRole
        {
            get;
            protected set;
        }

        #endregion
    }
}
