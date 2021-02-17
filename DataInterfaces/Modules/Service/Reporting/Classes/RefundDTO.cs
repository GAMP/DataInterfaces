using ProtoBuf;
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
        [ProtoMember(1)]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// The Id of the operator that performed the refund.
        /// </summary>
        [DataMember]
        [ProtoMember(2)]
        public int? OperatorId { get; set; }

        /// <summary>
        /// The name of the operator that performed the refund.
        /// </summary>
        [DataMember]
        [ProtoMember(3)]
        public string OperatorName { get; set; }

        /// <summary>
        /// The Id of the register on which the refund performed.
        /// </summary>
        [DataMember]
        [ProtoMember(4)]
        public int? RegisterId { get; set; }

        /// <summary>
        /// The name of the register on which the refund was performed.
        /// </summary>
        [DataMember]
        [ProtoMember(5)]
        public string RegisterName { get; set; }

        /// <summary>
        /// Refund method Id.
        /// </summary>
        [DataMember]
        [ProtoMember(6)]
        public int? RefundMethodId { get; set; }

        /// <summary>
        /// Refund method name.
        /// </summary>
        [DataMember]
        [ProtoMember(7)]
        public string RefundMethodName { get; set; }

        /// <summary>
        /// Amount refunded.
        /// </summary>
        [DataMember]
        [ProtoMember(8)]
        public decimal RefundedAmount { get; set; }

    }
}