using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Deposit transaction entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class DepositTransaction : ModifiableByWithRequiredUserMemberBase
    {
        #region DepositTransaction

        /// <summary>
        /// Gets or sets balance transaction type.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public DepositTransactionType Type
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets transaction amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public decimal Amount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets balance.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal Balance
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if voided.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public bool IsVoided
        {
            get;
            set;
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

        #endregion
     
    }
}
