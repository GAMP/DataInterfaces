using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Invoices Log Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class InvoicesLogReportDTO : ReportBaseDTO
    {
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

        /// <summary>
        /// Filter Operator Id.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// Filter Operator Name.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }
        
        /// <summary>
        /// Filter Register Id.
        /// </summary>
        [DataMember]
        public int? RegisterId { get; set; }

        /// <summary>
        /// Filter Register Name.
        /// </summary>
        [DataMember]
        public string RegisterName { get; set; }

        /// <summary>
        /// List of invoices.
        /// </summary>
        [DataMember]
        public List<InvoiceDTO> Invoices { get; set; } = new List<InvoiceDTO>();

    }
}