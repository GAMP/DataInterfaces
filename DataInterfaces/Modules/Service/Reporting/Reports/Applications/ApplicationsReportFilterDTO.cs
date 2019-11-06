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
        /// Filter Application Id.
        /// </summary>
        [DataMember]
        public int? ApplicationId { get; set; }

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