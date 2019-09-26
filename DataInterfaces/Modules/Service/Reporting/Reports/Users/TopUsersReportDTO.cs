using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    [Serializable]
    [DataContract]
    public class TopUsersReportDTO : ReportBaseDTO
    {
        [DataMember]
        public int TopUsersNumber { get; set; }

        [DataMember]
        public MemberCountersDTO MemberCounters { get; set; } = new MemberCountersDTO();

        [DataMember]
        public List<TopUsersReportUserGroupDTO> TopSpenders { get; set; } = new List<TopUsersReportUserGroupDTO>();

        [DataMember]
        public List<TopUsersReportUserGroupDTO> TopPointEarners { get; set; } = new List<TopUsersReportUserGroupDTO>();

        [DataMember]
        public List<TopUsersReportUserGroupDTO> TopPointSpenders { get; set; } = new List<TopUsersReportUserGroupDTO>();

        [DataMember]
        public List<TopUsersReportUserGroupDTO> TopSessions { get; set; } = new List<TopUsersReportUserGroupDTO>();
        
        [DataMember]
        public List<TopUsersReportUserGroupDTO> TopSessionDuration { get; set; } = new List<TopUsersReportUserGroupDTO>();
    }
}