using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Subscription warnings.
    /// </summary>
    [DataContract]
    [Flags()]
    public enum SubscriptionWarnings : int
    {
        /// <summary>
        /// No warnings.
        /// </summary>
        [EnumMember]
        None = 0,

        /// <summary>
        /// Payment failure.
        /// </summary>
        [EnumMember]
        PaymentFailure = 1,

        /// <summary>
        /// Future payment warning.
        /// </summary>
        [EnumMember]
        FuturePaymentWarning = 2
    }
}
