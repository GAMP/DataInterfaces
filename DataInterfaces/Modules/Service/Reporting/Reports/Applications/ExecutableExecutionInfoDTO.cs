using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// Executable Execution Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ExecutableExecutionInfoDTO : ExecutableInfoDTO
    {
        /// <summary>
        /// The Id of the user that ran the executable.
        /// </summary>
        [DataMember]
        public int UserId { get; set; }

        /// <summary>
        /// The Id of the user group to which the user belongs.
        /// </summary>
        [DataMember]
        public int UserGroupId { get; set; }

        /// <summary>
        /// The Id of the host on which the executable ran.
        /// </summary>
        [DataMember]
        public int HostId { get; set; }

        /// <summary>
        /// The Id of the host group to which the host belongs.
        /// </summary>
        [DataMember]
        public int? HostGroupId { get; set; }

        /// <summary>
        /// The time the executable started.
        /// </summary>
        [DataMember]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The time the executable ended.
        /// </summary>
        [DataMember]
        public DateTime EndTime { get; set; }
          
        /// <summary>
        /// The duration of the executable run in seconds.
        /// </summary>
        [DataMember]
        public double Span { get; set; }

        /// <summary>
        /// The user that ran the application is guest.
        /// </summary>
        [DataMember]
        public bool IsGuest { get; set; }

        /// <summary>
        /// User session information.
        /// </summary>
        [DataMember]
        public UserSessionDTO UserSession { get; set; }
        
    }
}
