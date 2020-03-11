using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Invoice payment entity.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class InvoicePayment : ModifiableByWithRequiredUserMemberBase
    {
        #region InvoicePayment

        /// <summary>
        /// Gets or sets payment id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int PaymentId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets invoice id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int InvoiceId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets amount taken from the referenced payment.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shift id.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public int? ShiftId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register id.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public int? RegisterId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets refunded amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public decimal RefundedAmount
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets refund status.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public RefundStatus RefundStatus
        {
            get; set;
        }

        #endregion
    }
}
