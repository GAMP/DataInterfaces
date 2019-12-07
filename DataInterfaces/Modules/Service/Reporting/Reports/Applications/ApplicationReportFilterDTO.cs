using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// Application Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ApplicationReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter Application Id.
        /// </summary>
        [DataMember]
        [Required]
        public int ApplicationId { get; set; }

        /// <summary>
        /// Filter User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

    }
}
