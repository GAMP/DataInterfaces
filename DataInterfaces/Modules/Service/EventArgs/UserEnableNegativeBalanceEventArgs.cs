using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERENABLENEGATIVEBALANCEEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserEnableNegativeBalanceEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserEnableNegativeBalanceEventArgs(int userId, bool? enabled) : base(userId, UserChangeType.NegativBalanceEnabled)
        {
            Enabled = enabled;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets if negative balance allowed for user.
        /// </summary>
        [DataMember()]
        public bool? Enabled
        {
            get; protected set;
        }
        #endregion
    }
    #endregion
}
