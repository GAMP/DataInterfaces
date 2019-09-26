using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    [Serializable]
    [DataContract]
    public class TopUsersReportUserGroupDTO : NamedInstanceDTO
    {
        [DataMember]
        public List<UserDetailDTO> TopUsers { get; set; }
    }
}