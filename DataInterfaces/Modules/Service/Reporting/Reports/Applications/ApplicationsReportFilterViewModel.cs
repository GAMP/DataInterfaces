using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// Applications Report Filter View Model.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ApplicationsReportFilterViewModel : ApplicationsReportFilterDTO, IReportFilter, IReportFilterViewModel
    {
        /// <summary>
        /// Start week day for weekly report default period.
        /// </summary>
        [DataMember]
        public string BusinessStartWeekDay { get; set; }

        /// <summary>
        /// Day start time for default period.
        /// </summary>
        [DataMember]
        public string BusinessDayStart { get; set; }

        /// <summary>
        /// Default period type for report. Available options are: daily, weekly, monthly and yearly.
        /// </summary>
        [DataMember]
        public string PeriodType { get; set; }

        /// <summary>
        /// Export as pdf.
        /// </summary>
        [DataMember]
        public bool? Pdf { get; set; }

        /// <summary>
        /// Render partial view.
        /// </summary>
        [DataMember]
        public bool? Partial { get; set; }

        /// <summary>
        /// List of available applications to filter.
        /// </summary>
        [DataMember]
        public List<ListItemDTO> Applications { get; set; }

        /// <summary>
        /// Filter Application Id.
        /// </summary>
        [DataMember]
        public int? ApplicationId { get; set; }

    }
}