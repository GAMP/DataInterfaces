using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Export Field.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ExportFieldDTO
    {
        /// <summary>
        /// Field Id.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Type of the field.
        /// </summary>
        [DataMember]
        public ExportFieldTypes FieldType { get; set; }

        /// <summary>
        /// Name of the field.
        /// </summary>
        [DataMember]
        public string FieldName { get; set; }

        /// <summary>
        /// Display name of the field.
        /// </summary>
        [DataMember]
        public string DisplayName { get; set; }

        /// <summary>
        /// The field is available for export.
        /// </summary>
        [DataMember]
        public bool Selectable { get; set; }

        /// <summary>
        /// The field is available for filtering.
        /// </summary>
        [DataMember]
        public bool Filterable { get; set; }

        /// <summary>
        /// Available lookup values for lookup fields.
        /// </summary>
        [DataMember]
        public List<ListItemDTO> LookupValues { get; set; }

        /// <summary>
        /// Minimum valid value for numeric fields.
        /// </summary>
        [DataMember]
        public int? Min { get; set; }

        /// <summary>
        /// Maximum valid value for numeric fields.
        /// </summary>
        [DataMember]
        public int? Max { get; set; }

    }
}