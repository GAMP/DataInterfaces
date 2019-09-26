using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class InvoicesInfoDTO
    {
        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public decimal Value { get; set; }
    }
}
