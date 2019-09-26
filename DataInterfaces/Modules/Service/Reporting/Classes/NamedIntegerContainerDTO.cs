using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class NamedIntegerContainerDTO : NamedInstanceDTO
    {
        [DataMember]
        public int Value { get; set; }
    }
}