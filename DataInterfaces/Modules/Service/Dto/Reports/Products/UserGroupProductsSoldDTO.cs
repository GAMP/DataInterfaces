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
    public class UserGroupProductsSoldDTO : ReportBaseDTO
    {
        [DataMember]
        public ProductDTO Product { get; set; }

    }
}