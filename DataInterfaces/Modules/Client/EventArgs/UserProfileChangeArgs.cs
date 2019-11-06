using SharedLib.User;
using System;

namespace Client
{
    /// <summary>
    /// User profile change event args.
    /// </summary>
    [Serializable()]
    public class UserProfileChangeArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="newProfile">New profile.</param>
        /// <param name="oldProfile">Old profile.</param>
        public UserProfileChangeArgs(IUserProfile newProfile, IUserProfile oldProfile)
        {
            NewProfile = newProfile ?? throw new ArgumentNullException(nameof(newProfile));
            OldProfile = oldProfile ?? throw new ArgumentNullException(nameof(oldProfile));
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets old profile value.
        /// </summary>
        public IUserProfile OldProfile
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets new profile value.
        /// </summary>
        public IUserProfile NewProfile
        {
            get;
            protected set;
        }

        #endregion
    }
}
