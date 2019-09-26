using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
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
