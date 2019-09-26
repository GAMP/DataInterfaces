using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERRENAMEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserRenamedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserRenamedEventArgs(int userId, string oldUserName, string newUserName)
            : base(userId, UserChangeType.UserName)
        {
            #region VALIDATION

            if (string.IsNullOrWhiteSpace(oldUserName))
                throw new ArgumentNullException("OldUserName", "Old user name may not be null or empty");

            if (string.IsNullOrWhiteSpace(newUserName))
                throw new ArgumentNullException("NewUserName", "New user name may not be null or empty");

            #endregion

            OldUserName = oldUserName;
            NewUserName = newUserName;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new user name.
        /// </summary>
        public string NewUserName
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets old user name.
        /// </summary>
        public string OldUserName
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion
}
