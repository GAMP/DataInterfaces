using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Dto.Reports
{
    [Serializable]
    [DataContract]
    public class ProductStockDTO : ProductDTO
    {
        [DataMember]
        public decimal Initial { get; set; }

        [DataMember]
        public decimal Added { get; set; }

        [DataMember]
        public decimal Removed { get; set; }
        
        [DataMember]
        public decimal Final { get; set; }

        [DataMember]
        public decimal Diff { get; set; }
    }
}