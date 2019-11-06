using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User enable negative balance event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserEnableNegativeBalanceEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="enabled">Indicates if negative balance is enabled.</param>
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
}
