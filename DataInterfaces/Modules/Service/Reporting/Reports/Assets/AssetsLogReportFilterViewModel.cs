using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Assets
{
    /// <summary>
    /// Assets Log Report Filter View Model.
    /// </summary>
    [Serializable]
    [DataContract]
    public class AssetsLogReportFilterViewModel : AssetsLogReportFilterDTO, IReportFilter, IReportFilterViewModel
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
        /// List of available asset types to filter.
        /// </summary>
        [DataMember]
        public List<ListItemDTO> AssetTypes { get; set; }

        /// <summary>
        /// List of available assets to filter.
        /// </summary>
        [DataMember]
        public List<AssetDTO> Assets { get; set; }

        /// <summary>
        /// List of available operators to filter.
        /// </summary>
        [DataMember]
        public List<ListItemDTO> Operators { get; set; }

    }
}