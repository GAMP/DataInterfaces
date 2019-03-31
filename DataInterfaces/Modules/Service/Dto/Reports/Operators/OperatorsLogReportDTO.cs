using DataInterfaces.Modules.Service.Dto.Reports.Operators;
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
    public class OperatorsLogReportDTO : ReportBaseDTO
    {
        [DataMember]
        public List<OperatorTransactionDTO> Transactions { get; set; }
    }
}