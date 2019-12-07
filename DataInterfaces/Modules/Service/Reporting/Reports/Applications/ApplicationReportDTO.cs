using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// Application Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ApplicationReportDTO : ReportBaseDTO
    {
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
        /// Filtered Application Id.
        /// </summary>
        [DataMember]
        public int ApplicationId { get; set; }

        /// <summary>
        /// Filtered Application Name.
        /// </summary>
        [DataMember]
        public string ApplicationName { get; set; }

        /// <summary>
        /// Application information.
        /// </summary>
        [DataMember]
        public ApplicationInfoDTO Application { get; set; }
     
        /// <summary>
        /// List of executables that belongs to the application and ran within the reporting period.
        /// </summary>
        [DataMember]
        public List<ExecutableExecutionSummaryDTO> Executables { get; set; } = new List<ExecutableExecutionSummaryDTO>();

        /// <summary>
        /// List of records for the runtime per user group chart.
        /// </summary>
        public List<ChartGroupDTO> HoursPerUserGroupChart { get; set; } = new List<ChartGroupDTO>();

        /// <summary>
        /// List of records for the runtime per host group chart.
        /// </summary>
        public List<ChartGroupDTO> HoursPerHostGroupChart { get; set; } = new List<ChartGroupDTO>();
    }
}