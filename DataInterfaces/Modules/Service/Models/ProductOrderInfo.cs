using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ProtoBuf;
using SharedLib;

namespace ServerService
{
    /// <summary>
    /// Product order info model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class ProductOrderInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Product oder id.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public int ProductOrderId
        {
            get; set;
        }

        /// <summary>
        /// User id.
        /// </summary>
        [ProtoMember(2)]
        [DataMember()]
        public int UserId
        {
            get; set;
        }

        /// <summary>
        /// Invoice id.
        /// </summary>
        [ProtoMember(3)]
        [DataMember()]
        public int? InvoiceId
        {
            get; set;
        }

        /// <summary>
        /// Order status.
        /// </summary>
        [ProtoMember(4)]
        public OrderStatus Status
        {
            get;set;
        }

        /// <summary>
        /// Invoice status.
        /// </summary>
        [ProtoMember(5)]
        [DataMember()]
        public InvoiceStatus? InvoiceStatus
        {
            get; set;
        }

        /// <summary>
        /// Total.
        /// </summary>
        [ProtoMember(6)]
        [DataMember()]
        public decimal Total
        {
            get; set;
        }

        /// <summary>
        /// Total outstanding.
        /// </summary>
        [ProtoMember(7)]
        [DataMember()]
        public decimal Outstanding
        {
            get; set;
        }

        /// <summary>
        /// Created time.
        /// </summary>
        [ProtoMember(8)]
        [DataMember()]
        public DateTime CreatedTime
        {
            get;set;
        }

        /// <summary>
        /// Order host id.
        /// </summary>
        [ProtoMember(9)]
        [DataMember()]
        public int? OrderHostId
        {
            get;set;
        }

        /// <summary>
        /// Prefered payment method.
        /// </summary>
        [ProtoMember(10)]
        [DataMember()]
        public int? PreferedPaymentMethodId
        {
            get;set;
        }

        /// <summary>
        /// Indicates if order is delivered.
        /// </summary>
        [ProtoMember(11)]
        [DataMember()]
        public bool IsDelivered
        {
            get;set;
        }

        /// <summary>
        /// User note.
        /// </summary>
        [ProtoMember(12)]
        [DataMember(EmitDefaultValue =false)]
        public string UserNote
        {
            get;set;
        }

        /// <summary>
        /// Ordered products.
        /// </summary>
        [ProtoMember(13)]
        [DataMember()]
        public IEnumerable<ProductOrderInfoProduct> Products
        {
            get; set;
        }

        #endregion
    }
}
