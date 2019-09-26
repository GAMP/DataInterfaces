using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERPASSWORDCHANGEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserPasswordChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserPasswordChangedEventArgs(int userId, string newPassword)
            : base(userId, UserChangeType.Password)
        {
            NewPassword = newPassword;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new password value.
        /// </summary>
        public string NewPassword
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets if user password equals to null or empty thus causing a password reset.
        /// </summary>
        public bool IsReset
        {
            get { return string.IsNullOrWhiteSpace(NewPassword); }
        }

        #endregion
    }
    #endregion
}
