using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Date Range Report Filter Base.
    /// </summary>
    [Serializable]
    [DataContract]
    public class DateRangeReportFilterBaseDTO : ReportFilterBaseDTO
    {
        /// <summary>
        /// Filter Date From.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Filter Date To.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime DateTo { get; set; }

    }
}
