using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    /// <summary>
    /// User Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class UserReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// Filter User Name.
        /// </summary>
        public string UserName { get; set; }

    }
}