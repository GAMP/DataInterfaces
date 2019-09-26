using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERPROFILECHANGEEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserProfileChangeEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public UserProfileChangeEventArgs(int userId, UserChangeType changeType)
            : base(userId)
        {
            Type = changeType;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets change type.
        /// </summary>
        public UserChangeType Type
        {
            get;
            protected set;
        }

        #endregion

        #region OVERRIDES
        public override string ToString()
        {
            return string.Format("USERID:{0} TYPE:{1}", this.UserId, this.Type);
        }
        #endregion
    }
    #endregion
}
