using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Products Log Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ProductsLogReportDTO : ReportBaseDTO
    {
        /// <summary>
        /// Filter Product Id.
        /// </summary>
        [DataMember]
        public int? ProductId { get; set; }

        /// <summary>
        /// Filter Product Name.
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// Filter Operator Id.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// Filter Operator Id.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        /// <summary>
        /// Filter Product Transaction Type Id.
        /// </summary>
        [DataMember]
        public ProductTransactionTypes? ProductTransactionType { get; set; }

        /// <summary>
        /// List of product transactions within the reporting period.
        /// </summary>
        [DataMember]
        public List<ProductTransactionDTO> ProductTransactions { get; set; }

    }
}