using ProtoBuf;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class UserProductDTO
    {
        #region PROPERTIES

        [DataMember()]
        [ProtoMember(1)]
        public int ProductId
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(2)]
        public string Name
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(3)]
        public string Description
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(4)]
        public int ProductGroupId
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(5)]
        public decimal Price
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(6)]
        public int? PointsPrice
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(7)]
        public int? Award
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(8)]
        public bool? IsOutOfStock
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(9)]
        public PurchaseOptionType PurchaseOptions
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(10)]
        public int? ProductImageId
        {
            get;set;
        }

        [DataMember()]
        [ProtoMember(11)]
        public decimal TaxRate
        {
            get;set;
        }


        [DataMember()]
        [ProtoMember(12)]
        public ProductType Type
        {
            get;set;
        }


        [DataMember()]
        [ProtoMember(13)]
        public bool HasImage
        {
            get;set;
        }

        [DataMember()]
        [ProtoMember(14)]
        public bool IsMemberOnly
        {
            get;set;
        }

        #endregion
    }

    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ProductOrderEntry
    {
        [DataMember()]
        [ProtoMember(1)]
        public int ProductId
        {
            get;set;
        }

        [DataMember()]
        [ProtoMember(2)]
        public decimal Quantity
        {
            get;set;
        }

        [DataMember()]
        [ProtoMember(3)]
        public OrderLinePayType PayType
        {
            get;set;
        }
    }

    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ClientProductOrder
    {
        [ProtoMember(1)]
        [DataMember()]
        public string UserNote
        {
            get;set;
        }

        [ProtoMember(2)]
        [DataMember()]
        public IEnumerable<ProductOrderEntry> Entries
        {
            get;set;
        }
    }
}
