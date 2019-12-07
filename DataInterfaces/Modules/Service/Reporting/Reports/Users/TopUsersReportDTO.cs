using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    /// <summary>
    /// Top Users Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class TopUsersReportDTO : ReportBaseDTO
    {
        /// <summary>
        /// Filtered number of top users to display.
        /// </summary>
        [DataMember]
        public int TopUsersNumber { get; set; }

        /// <summary>
        /// Member counters.
        /// </summary>
        [DataMember]
        public MemberCountersDTO MemberCounters { get; set; } = new MemberCountersDTO();

        /// <summary>
        /// List of top spenders grouped by user group.
        /// </summary>
        [DataMember]
        public List<TopUsersReportUserGroupDTO> TopSpenders { get; set; } = new List<TopUsersReportUserGroupDTO>();

        /// <summary>
        /// List of top point earners grouped by user group.
        /// </summary>
        [DataMember]
        public List<TopUsersReportUserGroupDTO> TopPointEarners { get; set; } = new List<TopUsersReportUserGroupDTO>();

        /// <summary>
        /// List of top point spenders grouped by user group.
        /// </summary>
        [DataMember]
        public List<TopUsersReportUserGroupDTO> TopPointSpenders { get; set; } = new List<TopUsersReportUserGroupDTO>();

        /// <summary>
        /// List of top users based on total usage time grouped by user group.
        /// </summary>
        [DataMember]
        public List<TopUsersReportUserGroupDTO> TopSessions { get; set; } = new List<TopUsersReportUserGroupDTO>();

        /// <summary>
        /// List of top users based on longest session grouped by user group.
        /// </summary>
        [DataMember]
        public List<TopUsersReportUserGroupDTO> TopSessionDuration { get; set; } = new List<TopUsersReportUserGroupDTO>();
    }
}