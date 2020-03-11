using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Deposit payment entity.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class DepositPayment : ModifiableByWithRequiredUserMemberBase
    {
        #region DepositPayment

        /// <summary>
        /// Gets or sets deposit transaction id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int DepositTransactionId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets payment id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int PaymentId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shift id.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int? ShiftId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register id.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int? RegisterId
        {
            get; set;
        }

        #endregion

    }
}
