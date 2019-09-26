using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Invoice payment summary base model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    [ProtoInclude(500, typeof(SaleSummaryReport))]
    [ProtoInclude(501, typeof(InvoicePaymentSummary))]
    [ProtoInclude(502, typeof(OperatorInvoicePaymentSummary))]
    public abstract class InvoicePaymentSummaryBase
    {
        #region PROPERTIES        

        /// <summary>
        /// Total amount on invoices.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public decimal InvoicePaymentTotal
        {
            get; set;
        }

        /// <summary>
        /// Total payments on invoices.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int InvoicePaymentCount
        {
            get; set;
        }

        /// <summary>
        /// Total amount on desposits.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal DepositPaymentTotal
        {
            get; set;
        }

        /// <summary>
        /// Total payments on deposits.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int DepositPaymentCount
        {
            get; set;
        }

        #region COMPUTED

        /// <summary>
        /// Total payments amount.
        /// </summary>
        [DataMember()]
        [ProtoIgnore()]
        public decimal PaymentTotal
        {
            get { return this.InvoicePaymentTotal + DepositPaymentTotal; }
        }

        /// <summary>
        /// Total payments count.
        /// </summary>
        [DataMember()]
        [ProtoIgnore()]
        public int TotalPaymentCount
        {
            get { return InvoicePaymentCount + DepositPaymentCount; }
        }

        #endregion

        #endregion
    }
}
