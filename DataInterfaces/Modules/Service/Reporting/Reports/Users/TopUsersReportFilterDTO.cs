using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    [Serializable]
    [DataContract]
    public class TopUsersReportFilterDTO : ReportFilterBaseDTO
    {
        [DataMember]
        public int TopUsersNumber { get; set; }

    }
}