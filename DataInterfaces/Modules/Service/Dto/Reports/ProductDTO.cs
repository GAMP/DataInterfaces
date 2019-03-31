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
    public class ProductDTO : NamedDecimalContainerDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public decimal UnitPrice { get; set; }

        [DataMember]
        public decimal Quantity { get; set; }

        [DataMember]
        public decimal Tax { get; set; }

        [DataMember]
        public decimal Returned { get; set; }

        [DataMember]
        public int Points { get; set; }

        [DataMember]
        public int PointsAward { get; set; }
    }
}