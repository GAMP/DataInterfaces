using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User profile changed event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserProfileChangeEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="changeType">Change type.</param>
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
        [DataMember()]
        public UserChangeType Type
        {
            get;
            protected set;
        }

        #endregion

        #region OVERRIDES
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("USERID:{0} TYPE:{1}", this.UserId, this.Type);
        }
        #endregion
    }
}
