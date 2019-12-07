using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Products Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ProductsReportDTO : ReportBaseDTO
    {
        /// <summary>
        /// Filtered User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// Filtered User Name.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// List of products.
        /// </summary>
        [DataMember]
        public List<GroupedProductSalesDTO> Products { get; set; } = new List<GroupedProductSalesDTO>();

    }
}