using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    /// <summary>
    /// Sessions Log Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class SessionsLogReportDTO : ReportBaseDTO
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
        /// Filtered Host Id.
        /// </summary>
        [DataMember]
        public int? HostId { get; set; }

        /// <summary>
        /// Filtered Host Name.
        /// </summary>
        [DataMember]
        public string HostName { get; set; }

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
        /// List of sessions within the reporting period.
        /// </summary>
        [DataMember]
        public List<UserSessionDetailsDTO> Sessions { get; set; } = new List<UserSessionDetailsDTO>();

    }
}