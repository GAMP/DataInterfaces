using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Reporting.Reports.Products
{
    [Serializable]
    [DataContract]
    public class StockReportDTO : ReportBaseDTO
    {
        [DataMember]
        public List<ProductStockDTO> Products { get; set; }

    }
}