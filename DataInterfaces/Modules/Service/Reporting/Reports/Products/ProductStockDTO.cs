using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Product Stock Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ProductStockDTO : SoldProductDTO
    {
        /// <summary>
        /// Initial number of items in stock.
        /// </summary>
        [DataMember]
        public decimal Initial { get; set; }

        /// <summary>
        /// Number of items added in stock.
        /// </summary>
        [DataMember]
        public decimal Added { get; set; }

        /// <summary>
        /// Number of items removed from stock.
        /// </summary>
        [DataMember]
        public decimal Removed { get; set; }

        /// <summary>
        /// Manually set stock to specific number of items.
        /// </summary>
        [DataMember]
        public decimal Set { get; set; }

        /// <summary>
        /// Number of items the stock left with.
        /// </summary>
        [DataMember]
        public decimal Final { get; set; }

        /// <summary>
        /// Difference between initial and final stock.
        /// </summary>
        [DataMember]
        public decimal Diff { get; set; }
    }
}