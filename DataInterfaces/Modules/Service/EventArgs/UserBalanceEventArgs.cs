using System;

namespace ServerService
{
    /// <summary>
    /// User balance change event args.
    /// </summary>
    public sealed class UserBalanceEventArgs : UserIdEventArgsBase
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
        public UserBalance Balance
        {
            get;
        }
        #endregion
    }
}
