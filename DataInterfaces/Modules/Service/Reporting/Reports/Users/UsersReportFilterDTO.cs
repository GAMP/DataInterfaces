using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    /// <summary>
    /// Users Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class UsersReportFilterDTO : DateRangeReportFilterBaseDTO
    {
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
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Filter number of top users to display.
        /// </summary>
        [DataMember]
        public int TopUsersNumber { get; set; }

    }
}