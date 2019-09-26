using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Hosts
{
    [Serializable]
    [DataContract]
    public class HostUsageReportDTO : ReportBaseDTO
    {
        [DataMember]
        public int? HostGroupId { get; set; }

        [DataMember]
        public string HostGroupName { get; set; }

        [DataMember]
        public HostUsageReportType ReportType { get; set; }

        [DataMember]
        public List<HostsGroupDTO> HostsGroups { get; set; } = new List<HostsGroupDTO>();
        
        [DataMember]
        public string TotalHoursUsed { get; set; }

        [DataMember]
        public decimal TotalReportMoney { get; set; }

    }
}