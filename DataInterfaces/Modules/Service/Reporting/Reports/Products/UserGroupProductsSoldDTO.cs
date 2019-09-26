using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    [Serializable]
    [DataContract]
    public class UserGroupProductsSoldDTO : NamedInstanceDTO
    {
        [DataMember]
        public SoldProductDTO Product { get; set; }

    }
}