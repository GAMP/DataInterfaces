using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Hosts
{
    [Serializable]
    [DataContract]
    public class HostUsageReportFilterDTO : ReportFilterBaseDTO
    {
        [DataMember]
        public HostUsageReportType ReportType { get; set; }

        [DataMember]
        public List<ListItemDTO> HostGroups { get; set; }

        [DataMember]
        public int? HostGroupId { get; set; }

    }
}