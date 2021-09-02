using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Product order product info model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class ProductOrderInfoProduct
    {
        #region PROPERTIES

        /// <summary>
        /// Order line id.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public int OrderLineId
        {
            get; set;
        }

        /// <summary>
        /// Product name.
        /// </summary>
        [ProtoMember(2)]
        [DataMember()]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Product quantity.
        /// </summary>
        [ProtoMember(3)]
        [DataMember()]
        public decimal Quantity
        {
            get; set;
        }

        /// <summary>
        /// Indicates if order line is delivered.
        /// </summary>
        [ProtoMember(4)]
        [DataMember()]
        public bool IsDelivered
        {
            get; set;
        }

        /// <summary>
        /// Delivered quantity.
        /// </summary>
        [ProtoMember(5)]
        [DataMember()]
        public decimal DeliveredQuantity
        {
            get; set;
        }

        /// <summary>
        /// Product type.
        /// </summary>
        [ProtoMember(6)]
        [DataMember()]
        public ProductType Type
        {
            get; set;
        }

        /// <summary>
        /// Bundle line id.
        /// </summary>
        [ProtoMember(7)]
        [DataMember()]
        public int? BundleLineId
        {
            get; set;
        }

        /// <summary>
        /// Pay type.
        /// </summary>
        [ProtoMember(8)]
        [DataMember()]
        public OrderLinePayType PayType
        {
            get; set;
        }

        #endregion
    }
}