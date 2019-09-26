using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Operator invoice payment summary model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class OperatorInvoicePaymentSummary : InvoicePaymentSummaryBase
    {
        #region PROPERTIES

        /// <summary>
        /// Operator id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int OperatorId
        {
            get; set;
        }

        /// <summary>
        /// Operator user name.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string OperatorName
        {
            get; set;
        }

        /// <summary>
        /// Total invoices count.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int InvoiceCount
        {
            get; set;
        }

        #endregion
    }
}
