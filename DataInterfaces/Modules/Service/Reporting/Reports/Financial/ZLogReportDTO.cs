using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    [Serializable]
    [DataContract]
    public class ZLogReportDTO : ReportBaseDTO
    {
        [DataMember]
        public List<ZDTO> Zs = new List<ZDTO>();

    }
}