using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Hosts
{
    /// <summary>
    /// User Session Cost Group.
    /// </summary>
    [Serializable]
    [DataContract]
    public class UserSessionCostGroupDTO : UserSessionCostDTO
    {
        /// <summary>
        /// Group name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Hours used percentage in comparison with other groups within the same period.
        /// </summary>
        [DataMember]
        public decimal HoursPercentage { get; set; }

        /// <summary>
        /// Estimated revenue percentage in comparison with other groups within the same period.
        /// </summary>
        [DataMember]
        public decimal EstimatedRevenuePercentage { get; set; }

        [DataMember]
        public List<UserSessionCostGroupDTO> SessionCostSubGroups { get; set; }
    }
}