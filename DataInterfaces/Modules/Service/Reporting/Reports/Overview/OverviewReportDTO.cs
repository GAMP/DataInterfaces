using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Overview
{
    /// <summary>
    /// Overview Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class OverviewReportDTO : ReportBaseDTO
    {
        /// <summary>
        /// List of operator statistics.
        /// </summary>
        [DataMember]
        public List<OverviewReportOperatorStatisticsDTO> OperatorsStatistics { get; set; } = new List<OverviewReportOperatorStatisticsDTO>();

        /// <summary>
        /// Average daily member visits duration.
        /// </summary>
        [DataMember]
        public string AverageMemberUsagePeriodMinutes { get; set; }

        /// <summary>
        /// Average daily guest visits duration.
        /// </summary>
        [DataMember]
        public string AverageGuestUsagePeriodMinutes { get; set; }

        /// <summary>
        /// Average utilization percentage.
        /// </summary>
        [DataMember]
        public decimal AverageUtilizationPercentage { get; set; }

        /// <summary>
        /// Unique members logins.
        /// </summary>
        [DataMember]
        public int UniqueMembersLogins { get; set; }

        /// <summary>
        /// Unique guests logins.
        /// </summary>
        [DataMember]
        public int UniqueGuestsLogins { get; set; }

        /// <summary>
        /// Member counters.
        /// </summary>
        [DataMember]
        public MemberCountersDTO MemberCounters { get; set; }
        
        /// <summary>
        /// List of records for the utilization chart.
        /// </summary>
        public List<PeriodUtilizationChartRecordDTO> UtilizationChart { get; set; } = new List<PeriodUtilizationChartRecordDTO>();

        /// <summary>
        /// List of records for the financial chart.
        /// </summary>
        public List<ChartRecordDTO> FinancialChart { get; set; } = new List<ChartRecordDTO>();

        /// <summary>
        /// Total pay in-out.
        /// </summary>
        [DataMember]
        public decimal TotalPayInOut { get; set; }

        /// <summary>
        /// Total revenue.
        /// </summary>
        [DataMember]
        public decimal TotalRevenue { get; set; }

        /// <summary>
        /// Average revenue per member.
        /// </summary>
        [DataMember]
        public decimal AverageRevenuePerMember { get; set; }

        /// <summary>
        /// Average revenue per guest.
        /// </summary>
        [DataMember]
        public decimal AverageRevenuePerGuest { get; set; }

        /// <summary>
        /// List of user group revenue.
        /// </summary>
        [DataMember]
        public List<NamedDecimalContainerDTO> RevenuePerGroup { get; set; } = new List<NamedDecimalContainerDTO>();

    }
}