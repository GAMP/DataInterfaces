using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class UserSessionDTO
    {
        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public DateTime? EndTime { get; set; }

        [DataMember]
        public double Span { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int UserGroupId{ get; set; }

        [DataMember]
        public bool UserIsGuest { get; set; }

        [DataMember]
        public int HostId { get; set; }

        [DataMember]
        public int Slot { get; set; }

        [DataMember]
        public decimal Value { get; set; }
    }
}
