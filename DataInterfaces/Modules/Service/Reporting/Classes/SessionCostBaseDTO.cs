using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
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
