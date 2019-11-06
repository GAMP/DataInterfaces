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
        /// Filter Application Id.
        /// </summary>
        [DataMember]
        public int ApplicationId { get; set; }

        /// <summary>
        /// Filter Application Name.
        /// </summary>
        [DataMember]
        public string ApplicationName { get; set; }

        /// <summary>
        /// Application information.
        /// </summary>
        [DataMember]
        public ApplicationInfoDTO Application { get; set; }

        /// <summary>
        /// List of records for the runtime per user group chart.
        /// </summary>
        [DataMember]
        public List<ChartGroupDTO> HoursPerUserGroupChart { get; set; } = new List<ChartGroupDTO>();

        /// <summary>
        /// List of records for the runtime per host group chart.
        /// </summary>
        [DataMember]
        public List<ChartGroupDTO> HoursPerHostGroupChart { get; set; } = new List<ChartGroupDTO>();
    }
}