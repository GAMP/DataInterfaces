using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Shifts
{
    /// <summary>
    /// Shifts Log Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ShiftsLogReportDTO : ReportBaseDTO
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
        /// Filter Shifts Log Report Types.
        /// </summary>
        [DataMember]
        public ShiftsLogReportTypes ShiftsLogReportType { get; set; }

        /// <summary>
        /// Report Shifts.
        /// </summary>
        [DataMember]
        public List<ShiftDTO> Shifts { get; set; }
    }
}