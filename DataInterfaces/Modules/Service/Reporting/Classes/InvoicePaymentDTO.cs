using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class InvoicePaymentDTO : InvoicesInfoDTO
    {
        [DataMember]
        public int InvoiceId { get; set; }

        [DataMember]
        public DateTime CreatedTime { get; set; }

        [DataMember]
        public decimal Amount { get; set; }
        
        [DataMember]
        public decimal RefundedAmount { get; set; }

        [DataMember]
        public RefundStatus RefundStatus { get; set; }

        [DataMember]
        public int PaymentMethodId { get; set; }

        [DataMember]
        public string PaymentMethodName { get; set; }

        [DataMember]
        public int RefundMethodId { get; set; }

        [DataMember]
        public int? OperatorId { get; set; }

        [DataMember]
        public string OperatorName { get; set; }

        [DataMember]
        public int? RegisterId { get; set; }

        [DataMember]
        public string RegisterName { get; set; }

        [DataMember]
        public int? ShiftId { get; set; }

        [DataMember]
        public int UserGroupId { get; set; }

        [DataMember]
        public bool IsGuest { get; set; }

        [DataMember]
        public decimal InvoiceTotal { get; set; }

        [DataMember]
        public decimal InvoiceOutstanding { get; set; }

        [DataMember]
        public bool InvoiceIsVoided { get; set; }

        [DataMember]
        public DateTime? VoidCreatedTime { get; set; }
    }
}