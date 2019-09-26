using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class RefundDTO
    {
        [DataMember]
        public DateTime CreatedTime { get; set; }

        [DataMember]
        public int? OperatorId { get; set; }

        [DataMember]
        public string OperatorName { get; set; }

        [DataMember]
        public int? RegisterId { get; set; }

        [DataMember]
        public string RegisterName { get; set; }

        [DataMember]
        public int? RefundMethodId { get; set; }

        [DataMember]
        public string RefundMethodName { get; set; }

        [DataMember]
        public decimal RefundedAmount { get; set; }

    }
}