using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Apps
{
    [Serializable]
    [DataContract]
    public class TopAppsReportDTO : ReportBaseDTO
    {
        [DataMember]
        public int TopAppsNumber { get; set; }

        [DataMember]
        public List<AppDetailsDTO> TopApps { get; set; } = new List<AppDetailsDTO>();
    }
}