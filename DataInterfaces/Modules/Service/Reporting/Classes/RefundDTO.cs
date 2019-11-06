using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Refund Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class RefundDTO
    {
        /// <summary>
        /// The time the refund was created.
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// The Id of the operator that performed the refund.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// The name of the operator that performed the refund.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        /// <summary>
        /// The Id of the register on which the refund performed.
        /// </summary>
        [DataMember]
        public int? RegisterId { get; set; }

        /// <summary>
        /// The name of the register on which the refund was performed.
        /// </summary>
        [DataMember]
        public string RegisterName { get; set; }

        /// <summary>
        /// Refund method Id.
        /// </summary>
        [DataMember]
        public int? RefundMethodId { get; set; }

        /// <summary>
        /// Refund method name.
        /// </summary>
        [DataMember]
        public string RefundMethodName { get; set; }

        /// <summary>
        /// Amount refunded.
        /// </summary>
        [DataMember]
        public decimal RefundedAmount { get; set; }

    }
}