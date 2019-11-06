using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Member Counters.
    /// </summary>
    [Serializable]
    [DataContract]
    public class MemberCountersDTO
    {
        /// <summary>
        /// Number of new members.
        /// </summary>
        [DataMember]
        public int NewMembers { get; set; }

        /// <summary>
        /// Total number of members.
        /// </summary>
        [DataMember]
        public int TotalMembers { get; set; }
        
        /// <summary>
        /// Number of banned members.
        /// </summary>
        [DataMember]
        public int BannedMembers { get; set; }
    }
}
