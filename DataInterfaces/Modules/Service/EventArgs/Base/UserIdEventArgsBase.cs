using System;

namespace ServerService
{
    /// <summary>
    /// Base class for event args with user id.
    /// </summary>
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
        public int UserId
        {
            get;
            protected set;
        }

        #endregion
    }
}
