using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    [Serializable]
    [DataContract]
    public class ProductStockDTO : SoldProductDTO
    {
        [DataMember]
        public decimal Initial { get; set; }

        [DataMember]
        public decimal Added { get; set; }

        [DataMember]
        public decimal Removed { get; set; }

        [DataMember]
        public decimal Set { get; set; }

        [DataMember]
        public decimal Final { get; set; }

        [DataMember]
        public decimal Diff { get; set; }
    }
}