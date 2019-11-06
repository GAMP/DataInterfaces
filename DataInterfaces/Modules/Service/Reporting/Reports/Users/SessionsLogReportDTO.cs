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
        /// Filter Host Id.
        /// </summary>
        [DataMember]
        public int? HostId { get; set; }

        /// <summary>
        /// Filter Host Name.
        /// </summary>
        [DataMember]
        public string HostName { get; set; }

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
        /// List of sessions within the reporting period.
        /// </summary>
        [DataMember]
        public List<UserSessionDetailsDTO> Sessions { get; set; } = new List<UserSessionDetailsDTO>();

    }
}