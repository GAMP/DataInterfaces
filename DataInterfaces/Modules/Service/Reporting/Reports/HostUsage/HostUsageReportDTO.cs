using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Hosts
{
    /// <summary>
    /// Host Usage Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class HostUsageReportDTO : ReportBaseDTO
    {
        /// <summary>
        /// Filter Host Group Id.
        /// </summary>
        [DataMember]
        public int? HostGroupId { get; set; }

        /// <summary>
        /// Filter Host Group Name.
        /// </summary>
        [DataMember]
        public string HostGroupName { get; set; }

        /// <summary>
        /// Filter Host Usage Report Type.
        /// </summary>
        [DataMember]
        public HostUsageReportTypes HostUsageReportType { get; set; }

        /// <summary>
        /// Usage information grouped by host group.
        /// </summary>
        [DataMember]
        public List<HostGroupUsageInfoDTO> HostGroups { get; set; } = new List<HostGroupUsageInfoDTO>();
        
        /// <summary>
        /// Total hours the hosts were used within the reporting period.
        /// </summary>
        [DataMember]
        public string TotalHoursUsed { get; set; }

        /// <summary>
        /// Total estimated revenue within the reporting period.
        /// </summary>
        [DataMember]
        public decimal TotalEstimatedRevenue { get; set; }

    }
}