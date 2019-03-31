using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Dto.Reports.Products
{
    [Serializable]
    [DataContract]
    public class ProductReportFilterDTO : ReportFilterBaseDTO
    {
        [DataMember]
        public List<ProductDTO> Products { get; set; }

        [DataMember]
        public int ProductId { get; set; }
    }
}