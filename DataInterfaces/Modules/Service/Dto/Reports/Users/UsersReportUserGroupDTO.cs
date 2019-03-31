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
    public class UsersReportUserGroupDTO : NamedInstanceDTO
    {
        [DataMember]
        public List<TopUserDTO> TopUsers { get; set; }
    }
}