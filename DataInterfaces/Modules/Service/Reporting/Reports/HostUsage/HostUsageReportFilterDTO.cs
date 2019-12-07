using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Hosts
{
    /// <summary>
    /// Host Usage Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class HostUsageReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter Host Usage Report Type.
        /// </summary>
        [DataMember]
        [Required]
        public HostUsageReportTypes HostUsageReportType { get; set; }

        /// <summary>
        /// Filter Host Group Id.
        /// </summary>
        [DataMember]
        public int? HostGroupId { get; set; }
    }
}