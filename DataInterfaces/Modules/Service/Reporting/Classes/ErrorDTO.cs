using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Error Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ErrorDTO
    {
        /// <summary>
        /// Error message.
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
