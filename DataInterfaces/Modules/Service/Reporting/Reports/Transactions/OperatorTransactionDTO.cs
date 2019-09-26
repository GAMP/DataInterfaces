using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Transactions
{
    [Serializable]
    [DataContract]
    public class OperatorTransactionDTO
    {
        [DataMember]
        public string Operator { get; set; }

        [DataMember]
        public DateTime TransactionDate { get; set; }

        [DataMember]
        public DateTime? InvoiceDate { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Customer { get; set; }

        [DataMember]
        public int? InvoiceId { get; set; }

        [DataMember]
        public decimal? Value { get; set; }

        [DataMember]
        public decimal? Total { get; set; }

        [DataMember]
        public string PaymentMethod { get; set; }

        [DataMember]
        public string Register { get; set; }
    }
}