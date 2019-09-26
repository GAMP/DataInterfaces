using ServerService.Reporting;
using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class SoldProductDTO : NamedDecimalContainerDTO
    {
        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unit price for this product.
        /// </summary>
        [DataMember]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the amount of items sold for this product.
        /// </summary>
        [DataMember]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the tax rate for this product.
        /// </summary>
        [DataMember]
        public decimal TaxRate { get; set; }

        /// <summary>
        /// Gets or sets the tax amount for this product.
        /// </summary>
        [DataMember]
        public decimal Tax { get; set; }

        /// <summary>
        /// Gets or sets the amount of items returned for this product.
        /// </summary>
        [DataMember]
        public decimal Returned { get; set; }

        /// <summary>
        /// Gets or sets the cost in points for this product.
        /// </summary>
        [DataMember]
        public int? Points { get; set; }

        /// <summary>
        /// Gets or sets the points award for this product.
        /// </summary>
        [DataMember]
        public int PointsAward { get; set; }
    }
}