using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Products Log Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ProductsLogReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter Product Id.
        /// </summary>
        [DataMember]
        public int? ProductId { get; set; }

        /// <summary>
        /// Filter Operator Id.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// Filter Product Transaction Type.
        /// </summary>
        [DataMember]
        public ProductTransactionTypes? ProductTransactionType { get; set; }

    }
}