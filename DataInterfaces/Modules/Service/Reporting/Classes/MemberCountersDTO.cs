using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
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
