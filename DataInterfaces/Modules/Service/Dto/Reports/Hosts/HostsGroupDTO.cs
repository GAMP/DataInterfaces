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
    public class HostsGroupDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public long MinutesUsed { get; set; }

        [DataMember]
        public string HoursUsed { get; set; }

        [DataMember]
        public long TotalMinutes { get; set; }

        [DataMember]
        public string TotalHours { get; set; }

        [DataMember]
        public decimal HoursPercentage { get; set; }

        [DataMember]
        public decimal TotalMoney { get; set; }

        [DataMember]
        public decimal UtilizationPercentage { get; set; }

        [DataMember]
        public List<SessionCostGroupedDTO> GroupSessionsCost { get; set; } = new List<SessionCostGroupedDTO>();

        [DataMember]
        public List<DateUtilizationChartDTO> Utilization { get; set; } = new List<DateUtilizationChartDTO>();

    }
}