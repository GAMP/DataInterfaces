using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Base class for event args with user id.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public abstract class UserIdEventArgsBase : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId"></param>
        public UserIdEventArgsBase(int userId)
        {
            UserId = userId;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets user id.
        /// </summary>
        [DataMember()]
        public int UserId
        {
            get;
            protected set;
        }

        #endregion
    }
}
