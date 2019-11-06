using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User renamed event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserRenamedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="oldUserName">Old user name.</param>
        /// <param name="newUserName">New user name.</param>
        public UserRenamedEventArgs(int userId, string oldUserName, string newUserName)
            : base(userId, UserChangeType.UserName)
        {
            #region VALIDATION

            if (string.IsNullOrWhiteSpace(oldUserName))
                throw new ArgumentNullException(nameof(oldUserName), "Old user name may not be null or empty");

            if (string.IsNullOrWhiteSpace(newUserName))
                throw new ArgumentNullException(nameof(newUserName), "New user name may not be null or empty");

            #endregion

            OldUserName = oldUserName;
            NewUserName = newUserName;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new user name.
        /// </summary>
        [DataMember()]
        public string NewUserName
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets old user name.
        /// </summary>
        [DataMember()]
        public string OldUserName
        {
            get;
            protected set;
        }

        #endregion
    }
}
