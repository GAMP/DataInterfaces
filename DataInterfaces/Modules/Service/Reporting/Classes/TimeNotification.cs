using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Time notification.
    /// </summary>
    [Serializable]
    [DataContract]
    public class TimeNotification
    {
        /// <summary>
        /// The minute of the notification.
        /// </summary>
        [DataMember]
        public int TimeLeftWarning { get; set; }

        /// <summary>
        /// The type of the notification.
        /// </summary>
        [DataMember]
        public TimeLeftWarningType TimeLeftWarningType { get; set; }
    }
}