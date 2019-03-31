using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Dto.Reports
{
    [Serializable]
    [DataContract]
    public class SessionCostDTO : SessionCostBaseDTO
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int UserGroupId { get; set; }

        [DataMember]
        public int HostId { get; set; }

        [DataMember]
        public int Slot { get; set; }
    }
}
