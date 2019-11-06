using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Financial Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class FinancialReportFilterDTO : DateRangeReportFilterBaseDTO
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
        /// Filter Financial Report Type.
        /// </summary>
        [DataMember]
        public FinancialReportTypes FinancialReportType { get; set; }
    }
}
