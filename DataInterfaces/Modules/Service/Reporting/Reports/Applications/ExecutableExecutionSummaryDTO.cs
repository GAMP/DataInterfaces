using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// Executable Execution Summary.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ExecutableExecutionSummaryDTO
    {
        /// <summary>
        /// Executable Id.
        /// </summary>
        [DataMember]
        public int ExecutableId { get; set; }

        /// <summary>
        /// Executable name.
        /// </summary>
        [DataMember]
        public string ExecutableName { get; set; }

        /// <summary>
        /// The number of unique users who ran the executable.
        /// </summary>
        [DataMember]
        public int UniqueUsers { get; set; }

        /// <summary>
        /// Total number of runs.
        /// </summary>
        [DataMember]
        public int TotalExecutions { get; set; }

        /// <summary>
        /// Total seconds the executable was running.
        /// </summary>
        [DataMember]
        public double TotalSeconds { get; set; }

        /// <summary>
        /// Total time the executable was running as text.
        /// </summary>
        [DataMember]
        public string TotalTime { get; set; }

        /// <summary>
        /// Average daily run time.
        /// </summary>
        [DataMember]
        public string AverageDailyExecutionTime { get; set; }

    }
}
