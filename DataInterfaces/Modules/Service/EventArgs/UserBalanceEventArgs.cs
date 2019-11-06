using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User balance change event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserBalanceEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="balance">User balance.</param>
        public UserBalanceEventArgs(int userId, UserBalance balance) : base(userId)
        {
            Balance = balance ?? throw new ArgumentNullException(nameof(balance));
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets balance.
        /// </summary>
        [DataMember()]
        public UserBalance Balance
        {
            get; protected set;
        }
        #endregion
    }
}
