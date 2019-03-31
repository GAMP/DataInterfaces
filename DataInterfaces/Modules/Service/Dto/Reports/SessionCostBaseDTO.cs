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
    public class SessionCostBaseDTO
    {
        [DataMember]
        public int SessionId { get; set; }

        [DataMember]
        public decimal Quantity { get; set; }

        [DataMember]
        public decimal Value { get; set; }

        [DataMember]
        public double Span { get; set; }

        [DataMember]
        public double BilledSpan { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }
 
        [DataMember]
        public DateTime? EndTime { get; set; }
    }
}
