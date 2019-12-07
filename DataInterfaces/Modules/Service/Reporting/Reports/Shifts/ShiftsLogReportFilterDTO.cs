using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Shifts
{
    /// <summary>
    /// Shifts Log Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ShiftsLogReportFilterDTO : DateRangeReportFilterBaseDTO
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
        /// Filter Shifts Log Report Type.
        /// </summary>
        [DataMember]
        [Required]
        public ShiftsLogReportTypes ShiftsLogReportType { get; set; }
    }
}
