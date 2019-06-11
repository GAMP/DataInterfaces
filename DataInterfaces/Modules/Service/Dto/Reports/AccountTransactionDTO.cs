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
    public class AccountTransactionDTO
    {
        [DataMember]
        public DepositTransactionType Type { get; set; }

        [DataMember]
        public int PaymentMethodId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public decimal Total { get; set; }

        [DataMember]
        public int? Operator { get; set; }

        [DataMember]
        public int? ShiftId { get; set; }

        [DataMember]
        public int UserGroupId { get; set; }

        [DataMember]
        public bool IsGuest { get; set; }
    }
}