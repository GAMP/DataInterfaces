using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Export Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ExportFilterDTO : ReportFilterBaseDTO
    {
        /// <summary>
        /// Export filter title.
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Available fields.
        /// </summary>
        [DataMember]
        public List<ExportFieldDTO> AvailableFields { get; set; }

        /// <summary>
        /// Fields to export.
        /// </summary>
        [DataMember]
        public List<int> SelectedFields { get; set; }

        /// <summary>
        /// Filters to apply.
        /// </summary>
        [DataMember]
        public string FilterValues { get; set; }

        /// <summary>
        /// Filter Export Type.
        /// </summary>
        [DataMember]
        public ExportTypes ExportType { get; set; }
    }
}