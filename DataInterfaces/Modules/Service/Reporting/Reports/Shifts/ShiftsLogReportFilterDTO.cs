using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Shifts
{
    [Serializable]
    [DataContract]
    public class ShiftsLogReportFilterDTO : ReportFilterBaseDTO
    {
        [DataMember]
        public List<ListItemDTO> Operators { get; set; }

        [DataMember]
        public int? OperatorId { get; set; }

        [DataMember]
        public List<ListItemDTO> Registers { get; set; }

        [DataMember]
        public int? RegisterId { get; set; }

        [DataMember]
        public ShiftsLogReportType ReportType { get; set; }
    }
}
