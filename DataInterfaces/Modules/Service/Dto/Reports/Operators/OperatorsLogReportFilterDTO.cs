using ServerService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Dto.Reports.Operators
{
    [Serializable]
    [DataContract]
    public class OperatorsLogReportFilterDTO : ReportFilterBaseDTO
    {
        [DataMember]
        public List<OperatorDTO> Operators { get; set; }

        [DataMember]
        public int? OperatorId { get; set; }
    }
}
