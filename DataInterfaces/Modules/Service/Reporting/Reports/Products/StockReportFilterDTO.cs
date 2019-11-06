using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Stock Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class StockReportFilterDTO : DateRangeReportFilterBaseDTO
    {
    }
}