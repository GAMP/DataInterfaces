using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// Applications Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ApplicationsReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// Hide unused applications.
        /// </summary>
        [DataMember]
        public bool HideUnused { get; set; }

    }
}