using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    [Serializable]
    [DataContract]
    public class InvoiceReportDTO : ReportBaseDTO
    {
        [DataMember]
        public int InvoiceId { get; set; }

        [DataMember]
        public InvoiceDTO Invoice { get; set; }
        
        [DataMember]
        public List<SoldProductDTO> SoldProducts { get; set; } = new List<SoldProductDTO>();

        [DataMember]
        public List<InvoicePaymentDTO> Payments { get; set; } = new List<InvoicePaymentDTO>();

        [DataMember]
        public List<RefundDTO> Refunds { get; set; } = new List<RefundDTO>();
    }
}