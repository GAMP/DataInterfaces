using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    [Serializable]
    [DataContract]
    public class InvoicesLogReportDTO : ReportBaseDTO
    {
        [DataMember]
        public InvoicesLogPaymentStatusTypes? PaymentStatusType { get; set; }

        [DataMember]
        public InvoicesLogVoidedStatusTypes? VoidedStatusType { get; set; }

        [DataMember]
        public int? OperatorId { get; set; }

        [DataMember]
        public string OperatorName { get; set; }

        [DataMember]
        public int? RegisterId { get; set; }
        
        [DataMember]
        public string RegisterName { get; set; }

        [DataMember]
        public List<InvoiceDTO> Invoices { get; set; } = new List<InvoiceDTO>();

    }
}