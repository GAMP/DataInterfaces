using SharedLib;

namespace ServerService
{
    /// <summary>
    /// User password changed event args.
    /// </summary>
    public sealed class UserGroupChangedEventArgs : UserProfileChangeEventArgs
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
        public int OldGroupId
        {
            get;
        }

        /// <summary>
        /// Gets new user group id.
        /// </summary>
        public int NewGroupId
        {
            get;
        }

        #endregion
    }
}
