using System;

namespace Client
{
    [Serializable()]
    public class UserPasswordChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public UserPasswordChangeEventArgs(string newPassword)
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
        #endregion
    } 
}
