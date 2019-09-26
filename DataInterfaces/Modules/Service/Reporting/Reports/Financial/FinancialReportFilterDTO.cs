﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    [Serializable]
    [DataContract]
    public class FinancialReportFilterDTO : ReportFilterBaseDTO
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
        public FinancialReportType ReportType { get; set; }
    }
}
