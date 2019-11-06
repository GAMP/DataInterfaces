using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Reporting.Reports.Overview
{
    /// <summary>
    /// Overview Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class OverviewReportFilterDTO : DateRangeReportFilterBaseDTO
    {

    }
}