using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Z Log Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ZLogReportDTO : ReportBaseDTO
    {
        /// <summary>
        /// List of Z within the report.
        /// </summary>
        [DataMember]
        public List<ZDTO> Zs = new List<ZDTO>();

    }
}