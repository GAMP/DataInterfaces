using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Invoices Log Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class InvoicesLogReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter Operator Id.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// Filter Register Id.
        /// </summary>
        [DataMember]
        public int? RegisterId { get; set; }

        /// <summary>
        /// Filter Payment Status Type.
        /// </summary>
        [DataMember]
        public InvoicesLogPaymentStatusTypes? PaymentStatusType { get; set; }

        /// <summary>
        /// Filter Voided Status Type.
        /// </summary>
        [DataMember]
        public InvoicesLogVoidedStatusTypes? VoidedStatusType { get; set; }
    }
}
