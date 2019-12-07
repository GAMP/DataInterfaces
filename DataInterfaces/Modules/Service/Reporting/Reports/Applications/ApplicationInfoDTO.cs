using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// Application Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ApplicationInfoDTO
    {
        /// <summary>
        /// Application Id.
        /// </summary>
        [DataMember]
        public int ApplicationId { get; set; }

        /// <summary>
        /// Application name.
        /// </summary>
        [DataMember]
        public string ApplicationName { get; set; }

        /// <summary>
        /// The number of unique users who ran the application.
        /// </summary>
        [DataMember]
        public int UniqueUsers { get; set; }

        /// <summary>
        /// The number of unique sessions in which the application ran.
        /// </summary>
        [DataMember]
        public int UniqueSessions { get; set; }

        /// <summary>
        /// Number of total runs.
        /// </summary>
        [DataMember]
        public int TotalExecutions { get; set; }

        /// <summary>
        /// Total seconds the application was running.
        /// </summary>
        [DataMember]
        public double TotalSeconds { get; set; }

        /// <summary>
        /// Total time the application was running as text.
        /// </summary>
        [DataMember]
        public string TotalTime { get; set; }

        /// <summary>
        /// Run time percentage in comparison with other applications within the same period.
        /// </summary>
        [DataMember]
        public decimal TotalExecutionsPercentage { get; set; }

        /// <summary>
        /// Average daily run time as text.
        /// </summary>
        [DataMember]
        public string AverageDailyExecutionTime { get; set; }

    }
}
