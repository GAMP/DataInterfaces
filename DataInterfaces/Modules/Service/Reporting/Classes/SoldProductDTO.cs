using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Sold Product Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class SoldProductDTO
    {
        /// <summary>
        /// Product Id.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Product name.
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// The unit price of the product.
        /// </summary>
        [DataMember]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The unit cost of the product.
        /// </summary>
        [DataMember]
        public decimal UnitCost { get; set; }

        /// <summary>
        /// The number of items sold of the product.
        /// </summary>
        [DataMember]
        public decimal Quantity { get; set; }

        /// <summary>
        /// The total cost of the products.
        /// </summary>
        [DataMember]
        public decimal TotalCost { get; set; }

        /// <summary>
        /// The cost of the product.
        /// </summary>
        [DataMember]
        public decimal Value { get; set; }

        /// <summary>
        /// The cost in points of the product.
        /// </summary>
        [DataMember]
        public int PointsValue { get; set; }

        /// <summary>
        /// The points award of the product.
        /// </summary>
        [DataMember]
        public int PointsAward { get; set; }

        /// <summary>
        /// The tax rate of the product.
        /// </summary>
        [DataMember]
        public decimal TaxRate { get; set; }

        /// <summary>
        /// The tax amount of the product.
        /// </summary>
        [DataMember]
        public decimal Tax { get; set; }

        /// <summary>
        /// The product has been sold as part of a bundle.
        /// </summary>
        [DataMember]
        public bool IsInBundle { get; set; }
    }
}