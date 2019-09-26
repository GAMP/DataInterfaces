using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class NamedInstanceDTO
    {
        [DataMember]
        public string Name { get; set; }
    }
}
