using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Client ordering product model.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ClientOrderingProduct
    {
        #region PROPERTIES

        /// <summary>
        /// Product id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int ProductId
        {
            get; set;
        }

        /// <summary>
        /// Product name.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string Name
        {
            get; set;
        }


        /// <summary>
        /// Product description.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public string Description
        {
            get; set;
        }

        /// <summary>
        /// Product group id.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int ProductGroupId
        {
            get; set;
        }

        /// <summary>
        /// User price.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public decimal Price
        {
            get; set;
        }

        /// <summary>
        /// User points price.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public int? PointsPrice
        {
            get; set;
        }

        /// <summary>
        /// Award.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public int? Award
        {
            get; set;
        }

        /// <summary>
        /// Indicates if product is out of stock.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public bool? IsOutOfStock
        {
            get; set;
        }

        /// <summary>
        /// Purchase options.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public PurchaseOptionType PurchaseOptions
        {
            get; set;
        }

        /// <summary>
        /// Default product image id.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public int? ProductImageId
        {
            get;set;
        }

        /// <summary>
        /// Tax rate.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public decimal TaxRate
        {
            get;set;
        }

        /// <summary>
        /// Product type.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public ProductType Type
        {
            get;set;
        }

        /// <summary>
        /// Indicates if product has image.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public bool HasImage
        {
            get;set;
        }

        /// <summary>
        /// Indicates if product can only be purchased by members.
        /// </summary>
        [DataMember()]
        [ProtoMember(14)]
        public bool IsMemberOnly
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets created time.
        /// </summary>
        [DataMember()]
        [ProtoMember(15)]
        public DateTime CreatedTime
        {
            get; set;
        }

        #endregion
    }
}
