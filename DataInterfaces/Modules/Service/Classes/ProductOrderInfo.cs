using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ProtoBuf;
using SharedLib;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class ProductOrderInfo
    {
        #region PROPERTIES

        [ProtoMember(1)]
        [DataMember()]
        public int ProductOrderId
        {
            get; set;
        }

        [ProtoMember(2)]
        [DataMember()]
        public int UserId
        {
            get; set;
        }

        [ProtoMember(3)]
        [DataMember()]
        public int? InvoiceId
        {
            get; set;
        }

        [ProtoMember(4)]
        public OrderStatus Status
        {
            get;set;
        }

        [ProtoMember(5)]
        [DataMember()]
        public InvoiceStatus? InvoiceStatus
        {
            get; set;
        }

        [ProtoMember(6)]
        [DataMember()]
        public decimal Total
        {
            get; set;
        }

        [ProtoMember(7)]
        [DataMember()]
        public decimal Outstanding
        {
            get; set;
        }

        [ProtoMember(8)]
        [DataMember()]
        public DateTime CreatedTime
        {
            get;set;
        }

        [ProtoMember(9)]
        [DataMember()]
        public int? OrderHostId
        {
            get;set;
        }

        [ProtoMember(10)]
        [DataMember()]
        public int? PreferedPaymentMethodId
        {
            get;set;
        }

        [ProtoMember(11)]
        [DataMember()]
        public bool IsDelivered
        {
            get;set;
        }

        [ProtoMember(12)]
        [DataMember()]
        public string UserNote
        {
            get;set;
        }

        [ProtoMember(13)]
        [DataMember()]
        public IEnumerable<ProductOrderInfoProduct> Products
        {
            get; set;
        }

        #endregion
    }

    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class ProductOrderInfoProduct
    {
        [ProtoMember(1)]
        [DataMember()]
        public int OrderLineId
        {
            get;set;
        }

        [ProtoMember(2)]
        [DataMember()]
        public string Name
        {
            get;set;
        }

        [ProtoMember(3)]
        [DataMember()]
        public decimal Quantity
        {
            get;set;
        }

        [ProtoMember(4)]
        [DataMember()]
        public bool IsDelivered
        {
            get; set;
        }

        [ProtoMember(5)]
        [DataMember()]
        public decimal DeliveredQuantity
        {
            get;set;
        }

        [ProtoMember(6)]
        [DataMember()]
        public ProductType Type
        {
            get;set;
        }
    }

}
