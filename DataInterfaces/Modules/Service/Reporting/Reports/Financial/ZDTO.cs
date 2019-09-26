using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    [Serializable]
    [DataContract]
    public class ZDTO
    {
        [DataMember]
        public int ZId { get; set; }

        [DataMember]
        public DateTime OpenTime { get; set; }

        [DataMember]
        public DateTime CloseTime { get; set; }

        [DataMember]
        public int FirstInvoiceId { get; set; }

        [DataMember]
        public int LastInvoiceId { get; set; }

        [DataMember]
        public int InvoiceCount { get; set; }

        [DataMember]
        public int ItemCount { get; set; }

        [DataMember]
        public decimal TotalTax { get; set; }

        [DataMember]
        public decimal TotalValue { get; set; }
    }
}
