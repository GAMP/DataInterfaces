using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USAGESESSIONCHANGEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UsageSessionChangedEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public UsageSessionChangedEventArgs(int userId, UsageType usageType, string timeProduct) : base(userId)
        {
            this.CurrentTimeProduct = timeProduct;
            this.CurrentUsageType = usageType;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets current time poroduct name.
        /// </summary>
        public string CurrentTimeProduct
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets current usage type.
        /// </summary>
        public UsageType CurrentUsageType
        {
            get;
            private set;
        }

        #endregion
    }
    #endregion
}
