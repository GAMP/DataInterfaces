using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Chart Group.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ChartGroupDTO
    {
        /// <summary>
        /// Chart group name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// List of records for the group.
        /// </summary>
        [DataMember]
        public List<ChartRecordDTO> GroupRecords { get; set; }
    }
}