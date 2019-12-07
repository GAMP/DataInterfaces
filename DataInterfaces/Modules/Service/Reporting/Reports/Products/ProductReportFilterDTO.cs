using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Product Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ProductReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter Product Id.
        /// </summary>
        [DataMember]
        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// Filter User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }
    }
}