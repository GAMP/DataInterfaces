using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// License Usage Info.
    /// </summary>
    [Serializable]
    [DataContract]
    public class LicenseUsageInfoDTO
    {
        /// <summary>
        /// License info.
        /// </summary>
        [DataMember]
        public LicenseInfoDTO LicenseInfo { get; set; }

        /// <summary>
        /// Total seconds the license was in use.
        /// </summary>
        [DataMember]
        public long TotalRunTimeSeconds { get; set; }

        /// <summary>
        /// Total time the license was in use as text.
        /// </summary>
        [DataMember]
        public string TotalRunTime { get; set; }

        /// <summary>
        /// Time of license last usage.
        /// </summary>
        [DataMember]
        public DateTime? LastUse { get; set; }

        /// <summary>
        /// List of executables that use the license and ran within the reporting period.
        /// </summary>
        [DataMember]
        public List<ExecutableInfoDTO> Executables { get; set; }
    }
}
