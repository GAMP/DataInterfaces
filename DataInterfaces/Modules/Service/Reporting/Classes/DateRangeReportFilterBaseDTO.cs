using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Date Range Report Filter Base.
    /// </summary>
    [Serializable]
    [DataContract]
    public class DateRangeReportFilterBaseDTO : ReportFilterBaseDTO
    {
        /// <summary>
        /// Filter Date From.
        /// </summary>
        [DataMember]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Filter Date To.
        /// </summary>
        [DataMember]
        public DateTime DateTo { get; set; }

    }
}
