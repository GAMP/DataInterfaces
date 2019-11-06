using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Invoice Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class InvoiceReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter Invoice Id.
        /// </summary>
        [DataMember]
        public int InvoiceId { get; set; }

    }
}
