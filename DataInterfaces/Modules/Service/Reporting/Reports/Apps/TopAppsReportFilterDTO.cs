using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Apps
{
    [Serializable]
    [DataContract]
    public class TopAppsReportFilterDTO : ReportFilterBaseDTO
    {
        [DataMember]
        public int TopAppsNumber { get; set; }
    }
}
