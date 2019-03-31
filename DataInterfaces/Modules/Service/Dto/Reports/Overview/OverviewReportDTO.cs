using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Dto.Reports.Overview
{
    [Serializable]
    [DataContract]
    public class OverviewReportDTO : ReportBaseDTO
    {
        [DataMember]
        public List<OverviewReportOperatorStatisticsDTO> OperatorsStatistics { get; set; } = new List<OverviewReportOperatorStatisticsDTO>();

        [DataMember]
        public int AverageMemberUsagePeriodMinutes { get; set; }

        [DataMember]
        public int AverageGuestUsagePeriodMinutes { get; set; }

        [DataMember]
        public decimal AverageUtilizationPercentage { get; set; }

        [DataMember]
        public int UniqueMembersLogins { get; set; }

        [DataMember]
        public int UniqueGuestsLogins { get; set; }

        [DataMember]
        public MemberCountersDTO MemberCounters { get; set; }
        
        [DataMember]
        public List<NamedIntegerContainerDTO> GroupMembers { get; set; } = new List<NamedIntegerContainerDTO>();

        [DataMember]
        public List<DateUtilizationChartDTO> Utilization { get; set; } = new List<DateUtilizationChartDTO>();

        [DataMember]
        public decimal TotalRevenue { get; set; }

        [DataMember]
        public decimal AverageRevenuePerMember { get; set; }

        [DataMember]
        public decimal AverageRevenuePerGuest { get; set; }

        [DataMember]
        public List<NamedDecimalContainerDTO> RevenuePerGroup { get; set; } = new List<NamedDecimalContainerDTO>();

    }
}