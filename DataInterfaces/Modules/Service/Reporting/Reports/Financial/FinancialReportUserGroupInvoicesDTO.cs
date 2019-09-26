using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    [Serializable]
    [DataContract]
    public class FinancialReportUserGroupInvoicesDTO : NamedInstanceDTO
    {
        [DataMember]
        public List<SoldProductDTO> FixedTimeProductsSold { get; set; } = new List<SoldProductDTO>();

        [DataMember]
        public List<SoldProductDTO> SessionTimeProductsSold { get; set; } = new List<SoldProductDTO>();

        [DataMember]
        public List<SoldProductDTO> TimeOffersSold { get; set; } = new List<SoldProductDTO>();

        [DataMember]
        public List<SoldProductDTO> ProductsSold { get; set; } = new List<SoldProductDTO>();

        [DataMember]
        public List<SoldProductDTO> BundlesSold { get; set; } = new List<SoldProductDTO>();

    }
}