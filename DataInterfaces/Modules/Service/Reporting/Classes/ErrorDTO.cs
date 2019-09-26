using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class ErrorDTO
    {
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
