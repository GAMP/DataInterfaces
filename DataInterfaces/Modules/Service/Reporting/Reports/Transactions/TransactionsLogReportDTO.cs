using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Transactions
{
    [Serializable]
    [DataContract]
    public class TransactionsLogReportDTO : ReportBaseDTO
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
        public TransactionsLogActionTypes? ActionType { get; set; }

        [DataMember]
        public List<OperatorTransactionDTO> Transactions { get; set; }
    }
}