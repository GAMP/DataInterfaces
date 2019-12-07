using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Report Base.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ReportBaseDTO
    {
        /// <summary>
        /// Report Name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Filtered Date From.
        /// </summary>
        [DataMember]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Filtered Date To.
        /// </summary>
        [DataMember]
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Company Name.
        /// </summary>
        [DataMember]
        public string CompanyName { get; set; }

        /// <summary>
        /// Report Type.
        /// </summary>
        [DataMember]
        public ReportTypes ReportType { get; set; }

    }
}