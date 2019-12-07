using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// Applications Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ApplicationsReportDTO : ReportBaseDTO
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
        /// List of applications that ran within the reporting period.
        /// </summary>
        [DataMember]
        public List<ApplicationInfoDTO> Applications { get; set; } = new List<ApplicationInfoDTO>();
    }
}