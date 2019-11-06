using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User usage session changed event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UsageSessionChangedEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="usageType">Current usage type.</param>
        /// <param name="timeProduct">Current time product name.</param>
        public UsageSessionChangedEventArgs(int userId, UsageType usageType, string timeProduct) : base(userId)
        {
            CurrentTimeProduct = timeProduct;
            CurrentUsageType = usageType;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets current time poroduct name.
        /// </summary>
        [DataMember()]
        public string CurrentTimeProduct
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets current usage type.
        /// </summary>
        [DataMember()]
        public UsageType CurrentUsageType
        {
            get;
            private set;
        }

        #endregion
    }
}
