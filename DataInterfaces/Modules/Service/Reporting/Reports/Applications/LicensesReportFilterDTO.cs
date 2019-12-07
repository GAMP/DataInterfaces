using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// Licenses Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class LicensesReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter Application Id.
        /// </summary>
        [DataMember]
        public int? ApplicationId { get; set; }

        /// <summary>
        /// Hide unused licenses.
        /// </summary>
        [DataMember]
        public bool HideUnused { get; set; }

    }
}