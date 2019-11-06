using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Report Export.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ExportDTO
    {
        /// <summary>
        /// List of headers.
        /// </summary>
        [DataMember()]
        public string[] Headers { get; set; }

        /// <summary>
        /// List of rows.
        /// </summary>
        [DataMember()]
        public ExportRowDTO[] Rows { get; set; }
    }
}