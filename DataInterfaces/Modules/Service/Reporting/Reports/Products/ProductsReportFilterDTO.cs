using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Products Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ProductsReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// Hide unused products.
        /// </summary>
        [DataMember]
        public bool HideUnused { get; set; }
    }
}