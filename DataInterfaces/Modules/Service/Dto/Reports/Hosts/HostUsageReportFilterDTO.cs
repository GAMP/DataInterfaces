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
    public class HostUsageReportFilterDTO : ReportFilterBaseDTO
    {
        [DataMember]
        public HostUsageReportType ReportType { get; set; }

        [DataMember]
        public List<HostGroupDTO> HostGroups { get; set; }

        [DataMember]
        public int? HostGroupId { get; set; }

    }
}