using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERBALANCEEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserBalanceEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public UserBalanceEventArgs(int userId, UserBalance balance) : base(userId)
        {
            if (balance == null)
                throw new ArgumentNullException(nameof(balance));

            this.Balance = balance;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets balance.
        /// </summary>
        public UserBalance Balance
        {
            get; protected set;
        }
        #endregion
    }
    #endregion
}
