using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    [Serializable]
    [DataContract]
    public class InvoiceReportFilterDTO : ReportFilterBaseDTO
    {
        [DataMember]
        public int InvoiceId { get; set; }

    }
}
