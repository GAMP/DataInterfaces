using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class InvoiceDTO
    {
        [DataMember]
        public int InvoiceId { get; set; }

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
        public int? UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string OrderSource { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public decimal Tax { get; set; }

        [DataMember]
        public decimal Value { get; set; }
        
        [DataMember]
        public decimal PointsValue { get; set; }

        [DataMember]
        public int PointsAward { get; set; }
        
        [DataMember]
        public decimal Outstanding { get; set; }

        [DataMember]
        public bool IsVoided { get; set; }

        [DataMember]
        public decimal RefundedAmount { get; set; }

    }
}