using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Points transaction entity.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class PointTransaction : ModifiableByWithRequiredUserMemberBase
    {
        #region PointTransaction

        /// <summary>
        /// Gets or sets balance transaction type.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public LoyalityPointsTransactionType Type
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets points amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int Amount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets points balance.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int Balance
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
