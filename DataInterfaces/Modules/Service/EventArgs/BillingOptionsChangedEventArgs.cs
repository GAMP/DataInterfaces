using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region BILLINGOPTIONSCHANGEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class BillingOptionsChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public BillingOptionsChangedEventArgs(int userId, BillingOption? options) : base(userId, UserChangeType.BillingOptions)
        {
            this.Options = options;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets billing options.
        /// </summary>
        public BillingOption? Options
        {
            get; protected set;
        }
        #endregion
    }
    #endregion
}
