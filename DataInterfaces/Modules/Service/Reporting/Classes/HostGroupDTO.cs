using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Host Group Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class HostGroupDTO
    {
        /// <summary>
        /// Host Group Id.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Host Group name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Host Group Id.
        /// </summary>
        [DataMember]
        public List<HostDTO> Hosts { get; set; }

    }
}
