using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Sold Product Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class GroupedProductSalesDTO : GroupProductSoldDTO
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
    }
}
