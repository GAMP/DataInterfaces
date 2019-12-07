using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    /// <summary>
    /// Sessions Log Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class SessionsLogReportFilterDTO : DateRangeReportFilterBaseDTO
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

        /// <summary>
        /// Filter Host Id.
        /// </summary>
        [DataMember]
        public int? HostId { get; set; }

        /// <summary>
        /// Filter Operator Id.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

    }
}