using SharedLib.User;
using System;

namespace Client
{
    [Serializable()]
    public class UserProfileChangeArgs : EventArgs
    {
        #region CONSTRUCTOR
        public UserProfileChangeArgs(IUserProfile newProfile, IUserProfile oldProfile)
        {
            if (newProfile == null)
                throw new ArgumentNullException("newProfile");

            if (oldProfile == null)
                throw new ArgumentNullException("oldProfile");

            NewProfile = newProfile;
            OldProfile = oldProfile;
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
