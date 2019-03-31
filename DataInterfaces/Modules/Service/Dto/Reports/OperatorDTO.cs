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
    public class OperatorDTO : NamedInstanceDTO
    {
        [DataMember]
        public int Id { get; set; }
    }
}