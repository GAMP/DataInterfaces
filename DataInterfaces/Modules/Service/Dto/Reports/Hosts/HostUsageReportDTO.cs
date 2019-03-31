using ServerService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Dto.Reports.Hosts
{
    [Serializable]
    [DataContract]
    public class HostUsageReportDTO : ReportBaseDTO
    {
        [DataMember]
        public HostUsageReportType ReportType { get; set; }

        [DataMember]
        public List<HostsGroupDTO> HostsGroups { get; set; } = new List<HostsGroupDTO>();

    }
}