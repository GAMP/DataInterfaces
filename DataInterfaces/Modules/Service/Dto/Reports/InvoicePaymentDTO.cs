using SharedLib;
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
    public class InvoicePaymentDTO : InvoicesInfoDTO
    {
        [DataMember]
        public int InvoiceId { get; set; }

        [DataMember]
        public decimal Total { get; set; }

        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public decimal RefundedAmount { get; set; }

        [DataMember]
        public decimal Outstanding { get; set; }

        [DataMember]
        public bool IsVoided { get; set; }

        [DataMember]
        public RefundStatus RefundStatus { get; set; }

        [DataMember]
        public int PaymentMethodId { get; set; }

        [DataMember]
        public int RefundMethodId { get; set; }

        [DataMember]
        public int? Operator { get; set; }

        [DataMember]
        public int? ShiftId { get; set; }

        [DataMember]
        public int UserGroupId { get; set; }
    }
}