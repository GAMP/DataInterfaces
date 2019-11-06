using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// User Session Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class UserSessionDTO
    {
        /// <summary>
        /// User Session Id.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// The time the session started.
        /// </summary>
        [DataMember]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The time the session ended, null if still active.
        /// </summary>
        [DataMember]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Duration of the user session in seconds.
        /// </summary>
        [DataMember]
        public double Span { get; set; }

        /// <summary>
        /// Billed seconds.
        /// </summary>
        [DataMember]
        public double BilledSpan { get; set; }

        /// <summary>
        /// The Id of the user to which the session belongs.
        /// </summary>
        [DataMember]
        public int UserId { get; set; }

        /// <summary>
        /// The Id of the group in which the user of the session belongs.
        /// </summary>
        [DataMember]
        public int UserGroupId{ get; set; }

        /// <summary>
        /// User is guest.
        /// </summary>
        [DataMember]
        public bool UserIsGuest { get; set; }

        /// <summary>
        /// The Id of the host on which the user session ran.
        /// </summary>
        [DataMember]
        public int HostId { get; set; }

        /// <summary>
        /// The slot number on which the user session ran.
        /// </summary>
        [DataMember]
        public int Slot { get; set; }

        /// <summary>
        /// Duration of the user session in minutes.
        /// </summary>
        [DataMember]
        public decimal TotalMinutes { get; set; }

        /// <summary>
        /// The time the session was running as text.
        /// </summary>
        [DataMember]
        public string Duration { get; set; }
    }
}
