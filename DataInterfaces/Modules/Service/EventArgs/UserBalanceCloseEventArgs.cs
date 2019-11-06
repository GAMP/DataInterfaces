using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User balance close event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserBalanceCloseEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        public UserBalanceCloseEventArgs(int userId) : base(userId)
        { }
        #endregion
    }
}
