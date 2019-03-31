using ServerService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Dto.Reports.Financial
{
    [Serializable]
    [DataContract]
    public class FinancialReportFilterDTO : ReportFilterBaseDTO
    {
        [DataMember]
        public FinancialReportType ReportType { get; set; }
    }
}
