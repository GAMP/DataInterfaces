using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User password changed event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserGroupChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="oldGroupId">Old group id.</param>
        /// <param name="newGroupId">New group id.</param>
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
        [DataMember()]
        public int OldGroupId
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets new user group id.
        /// </summary>
        [DataMember()]
        public int NewGroupId
        {
            get;
            protected set;
        }

        #endregion
    }
}
