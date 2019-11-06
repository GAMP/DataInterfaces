using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Order line state.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class OrderLineState
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets order line id.
        /// </summary>
        [ProtoMember(1)]
        public int OrderLineId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if devlivered.
        /// </summary>
        [ProtoMember(2)]
        public bool IsDelivered
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets devlivered quantity.
        /// </summary>
        [ProtoMember(3)]
        public decimal DeliveredQuantity
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets delivery time.
        /// </summary>
        [ProtoMember(4)]
        public DateTime? DeliverTime
        {
            get; set;
        }

        #endregion
    }
}
