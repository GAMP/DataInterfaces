using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Z Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ZReportDTO : FinancialReportBaseDTO
    {
        /// <summary>
        /// Z information in case the financial report type is Z.
        /// </summary>
        [DataMember]
        public ZDTO Z { get; set; }

    }
}