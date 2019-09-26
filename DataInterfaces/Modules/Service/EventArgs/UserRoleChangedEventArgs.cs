using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERROLECHANGEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserRoleChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserRoleChangedEventArgs(int userId, UserRoles oldRole, UserRoles newRole)
            : base(userId, UserChangeType.Role)
        {
            OldRole = oldRole;
            NewRole = newRole;
        }
        #endregion

        #region PROPERTIES
        public UserRoles OldRole
        {
            get;
            protected set;
        }

        public UserRoles NewRole
        {
            get;
            protected set;
        }
        #endregion
    }
    #endregion
}
