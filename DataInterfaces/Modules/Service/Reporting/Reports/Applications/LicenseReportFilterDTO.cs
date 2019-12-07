using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// License Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class LicenseReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter License Id.
        /// </summary>
        [DataMember]
        [Required]
        public int LicenseId { get; set; }

    }
}