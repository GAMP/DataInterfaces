using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Payment summary model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class PaymentSummary
    {
        #region PROPERTIES

        /// <summary>
        /// Payment method id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int PaymentMethodId
        {
            get; set;
        }

        /// <summary>
        /// Payment method name.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string PaymentMethodName
        {
            get; set;
        }

        /// <summary>
        /// Total payment amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// Payments count.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int Count
        {
            get; set;
        }

        #endregion
    }
}
