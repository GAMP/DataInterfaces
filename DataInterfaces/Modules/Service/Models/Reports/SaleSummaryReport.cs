using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Sale summary report model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class SaleSummaryReport : InvoicePaymentSummaryBase
    {
        #region FIELDS
        private Dictionary<int, InvoicePaymentSummary> paymentsByMethod;
        private Dictionary<int, InvoicePaymentSummary> refundsByMethod;
        private Dictionary<int, InvoicePaymentSummary> proceeds;
        private Dictionary<int, OperatorInvoicePaymentSummary> proceedsByOperator;
        private Dictionary<int, OperatorInvoicePaymentSummary> invoicedByOperator;
        private Dictionary<int, OperatorBasicSummary> withdrawalsByOperator;
        private Dictionary<int, OperatorBasicSummary> refundsByOperator;
        private Dictionary<int, OperatorBasicSummary> payInsOutsByOperator;
        private Dictionary<int, OperatorBasicSummary> voidsByOperator;
        private Dictionary<int, OperatorBasicSummary> totalsByOperator;
        #endregion

        #region PROPERTIES

        #region COMPUTED

        [DataMember()]
        [ProtoIgnore()]
        public decimal Total
        {
            get
            {
                return this.Proceeds - this.Withdrawals - this.RefundsTotal + this.PayInsOutsTotal; 
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets outstanding amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public decimal Outstanding
        {
            get; set;
        }

        /// <summary>
        /// Total tax sum.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public decimal Tax
        {
            get; set;
        }

        /// <summary>
        /// Total cost sum.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal Cost
        {
            get; set;
        }

        /// <summary>
        /// Total net sum.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public decimal Net
        {
            get; set;
        }

        /// <summary>
        /// Total revenue sum.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public decimal Revenue
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(6)]
        public decimal Withdrawals
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(7)]
        public decimal Proceeds
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(18)]
        public decimal NonDepositSales
        {
            get;set;
        }

        [DataMember()]
        [ProtoMember(8)]
        public decimal ProceedsCurrent
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(9)]
        public decimal ProceedsPrevious
        {
            get; set;
        }

        /// <summary>
        /// Total amount of refunds.
        /// </summary>
        [DataMember()]
        [ProtoMember(15)]
        public decimal RefundsTotal
        {
            get;set;
        }

        /// <summary>
        /// Total amount of refunds in cash.
        /// </summary>
        [DataMember()]
        [ProtoMember(16)]
        public decimal CashRefunds
        {
            get;set;
        }

        /// <summary>
        /// Total amount of refunds in deposits.
        /// </summary>
        [DataMember()]
        [ProtoMember(17)]
        public decimal DepositRefunds
        {
            get;set;
        }

        [DataMember()]
        [ProtoMember(10)]
        public int InvoiceCount
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(11)]
        public decimal Invoiced
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(12)]
        public int VoidedInvoicesCount
        {
            get;set;
        }

        [DataMember()]
        [ProtoMember(13)]
        public decimal VoidedInvocesSubTotal
        {
            get;set;
        }

        [DataMember()]
        [ProtoMember(14)]
        public decimal VoidedInvocesTotal
        {
            get; set;
        }

        /// <summary>
        /// Total amount of pay ins/outs.
        /// </summary>
        [DataMember()]
        [ProtoMember(19)]
        public decimal PayInsOutsTotal
        {
            get; set;
        }

        #region GROUPS

        [DataMember()]
        [ProtoMember(100)]
        public Dictionary<int, InvoicePaymentSummary> PaymentsByMethod
        {
            get
            {
                if (this.paymentsByMethod == null)
                    this.paymentsByMethod = new Dictionary<int, InvoicePaymentSummary>();
                return this.paymentsByMethod;
            }
            set
            {
                this.paymentsByMethod = value;
            }
        }

        [DataMember()]
        [ProtoMember(101)]
        public Dictionary<int, OperatorInvoicePaymentSummary> InvoicedByOperator
        {
            get
            {
                if (this.invoicedByOperator == null)
                    this.invoicedByOperator = new Dictionary<int, OperatorInvoicePaymentSummary>();
                return this.invoicedByOperator;
            }
            set
            {
                this.invoicedByOperator = value;
            }
        }

        [DataMember()]
        [ProtoMember(102)]
        public Dictionary<int, OperatorBasicSummary> WithdrawalsByOperator
        {
            get
            {
                if (this.withdrawalsByOperator == null)
                    this.withdrawalsByOperator = new Dictionary<int, OperatorBasicSummary>();
                return this.withdrawalsByOperator;
            }
            set
            {
                this.withdrawalsByOperator = value;
            }
        }

        [DataMember()]
        [ProtoMember(103)]
        public Dictionary<int, InvoicePaymentSummary> ProceedsByMethod
        {
            get
            {
                if (this.proceeds == null)
                    this.proceeds = new Dictionary<int, InvoicePaymentSummary>();
                return this.proceeds;
            }
            set
            {
                this.proceeds = value;
            }
        }

        [DataMember()]
        [ProtoMember(104)]
        public Dictionary<int, OperatorInvoicePaymentSummary> ProceedsByOperator
        {
            get
            {
                if (this.proceedsByOperator == null)
                    this.proceedsByOperator = new Dictionary<int, OperatorInvoicePaymentSummary>();
                return this.proceedsByOperator;
            }
            set
            {
                this.proceedsByOperator = value;
            }
        }

        [DataMember()]
        [ProtoMember(105)]
        public Dictionary<int, OperatorBasicSummary> VoidsByOperator
        {
            get
            {
                if (this.voidsByOperator == null)
                    this.voidsByOperator = new Dictionary<int, OperatorBasicSummary>();
                return this.voidsByOperator;
            }
            set
            {
                this.voidsByOperator = value;
            }
        }

        [DataMember()]
        [ProtoMember(106)]
        public Dictionary<int, OperatorBasicSummary> RefundsByOperator
        {
            get
            {
                if (this.refundsByOperator == null)
                    this.refundsByOperator = new Dictionary<int, OperatorBasicSummary>();
                return this.refundsByOperator;
            }
            set
            {
                this.refundsByOperator = value;
            }
        }

        [DataMember()]
        [ProtoMember(107)]
        public Dictionary<int, InvoicePaymentSummary> RefundsByMethod
        {
            get
            {
                if (this.refundsByMethod == null)
                    this.refundsByMethod = new Dictionary<int, InvoicePaymentSummary>();
                return this.refundsByMethod;
            }
            set
            {
                this.refundsByMethod = value;
            }
        }

        [DataMember()]
        [ProtoMember(108)]
        public Dictionary<int, OperatorBasicSummary> TotalsByOperator
        {
            get
            {
                if (this.totalsByOperator == null)
                    this.totalsByOperator = new Dictionary<int, OperatorBasicSummary>();
                return this.totalsByOperator;
            }
            set
            {
                this.totalsByOperator = value;
            }
        }

        [DataMember()]
        [ProtoMember(109)]
        public Dictionary<int, OperatorBasicSummary> PayInsOutsByOperator
        {
            get
            {
                if (this.payInsOutsByOperator == null)
                    this.payInsOutsByOperator = new Dictionary<int, OperatorBasicSummary>();
                return this.payInsOutsByOperator;
            }
            set
            {
                this.payInsOutsByOperator = value;
            }
        }

        #endregion

        #endregion
    }
}
