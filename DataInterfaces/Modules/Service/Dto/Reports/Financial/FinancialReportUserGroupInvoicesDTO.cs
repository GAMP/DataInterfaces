using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Dto.Reports.Financial
{
    [Serializable]
    [DataContract]
    public class FinancialReportUserGroupInvoicesDTO : NamedInstanceDTO
    {
        [DataMember]
        public List<ProductDTO> FixedTimeProductsSold { get; set; } = new List<ProductDTO>();

        [DataMember]
        public List<ProductDTO> SessionTimeProductsSold { get; set; } = new List<ProductDTO>();

        [DataMember]
        public List<ProductDTO> TimeOffersSold { get; set; } = new List<ProductDTO>();

        [DataMember]
        public List<ProductDTO> ProductsSold { get; set; } = new List<ProductDTO>();

        [DataMember]
        public List<ProductDTO> BundlesSold { get; set; } = new List<ProductDTO>();

    }
}