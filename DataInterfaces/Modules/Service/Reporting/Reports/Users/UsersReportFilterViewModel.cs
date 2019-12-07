using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    /// <summary>
    /// Users Report Filter View Model.
    /// </summary>
    [Serializable]
    [DataContract]
    public class UsersReportFilterViewModel : DateRangeReportFilterBaseDTO, IReportFilter, IReportFilterViewModel
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
        /// List of available users to filter.
        /// </summary>
        [DataMember]
        public List<ListItemDTO> Users { get; set; }

        /// <summary>
        /// Filter User Report Type.
        /// </summary>
        [DataMember]
        public UserReportTypes UserReportType { get; set; }

        /// <summary>
        /// Filter User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// Filter User Name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Filter number of top users to display.
        /// </summary>
        [DataMember]
        public int TopUsersNumber { get; set; }

    }
}