using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Open session info model.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class OpenSessionInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets session id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int SessionId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets slot.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int Slot
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int UserId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets host id.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int HostId
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets session state.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public SessionState State
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets session span.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public double Span
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets last activation.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public double? LastActivation
        {
            get; set;
        }

        #endregion
    }
}
