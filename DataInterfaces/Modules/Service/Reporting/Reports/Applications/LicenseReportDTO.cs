using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// License Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class LicenseReportDTO : ReportBaseDTO
    {
        /// <summary>
        /// Filtered License Id.
        /// </summary>
        [DataMember]
        public int? LicenseId { get; set; }

        /// <summary>
        /// Filtered License Name.
        /// </summary>
        [DataMember]
        public string LicenseName { get; set; }
        
        /// <summary>
        /// License usage information.
        /// </summary>
        [DataMember]
        public LicenseUsageInfoDTO LicenseUsage { get; set; }

        /// <summary>
        /// List of records for the concurrent keys chart.
        /// </summary>
        [DataMember]
        public List<ChartRecordDTO> LicenseTimeChart { get; set; }

    }
}