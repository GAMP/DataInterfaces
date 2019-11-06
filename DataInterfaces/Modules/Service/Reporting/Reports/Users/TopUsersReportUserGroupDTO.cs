using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    /// <summary>
    /// Top Users Report User Group.
    /// </summary>
    [Serializable]
    [DataContract]
    public class TopUsersReportUserGroupDTO
    {
        /// <summary>
        /// User Group Name.
        /// </summary>
        [DataMember]
        public string UserGroupName { get; set; }

        /// <summary>
        /// List of users within this group.
        /// </summary>
        [DataMember]
        public List<TopUserInfoDTO> TopUsers { get; set; }
    }
}