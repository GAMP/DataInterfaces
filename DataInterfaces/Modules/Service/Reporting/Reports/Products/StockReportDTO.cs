using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Stock Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class StockReportDTO : ReportBaseDTO
    {
        /// <summary>
        /// List of products with stock.
        /// </summary>
        [DataMember]
        public List<ProductStockDTO> Products { get; set; }

    }
}