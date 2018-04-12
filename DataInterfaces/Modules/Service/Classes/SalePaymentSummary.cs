using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region InvoicePaymentSummaryBase
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    [ProtoInclude(500, typeof(SaleSummaryReport))]
    [ProtoInclude(501, typeof(InvoicePaymentSummary))]
    [ProtoInclude(502, typeof(OperatorInvoicePaymentSummary))]
    public abstract class InvoicePaymentSummaryBase
    {
        #region PROPERTIES

        #region COMPUTED

        /// <summary>
        /// Gets total payments amount.
        /// </summary>
        [ProtoIgnore()]
        public decimal PaymentTotal
        {
            get { return this.InvoicePaymentTotal + this.DepositPaymentTotal; }
        }

        /// <summary>
        /// Gets total payments count.
        /// </summary>
        [ProtoIgnore()]
        public int TotalPaymentCount
        {
            get { return this.InvoicePaymentCount + this.DepositPaymentCount; }
        }

        #endregion

        /// <summary>
        /// Gets or sets total amount on invoices.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public decimal InvoicePaymentTotal
        {
            get; set;
        }

        /// <summary>
        /// Gets ot sets total payments on invoices.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int InvoicePaymentCount
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total amount on desposits.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal DepositPaymentTotal
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total payments on deposits.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int DepositPaymentCount
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region InvoicePaymentSummary
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class InvoicePaymentSummary : InvoicePaymentSummaryBase
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

        #endregion
    }
    #endregion

    #region OperatorInvoicePaymentSummary
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class OperatorInvoicePaymentSummary : InvoicePaymentSummaryBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets operator id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int OperatorId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets operator name.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string OperatorName
        {
            get; set;
        }

        /// <summary>
        /// Gets total count of invoices.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int InvoiceCount
        {
            get;set;
        }

        #endregion
    }
    #endregion
}
