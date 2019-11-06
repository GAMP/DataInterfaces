using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Report Scheduled Task.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ReportScheduledTask
    {
        /// <summary>
        /// Scheduled task name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The scheduled task is active.
        /// </summary>
        [DataMember]
        public bool IsActive { get; set; }

        /// <summary>
        /// Cron expression that represents the schedule to execute the task.
        /// </summary>
        [DataMember]
        public string Schedule { get; set; }
        
        /// <summary>
        /// List of recipiends e-mails to send 
        /// </summary>
        [DataMember]
        public List<ReportMailRecipient> Recipients { get; set; }

        /// <summary>
        /// List of report mail task under the scheduled task.
        /// </summary>
        [DataMember]
        public List<ReportMailTask> ReportMailTasks { get; set; }
    }
}