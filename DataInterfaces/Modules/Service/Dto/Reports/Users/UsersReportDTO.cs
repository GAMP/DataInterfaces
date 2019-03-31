using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Dto.Reports.Users
{
    [Serializable]
    [DataContract]
    public class UsersReportDTO : ReportBaseDTO
    {
        [DataMember]
        public int TopUsersNumber { get; set; }

        [DataMember]
        public MemberCountersDTO MemberCounters { get; set; }

        [DataMember]
        public List<UsersReportUserGroupDTO> TopSpenders { get; set; } = new List<UsersReportUserGroupDTO>();

        [DataMember]
        public List<UsersReportUserGroupDTO> TopPointEarners { get; set; } = new List<UsersReportUserGroupDTO>();

        [DataMember]
        public List<UsersReportUserGroupDTO> TopPointSpenders { get; set; } = new List<UsersReportUserGroupDTO>();

        [DataMember]
        public List<UsersReportUserGroupDTO> TopSessions { get; set; } = new List<UsersReportUserGroupDTO>();
        
        [DataMember]
        public List<UsersReportUserGroupDTO> TopSessionDuration { get; set; } = new List<UsersReportUserGroupDTO>();
    }
}