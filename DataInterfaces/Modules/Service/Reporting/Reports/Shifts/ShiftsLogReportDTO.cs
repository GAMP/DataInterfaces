using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Shifts
{
    [Serializable]
    [DataContract]
    public class ShiftsLogReportDTO : ReportBaseDTO
    {
        [DataMember]
        public int? OperatorId { get; set; }

        [DataMember]
        public string OperatorName { get; set; }

        [DataMember]
        public int? RegisterId { get; set; }

        [DataMember]
        public string RegisterName { get; set; }

        [DataMember]
        public ShiftsLogReportType ReportType { get; set; }

        [DataMember]
        public List<ShiftDTO> Shifts { get; set; }
    }
}