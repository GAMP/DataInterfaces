using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Dto.Reports.Users
{
    [Serializable]
    [DataContract]
    public class TopUserDTO : NamedDecimalContainerDTO
    {
        [DataMember]
        public string StringValue { get; set; }
    }
}