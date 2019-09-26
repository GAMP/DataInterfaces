using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    [Serializable]
    [DataContract]
    public class UserDetailDTO : NamedDecimalContainerDTO
    {
        [DataMember]
        public string StringValue { get; set; }
    }
}