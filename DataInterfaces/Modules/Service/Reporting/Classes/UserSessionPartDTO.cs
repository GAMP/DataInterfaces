using SharedLib;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// User Session Part.
    /// </summary>
    [Serializable]
    [DataContract]
    public class UserSessionPartDTO
    {

        /// <summary>
        /// The state of the session.
        /// </summary>
        [DataMember]
        public List<UserSessionDetailsDTO> UserSessionChanges { get; set; }

    }
}