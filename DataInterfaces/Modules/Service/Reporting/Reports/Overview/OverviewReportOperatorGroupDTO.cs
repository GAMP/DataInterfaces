using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Reporting.Reports.Overview
{
    [Serializable]
    [DataContract]
    public class OverviewReportOperatorStatisticsDTO : NamedDecimalContainerDTO
    {
        [DataMember]
        public int OperatorId { get; set; }

        [DataMember]
        public int MinutesWorked { get; set; }

        [DataMember]
        public string HoursWorked { get; set; }

        [DataMember]
        public decimal MinutesSold { get; set; }

        [DataMember]
        public string HoursSold { get; set; }

        [DataMember]
        public int ProductsSold { get; set; }

        [DataMember]
        public int TimeOffersSold { get; set; }

        [DataMember]
        public int BundlesSold { get; set; }

        [DataMember]
        public int Voids { get; set; }
    }
}