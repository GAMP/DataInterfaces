using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Chart Record Period.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ChartRecordPeriodDTO
    {
        /// <summary>
        /// Period name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Period date from.
        /// </summary>
        [DataMember]
        public DateTime From { get; set; }

        /// <summary>
        /// Period date to.
        /// </summary>
        [DataMember]
        public DateTime To { get; set; }

    }
}
