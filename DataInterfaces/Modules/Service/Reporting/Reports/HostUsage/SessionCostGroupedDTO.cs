using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Hosts
{
    [Serializable]
    [DataContract]
    public class SessionCostGroupedDTO : SessionCostBaseDTO
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public long Minutes { get; set; }

        [DataMember]
        public string Hours { get; set; }

        [DataMember]
        public decimal HoursPercentage { get; set; }

        [DataMember]
        public decimal MoneyPercentage { get; set; }

        [DataMember]
        public List<SessionCostGroupedDTO> SessionCostSubGroups { get; set; }
    }
}