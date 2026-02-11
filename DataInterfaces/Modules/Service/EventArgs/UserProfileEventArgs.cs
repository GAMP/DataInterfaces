using SharedLib;
using System;

namespace ServerService
{
    /// <summary>
    /// User profile event arguments.
    /// </summary>
    public sealed class UserProfileEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="userProfile">User profile.</param>
        /// <param name="type">Change type.</param>
        public UserProfileEventArgs(int userId, object userProfile, UserChangeType type) : base(userId, type)
        {
            UserProfile = userProfile ?? throw new ArgumentNullException(nameof(userProfile));
        }
        #endregion

        #region FIELDS
        private object _userProfile;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets user profile.
        /// </summary>
        public object UserProfile
        {
            get { return _userProfile; }
            protected set { _userProfile = value; }
        }

        #endregion
    }
}
