using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERGROUPCHANGEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserGroupChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserGroupChangedEventArgs(int userId, int oldGroupId, int newGroupId)
            : base(userId, UserChangeType.UserGroup)
        {
            OldGroupId = oldGroupId;
            NewGroupId = newGroupId;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets old user group id.
        /// </summary>
        public int OldGroupId
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets new user group id.
        /// </summary>
        public int NewGroupId
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion
}
