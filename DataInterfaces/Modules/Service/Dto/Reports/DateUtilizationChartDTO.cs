using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Dto.Reports
{
    [Serializable]
    [DataContract]
    public class DateUtilizationChartDTO : ChartRecordDTO
    {
        [DataMember]
        public int TotalSeconds { get; set; }

        [DataMember]
        public int UsedSeconds { get; set; }

    }
}
