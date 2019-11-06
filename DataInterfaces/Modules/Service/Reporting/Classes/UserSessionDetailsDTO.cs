using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// User Session Details.
    /// </summary>
    [Serializable]
    [DataContract]
    public class UserSessionDetailsDTO : UserSessionDTO
    {
        /// <summary>
        /// The name of the user to which the session belongs.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// The name of the host on which the user session ran.
        /// </summary>
        [DataMember]
        public string HostName { get; set; }

        /// <summary>
        /// The number of the host on which the user session ran.
        /// </summary>
        [DataMember]
        public int HostNumber { get; set; }
        
        /// <summary>
        /// The Id of the operator that started the session.
        /// </summary>
        [DataMember]
        public int? LoginOperatorId { get; set; }

        /// <summary>
        /// The name of the operator that started the session.
        /// </summary>
        [DataMember]
        public string LoginOperatorName { get; set; }

        /// <summary>
        /// The Id of the operator that ended the session.
        /// </summary>
        [DataMember]
        public int? LogoutOperatorId { get; set; }

        /// <summary>
        /// The name of the operator that ended the session.
        /// </summary>
        [DataMember]
        public string LogoutOperatorName { get; set; }

        /// <summary>
        /// The name of the host to which the session was moved.
        /// </summary>
        [DataMember]
        public string MoveHostName { get; set; }

        /// <summary>
        /// The state of the session.
        /// </summary>
        [DataMember]
        public SessionState State { get; set; }

    }
}