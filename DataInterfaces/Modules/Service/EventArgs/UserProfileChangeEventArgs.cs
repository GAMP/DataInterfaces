using SharedLib;

namespace ServerService
{
    /// <summary>
    /// User profile changed event args.
    /// </summary>
    public class UserProfileChangeEventArgs : UserIdEventArgsBase
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="changeType">Change type.</param>
        public UserProfileChangeEventArgs(int userId, UserChangeType changeType)
            : base(userId)
        {
            Type = changeType;
        }

        /// <summary>
        /// Gets change type.
        /// </summary>
        public UserChangeType Type
        {
            get;
        }
    }
}
