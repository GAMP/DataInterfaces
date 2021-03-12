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
        private int timeLeftWarning;
        private TimeLeftWarningType timeLeftWarningType;

        /// <summary>
        /// The minute of the notification.
        /// </summary>
        [DataMember]
        public int TimeLeftWarning
        {
            get
            {
                return timeLeftWarning;
            }
            set
            {
                timeLeftWarning = value;
            }
        }

        /// <summary>
        /// The type of the notification.
        /// </summary>
        [DataMember]
        public TimeLeftWarningType TimeLeftWarningType
        {
            get
            {
                return timeLeftWarningType;
            }
            set
            {
                timeLeftWarningType = value;
            }
        }
    }
}