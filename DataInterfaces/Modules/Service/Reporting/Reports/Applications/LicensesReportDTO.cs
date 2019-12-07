using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// Licenses Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class LicensesReportDTO : ReportBaseDTO
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
        public int? LicenseName { get; set; }

        /// <summary>
        /// Filtered Application Id.
        /// </summary>
        [DataMember]
        public int? ApplicationId { get; set; }

        /// <summary>
        /// Filtered Application Name.
        /// </summary>
        [DataMember]
        public int? ApplicationName { get; set; }

        /// <summary>
        /// List of license usages.
        /// </summary>
        [DataMember]
        public List<LicenseUsageInfoDTO> Licenses { get; set; } = new List<LicenseUsageInfoDTO>();
    }
}