using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USEREMAILCHANGEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserEmailChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserEmailChangedEventArgs(int userId, string oldEmail, string newEmail)
            : base(userId, UserChangeType.Email)
        {
            NewEmail = newEmail;
            OldEmail = oldEmail;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new email value.
        /// </summary>
        public string NewEmail
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets old email value.
        /// </summary>
        public string OldEmail
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion
}
