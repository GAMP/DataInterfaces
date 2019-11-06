using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Z Log Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ZLogReportFilterDTO : DateRangeReportFilterBaseDTO
    {

    }
}
