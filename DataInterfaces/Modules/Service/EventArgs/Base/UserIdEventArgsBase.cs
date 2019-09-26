using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERIDEVENTARGSBASE
    [Serializable()]
    [DataContract()]
    public abstract class UserIdEventArgsBase : EventArgs
    {
        #region CONSTRUCTOR
        public UserIdEventArgsBase(int userId)
        {
            this.UserId = userId;
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
    #endregion
}
