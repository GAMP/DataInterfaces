using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Applications
{
    /// <summary>
    /// License Info.
    /// </summary>
    [Serializable]
    [DataContract]
    public class LicenseInfoDTO
    {
        /// <summary>
        /// License Id.
        /// </summary>
        [DataMember]
        public int LicenseId { get; set; }

        /// <summary>
        /// License name.
        /// </summary>
        [DataMember]
        public string LicenseName { get; set; }

        /// <summary>
        /// Number of active keys.
        /// </summary>
        [DataMember]
        public int NumberOfActiveKeys { get; set; }

        /// <summary>
        /// Number of disabled keys.
        /// </summary>
        [DataMember]
        public int NumberOfDisabledKeys { get; set; }

        /// <summary>
        /// Number of executables using this license.
        /// </summary>
        [DataMember]
        public int NumberOfExecutables { get; set; }

    }
}