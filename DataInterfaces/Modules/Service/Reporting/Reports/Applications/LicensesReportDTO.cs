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
        /// Filter License Id.
        /// </summary>
        [DataMember]
        public int? LicenseId { get; set; }

        /// <summary>
        /// Filter License Name.
        /// </summary>
        [DataMember]
        public int? LicenseName { get; set; }

        /// <summary>
        /// Filter Application Id.
        /// </summary>
        [DataMember]
        public int? ApplicationId { get; set; }

        /// <summary>
        /// Filter Application Name.
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