using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    /// <summary>
    /// User Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class UserReportFilterBaseDTO: DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

    }
}