using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Transactions
{
    /// <summary>
    /// Transactions Log Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class TransactionsLogReportDTO : ReportBaseDTO
    {
        /// <summary>
        /// Filter Operator Id.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// Filter Operator Name.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        /// <summary>
        /// Filter Register Id.
        /// </summary>
        [DataMember]
        public int? RegisterId { get; set; }

        /// <summary>
        /// Filter Register Name.
        /// </summary>
        [DataMember]
        public string RegisterName { get; set; }

        /// <summary>
        /// Filter User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// Filter User Name.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Filter Transactions Log Action Type.
        /// </summary>
        [DataMember]
        public TransactionsLogActionTypes? TransactionsLogActionType { get; set; }

        /// <summary>
        /// List of operator transactions.
        /// </summary>
        [DataMember]
        public List<OperatorTransactionDTO> Transactions { get; set; }
    }
}