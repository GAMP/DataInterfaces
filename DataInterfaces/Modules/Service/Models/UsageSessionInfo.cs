using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Usage session info model.
    /// </summary>
    [Serializable()]
    [ProtoContract()]
    [DataContract()]
    public class UsageSessionInfo
    {
        #region PROPERTIES
        
        /// <summary>
        /// Usage session id.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public int UsageSessionId
        {
            get; set;
        }

        /// <summary>
        /// User id.
        /// </summary>
        [ProtoMember(2)]
        [DataMember()]
        public int UserId
        {
            get; set;
        }

        /// <summary>
        /// Product name.
        /// </summary>
        [ProtoMember(3)]
        [DataMember()]
        public string TimePorduct
        {
            get; set;
        }

        /// <summary>
        /// Current usage type.
        /// </summary>
        [ProtoMember(4)]
        [DataMember()]
        public UsageType CurrentUsageType
        {
            get; set;
        } 

        #endregion
    }
}
