using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Z's Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ZDTO
    {
        /// <summary>
        /// Incremental number of the Z.
        /// </summary>
        [DataMember]
        public int ZId { get; set; }

        /// <summary>
        /// The time of the first Z transaction.
        /// </summary>
        [DataMember]
        public DateTime OpenTime { get; set; }

        /// <summary>
        /// The time the Z was closed.
        /// </summary>
        [DataMember]
        public DateTime CloseTime { get; set; }

        /// <summary>
        /// The Id of the first invoice within the Z.
        /// </summary>
        [DataMember]
        public int FirstInvoiceId { get; set; }

        /// <summary>
        /// The Id of the last invoice within the Z.
        /// </summary>
        [DataMember]
        public int LastInvoiceId { get; set; }

        /// <summary>
        /// Number of invoices within the Z.
        /// </summary>
        [DataMember]
        public int InvoiceCount { get; set; }

        /// <summary>
        /// Number of items within the Z.
        /// </summary>
        [DataMember]
        public int ItemCount { get; set; }

        /// <summary>
        /// Z's total tax.
        /// </summary>
        [DataMember]
        public decimal TotalTax { get; set; }

        /// <summary>
        /// Z's total value.
        /// </summary>
        [DataMember]
        public decimal TotalValue { get; set; }
    }
}
