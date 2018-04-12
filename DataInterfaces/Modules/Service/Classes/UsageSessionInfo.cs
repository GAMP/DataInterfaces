using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [Serializable()]
    [ProtoContract()]
    [DataContract()]
    public class UsageSessionInfo
    {
        /// <summary>
        /// Gets or sets usage session id.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public int UsageSessionId
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [ProtoMember(2)]
        [DataMember()]
        public int UserId
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets product name.
        /// </summary>
        [ProtoMember(3)]
        [DataMember()]
        public string TimePorduct
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets current usage type.
        /// </summary>
        [ProtoMember(4)]
        [DataMember()]
        public UsageType CurrentUsageType
        {
            get;set;
        }
    }

    public enum UsageType
    {
        None,
        Rate,
        TimeFixed,
        TimeOffer,
    }
}
