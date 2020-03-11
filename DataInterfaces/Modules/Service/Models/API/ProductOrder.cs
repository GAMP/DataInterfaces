using ProtoBuf;
using SharedLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Product order entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class ProductOrder : ModifiableByWithRequiredUserMemberBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets order status.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public OrderStatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// Gets sub total.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public decimal SubTotal
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets sub total.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal Total
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets total points.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int PointsTotal
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets tax amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public decimal Tax
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if entity is deleted.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public bool IsDeleted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if voided.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public bool IsVoided
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets host id.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public int? HostId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shift id.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public int? ShiftId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register id.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public int? RegisterId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets prefered payment method id.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public int? PreferedPaymentMethodId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if delivered.
        /// </summary>
        [DataMember()]
        [ProtoMember(14)]
        public bool IsDelivered
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets delivered time.
        /// </summary>
        [DataMember()]
        [ProtoMember(15)]
        public DateTime? DeliveredTime
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets order source.
        /// </summary>
        [DataMember()]
        [ProtoMember(16)]
        public OrderSource Source
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets order source.
        /// </summary>
        [DataMember()]
        [ProtoMember(17)]
        [MaxLength(255)]
        public string UserNote
        {
            get; set;
        }

        #endregion
    }
}
