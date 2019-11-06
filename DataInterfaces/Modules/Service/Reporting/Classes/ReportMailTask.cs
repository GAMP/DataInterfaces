using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Report Mail Task.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ReportMailTask
    {
        /// <summary>
        /// The report type of the task.
        /// </summary>
        [DataMember]
        public ReportTypes ReportType { get; set; }

        /// <summary>
        /// The report period type of the task.
        /// </summary>
        [DataMember]
        public ReportPeriodTypes ReportPeriodType { get; set; }

        /// <summary>
        /// Report parameters to pass on execution.
        /// </summary>
        [DataMember]
        public string Parameters { get; set; }

    }
}
