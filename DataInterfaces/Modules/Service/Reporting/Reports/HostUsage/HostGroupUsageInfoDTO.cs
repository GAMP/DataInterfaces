using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Hosts
{
    /// <summary>
    /// Host Group Usage Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class HostGroupUsageInfoDTO
    {
        /// <summary>
        /// Host group Id.
        /// </summary>
        [DataMember]
        public int HostGroupId { get; set; }

        /// <summary>
        /// Host group name.
        /// </summary>
        [DataMember]
        public string HostGroupName { get; set; }

        /// <summary>
        /// Total minutes the hosts of the group were used within the reporting period.
        /// </summary>
        [DataMember]
        public long TotalMinutesUsed { get; set; }

        /// <summary>
        /// Total hours the hosts of the group were used within the reporting period.
        /// </summary>
        [DataMember]
        public string TotalHoursUsed { get; set; }

        /// <summary>
        /// Period total minutes multiplied by the number of available hosts.
        /// </summary>
        [DataMember]
        public long TotalMinutes { get; set; }

        /// <summary>
        /// Total estimated revenue within the reporting period.
        /// </summary>
        [DataMember]
        public decimal TotalEstimatedRevenue { get; set; }

        /// <summary>
        /// Utilization percentage.
        /// </summary>
        [DataMember]
        public decimal UtilizationPercentage { get; set; }

        /// <summary>
        /// List of records for the estimated value per host group.
        /// </summary>
        [DataMember]
        public List<GroupSessionsEstimationDTO> GroupSessionsEstimations { get; set; } = new List<GroupSessionsEstimationDTO>();

        /// <summary>
        /// List of records for the utilization charts.
        /// </summary>
        public List<PeriodUtilizationChartRecordDTO> UtilizationChart { get; set; } = new List<PeriodUtilizationChartRecordDTO>();

    }
}