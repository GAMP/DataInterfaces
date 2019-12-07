using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Sold Product Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class GroupProductSoldDTO
    {
        /// <summary>
        /// The number of items sold of the product.
        /// </summary>
        [DataMember]
        public decimal Sold { get; set; }
        
        /// <summary>
        /// The number of items returned of the product.
        /// </summary>
        [DataMember]
        public decimal Returned { get; set; }

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
        /// The tax amount of the product.
        /// </summary>
        [DataMember]
        public decimal Tax { get; set; }
    }
}