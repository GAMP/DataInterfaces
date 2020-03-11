using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Payment entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class Payment : ModifiableByWithRequiredUserMemberBase
    {
        #region Payment

        /// <summary>
        /// Gets or sets payment method id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int PaymentMethodId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public decimal Amount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets received amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal AmountReceived
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if deleted.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public bool IsDeleted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if voided.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public bool IsVoided
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets transaction id.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public int? DepositTransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets loaylity transaction id.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public int? PointTransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets shift id.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public int? ShiftId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register id.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public int? RegisterId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets refunded amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public decimal RefundedAmount
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets refund status.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public RefundStatus RefundStatus
        {
            get; set;
        }

        #endregion

    }
}
