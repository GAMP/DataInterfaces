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
        /// Filtered Operator Id.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// Filtered Operator Name.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        /// <summary>
        /// Filtered Register Id.
        /// </summary>
        [DataMember]
        public int? RegisterId { get; set; }

        /// <summary>
        /// Filtered Register Name.
        /// </summary>
        [DataMember]
        public string RegisterName { get; set; }

        /// <summary>
        /// Filtered User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// Filtered User Name.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Filtered Transactions Log Action Type.
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