using SharedLib.Configuration;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [DataContract()]
    public class BackupScheduledTask
    {
        /// <summary>
        /// The backup scheduled task to execute.
        /// </summary>
        [DataMember]
        public ServiceBackupConfig Task { get; set; }

        /// <summary>
        /// Cron expression that represents the schedule to execute the task.
        /// </summary>
        [DataMember]
        public string Schedule { get; set; }

        /// <summary>
        /// Last execution.
        /// </summary>
        [DataMember]
        public DateTime? PreviousExecution { get; set; }

        /// <summary>
        /// Next scheduled execution.
        /// </summary>
        [DataMember]
        public DateTime NextExecution { get; set; }
    }
}
