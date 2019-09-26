using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class ListItemDTO : NamedInstanceDTO
    {
        [DataMember]
        public int Id { get; set; }
    }
}