using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Shifts
{
    /// <summary>
    /// Shift Details.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ShiftDetailsDTO
    {
        /// <summary>
        /// Payment method name.
        /// </summary>
        [DataMember]
        public string PaymentMethodName { get; set; }

        /// <summary>
        /// Cash amount the shift started with for this payment method.
        /// </summary>
        [DataMember]
        public decimal StartCash { get; set; }

        /// <summary>
        /// Total amount of sales in this shift for this payment method.
        /// </summary>
        [DataMember]
        public decimal Sales { get; set; }

        /// <summary>
        /// Total amount of deposits in this shift for this payment method.
        /// </summary>
        [DataMember]
        public decimal Deposits { get; set; }

        /// <summary>
        /// Total amount of withdrawals in this shift for this payment method.
        /// </summary>
        [DataMember]
        public decimal Withdrawals { get; set; }

        /// <summary>
        /// Total amount of refunds in this shift for this payment method.
        /// </summary>
        [DataMember]
        public decimal Refunds { get; set; }

        /// <summary>
        /// Total amount of pay ins in this shift for this payment method.
        /// </summary>
        [DataMember]
        public decimal PayIns { get; set; }

        /// <summary>
        /// Total amount of pay outs in this shift for this payment method.
        /// </summary>
        [DataMember]
        public decimal PayOuts { get; set; }

        /// <summary>
        /// Amount expected the shift to end with for this payment method.
        /// </summary>
        [DataMember]
        public decimal Expected { get; set; }

        /// <summary>
        /// Actual amount the shift ended with for this payment method.
        /// </summary>
        [DataMember]
        public decimal Actual { get; set; }

        /// <summary>
        /// Difference between the expected and the actual amount for this payment method.
        /// </summary>
        [DataMember]
        public decimal Difference { get; set; }

    }
}
