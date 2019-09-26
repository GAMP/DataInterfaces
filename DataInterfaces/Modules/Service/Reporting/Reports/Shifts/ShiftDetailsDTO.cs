using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Shifts
{
    [Serializable]
    [DataContract]
    public class ShiftDetailsDTO
    {
        [DataMember]
        public string PaymentMethodName { get; set; }

        [DataMember]
        public decimal StartCash { get; set; }

        [DataMember]
        public decimal Sales { get; set; }

        [DataMember]
        public decimal Deposits { get; set; }

        [DataMember]
        public decimal Withdrawals { get; set; }

        [DataMember]
        public decimal Refunds { get; set; }

        [DataMember]
        public decimal Expected { get; set; }

        [DataMember]
        public decimal Actual { get; set; }

        [DataMember]
        public decimal Difference { get; set; }

    }
}
