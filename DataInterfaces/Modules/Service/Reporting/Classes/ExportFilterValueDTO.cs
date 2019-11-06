using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Export Filter Value.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ExportFilterValueDTO
    {
        /// <summary>
        /// Field Id.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Filter value for non range fields.
        /// </summary>
        [DataMember]
        public string Value { get; set; }

        /// <summary>
        /// Filter value from for range fields.
        /// </summary>
        [DataMember]
        public string ValueFrom { get; set; }

        /// <summary>
        /// Filter value to for range fields.
        /// </summary>
        [DataMember]
        public string ValueTo { get; set; }

    }
}