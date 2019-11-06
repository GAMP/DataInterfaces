using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Report Export Row.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ExportRowDTO
    {
        /// <summary>
        /// List of columns within this row.
        /// </summary>
        [DataMember()]
        public string[] Columns { get; set; }
    }
}
