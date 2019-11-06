using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Billing option changed args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class BillingOptionsChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="options">Billing options.</param>
        public BillingOptionsChangedEventArgs(int userId, BillingOption? options) : base(userId, UserChangeType.BillingOptions)
        {
            Options = options;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets billing options.
        /// </summary>
        [DataMember()]
        public BillingOption? Options
        {
            get; protected set;
        }
        #endregion
    }
}
