using GizmoDALV2.DTO;
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
    public class ReportUserSessionDTO
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
