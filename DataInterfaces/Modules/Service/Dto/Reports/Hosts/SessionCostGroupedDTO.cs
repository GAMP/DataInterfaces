using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Dto.Reports.Hosts
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