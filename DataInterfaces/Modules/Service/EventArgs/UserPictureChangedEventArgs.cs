using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User pricture changed event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserPictureChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="oldPicture">Old picture data.</param>
        /// <param name="newPicture">New picture data.</param>
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
        [DataMember()]
        public byte[] OldPicture
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets new picture.
        /// </summary>
        [DataMember()]
        public byte[] NewPicture
        {
            get;
            protected set;
        }

        #endregion
    }
}
