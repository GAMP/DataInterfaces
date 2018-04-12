using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class PaymentSummary
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets payment method id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int PaymentMethodId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets payment method name.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string PaymentMethodName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total payment amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets payments count.
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
