using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// License Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class LicenseReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter License Id.
        /// </summary>
        [DataMember]
        public int LicenseId { get; set; }

    }
}