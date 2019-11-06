using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// Executable Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ExecutableInfoDTO
    {
        /// <summary>
        /// The Id of the application on which the executable belongs.
        /// </summary>
        [DataMember]
        public int ApplicationId { get; set; }

        /// <summary>
        /// The name of the application on which the executable belongs.
        /// </summary>
        [DataMember]
        public string ApplicationName { get; set; }

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
        /// List of executable runs.
        /// </summary>
        [DataMember]
        public List<ExecutableExecutionInfoDTO> Executions { get; set; } = new List<ExecutableExecutionInfoDTO>();

        /// <summary>
        /// The number of unique users who ran the executable.
        /// </summary>
        [DataMember]
        public int UniqueUsers { get; set; }

        /// <summary>
        /// The number of unique session in which the executable ran.
        /// </summary>
        [DataMember]
        public int UniqueSessions { get; set; }

        /// <summary>
        /// Total number of runs.
        /// </summary>
        [DataMember]
        public int TotalExecutions { get; set; }

        /// <summary>
        /// Average daily run time.
        /// </summary>
        [DataMember]
        public string AverageDailyExecutionTime { get; set; }
    }
}