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
        /// Filtered Payment Status Type.
        /// </summary>
        [DataMember]
        public InvoicesLogPaymentStatusTypes? PaymentStatusType { get; set; }

        /// <summary>
        /// Filtered Voided Status Type.
        /// </summary>
        [DataMember]
        public InvoicesLogVoidedStatusTypes? VoidedStatusType { get; set; }

        /// <summary>
        /// Filtered Operator Id.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// Filtered Operator Name.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        /// <summary>
        /// Filtered Register Id.
        /// </summary>
        [DataMember]
        public int? RegisterId { get; set; }

        /// <summary>
        /// Filtered Register Name.
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