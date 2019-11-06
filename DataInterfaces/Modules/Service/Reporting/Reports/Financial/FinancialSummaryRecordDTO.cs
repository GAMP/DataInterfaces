using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Financial Summary Record.
    /// </summary>
    [Serializable]
    [DataContract]
    public class FinancialSummaryRecordDTO
    {
        /// <summary>
        /// Payment method Id.
        /// </summary>
        [DataMember]
        public int PaymentMethodId { get; set; }

        /// <summary>
        /// Payment method name.
        /// </summary>
        [DataMember]
        public string PaymentMethodName { get; set; }

        /// <summary>
        /// Number of items within the record.
        /// </summary>
        [DataMember]
        public int Quantity { get; set; }

        /// <summary>
        /// Value of items within the record.
        /// </summary>
        [DataMember]
        public decimal Value { get; set; }

        /// <summary>
        /// Record refers to a voided invoice.
        /// </summary>
        [DataMember]
        public bool InvoiceIsVoided { get; set; }
    }
}
