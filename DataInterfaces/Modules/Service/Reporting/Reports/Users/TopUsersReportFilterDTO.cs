using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    /// <summary>
    /// Top Users Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class TopUsersReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter number of top users to display.
        /// </summary>
        [DataMember]
        public int TopUsersNumber { get; set; }

    }
}