using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERPICTURECHANGEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserPictureChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserPictureChangedEventArgs(int userId, byte[] oldPicture, byte[] newPicture)
            : base(userId, UserChangeType.Picture)
        {
            OldPicture = oldPicture;
            NewPicture = newPicture;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets old picture.
        /// </summary>
        public byte[] OldPicture
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets new picture.
        /// </summary>
        public byte[] NewPicture
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion
}
