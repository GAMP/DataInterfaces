using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Stock Transaction.
    /// </summary>
    [Serializable]
    [DataContract]
    public class StockTransactionDTO
    {
        /// <summary>
        /// The creation time of the transaction.
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Number of items left in stock after the transaction.
        /// </summary>
        [DataMember]
        public decimal OnHand { get; set; }
    }
}
