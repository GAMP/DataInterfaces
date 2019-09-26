using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Invoice payment summary model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class InvoicePaymentSummary : InvoicePaymentSummaryBase
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

        #endregion
    }
}
