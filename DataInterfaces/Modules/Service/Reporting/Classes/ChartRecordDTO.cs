using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Chart Record.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ChartRecordDTO
    {
        /// <summary>
        /// The name of the chart record.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The value of the chart record.
        /// </summary>
        [DataMember]
        public decimal Value { get; set; }
    }
}
