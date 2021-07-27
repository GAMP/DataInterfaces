using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Transactions
{
    /// <summary>
    /// Operator Transaction.
    /// </summary>
    [Serializable]
    [DataContract]
    public class OperatorTransactionDTO
    {
        /// <summary>
        /// Operator name.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        /// <summary>
        /// The creation time of the transaction.
        /// </summary>
        [DataMember]
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// The creation time of the invoice related to the transaction.
        /// </summary>
        [DataMember]
        public DateTime? InvoiceDate { get; set; }

        /// <summary>
        /// The transaction title.
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// The username of the customer for whom the transaction was created.
        /// </summary>
        [DataMember]
        public string CustomerName { get; set; }

        /// <summary>
        /// The Id of the invoice related to the transaction.
        /// </summary>
        [DataMember]
        public int? InvoiceId { get; set; }

        /// <summary>
        /// The value of the transaction.
        /// </summary>
        [DataMember]
        public decimal? Value { get; set; }

        /// <summary>
        /// The amount of money or points moved by the transaction.
        /// </summary>
        [DataMember]
        public decimal? Total { get; set; }

        /// <summary>
        /// Payment Method Id.
        /// </summary>
        [DataMember]
        public int PaymentMethodId { get; set; }

        /// <summary>
        /// Payment Method Name.
        /// </summary>
        [DataMember]
        public string PaymentMethodName { get; set; }

        /// <summary>
        /// Register Name.
        /// </summary>
        [DataMember]
        public string RegisterName { get; set; }

        /// <summary>
        /// Note.
        /// </summary>
        [DataMember]
        public string Note { get; set; }
    }
}