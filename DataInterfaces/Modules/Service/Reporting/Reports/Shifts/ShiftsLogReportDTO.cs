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
        /// Filtered Shifts Log Report Types.
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