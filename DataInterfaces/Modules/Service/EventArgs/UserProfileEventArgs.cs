using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERPROFILEEVENTARGS
    /// <summary>
    /// User profile event arguments.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserProfileEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserProfileEventArgs(int userId, object userProfile, UserChangeType type) : base(userId, type)
        {
            if (userProfile == null)
                throw new ArgumentNullException(nameof(userProfile));

            this.UserProfile = userProfile;
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
            get { return this.userProfile; }
            protected set { this.userProfile = value; }
        }

        #endregion
    }
    #endregion
}
