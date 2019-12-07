using SharedLib;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Orders Log Report Filter View Model.
    /// </summary>
    [Serializable]
    [DataContract]
    public class OrdersReportFilterViewModel : OrdersReportFilterDTO, IReportFilter, IReportFilterViewModel
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
        /// List of available operators to filter.
        /// </summary>
        [DataMember]
        public List<ListItemDTO> Operators { get; set; }

        /// <summary>
        /// List of available users to filter.
        /// </summary>
        [DataMember]
        public List<ListItemDTO> Users { get; set; }

        /// <summary>
        /// Filter Orders Log Report Type.
        /// </summary>
        [DataMember]
        public OrdersLogReportTypes OrdersLogReportType { get; set; }
    }
}