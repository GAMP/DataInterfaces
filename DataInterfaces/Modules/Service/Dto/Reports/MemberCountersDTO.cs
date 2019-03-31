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
    public class MemberCountersDTO
    {
        [DataMember]
        public int NewMembers { get; set; }

        [DataMember]
        public int TotalMembers { get; set; }
        
        [DataMember]
        public int BannedMembers { get; set; }
    }
}
