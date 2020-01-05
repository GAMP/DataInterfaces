using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Transactions
{
    /// <summary>
    /// Transactions Log Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class TransactionsLogReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter Operator Id.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// Filter Register Id.
        /// </summary>
        [DataMember]
        public int? RegisterId { get; set; }

        /// <summary>
        /// Filter User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// Filter User Name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Filter Void Operator Id.
        /// </summary>
        [DataMember]
        public int? VoidOperatorId { get; set; }

        /// <summary>
        /// Filter Transactions Log Action Type.
        /// </summary>
        [DataMember]
        public TransactionsLogActionTypes? TransactionsLogActionType { get; set; }
    }
}
