using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class NamedDecimalContainerDTO : NamedInstanceDTO
    {
        [DataMember]
        public decimal Value { get; set; }
    }
}