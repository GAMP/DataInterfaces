using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Invoice Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class InvoiceReportDTO : ReportBaseDTO
    {
        /// <summary>
        /// Filtered Invoice Id.
        /// </summary>
        [DataMember]
        public int InvoiceId { get; set; }

        /// <summary>
        /// Information of the invoice.
        /// </summary>
        [DataMember]
        public InvoiceDTO Invoice { get; set; }
        
        /// <summary>
        /// List of products sold with this invoice.
        /// </summary>
        [DataMember]
        public List<SoldProductDTO> SoldProducts { get; set; } = new List<SoldProductDTO>();

        /// <summary>
        /// List of payments performed for this invoice.
        /// </summary>
        [DataMember]
        public List<InvoicePaymentDTO> Payments { get; set; } = new List<InvoicePaymentDTO>();

        /// <summary>
        /// List of refunds performed for this invoice.
        /// </summary>
        [DataMember]
        public List<RefundDTO> Refunds { get; set; } = new List<RefundDTO>();
    }
}