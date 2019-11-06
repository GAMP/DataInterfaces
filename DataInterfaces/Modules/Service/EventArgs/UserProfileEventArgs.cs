using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User profile event arguments.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserProfileEventArgs : UserProfileChangeEventArgs
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
        private object userProfile;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets user profile.
        /// </summary>
        [DataMember()]
        public object UserProfile
        {
            get { return userProfile; }
            protected set { userProfile = value; }
        }

        #endregion
    }
}
