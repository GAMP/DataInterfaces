using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Product Transaction.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ProductTransactionDTO
    {
        /// <summary>
        /// The time the transaction performed.
        /// </summary>
        [DataMember]
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// The type of the transaction.
        /// </summary>
        [DataMember]
        public ProductTransactionTypes ProductTransactionType { get; set; }

        /// <summary>
        /// Product Id.
        /// </summary>
        [DataMember]
        public int ProductId { get; set; }

        /// <summary>
        /// Product name.
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// Number of items within the transaction.
        /// </summary>
        [DataMember]
        public decimal Quantity { get; set; }

        /// <summary>
        /// The Id of the operator that performed the transaction.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// The name of the operator that performed the transaction.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        /// <summary>
        /// The Id of the register on which the transaction was performed.
        /// </summary>
        [DataMember]
        public int? RegisterId { get; set; }

        /// <summary>
        /// The name of the register on which the transaction was performed.
        /// </summary>
        [DataMember]
        public string RegisterName { get; set; }

        /// <summary>
        /// The Id of the customer for whom the transaction was created.
        /// </summary>
        [DataMember]
        public int? CustomerId { get; set; }

        /// <summary>
        /// The username of the customer for whom the transaction was created.
        /// </summary>
        [DataMember]
        public string CustomerName { get; set; }

        /// <summary>
        /// Id of the invoice that is related to the transaction.
        /// </summary>
        [DataMember]
        public int? InvoiceId { get; set; }

    }
}