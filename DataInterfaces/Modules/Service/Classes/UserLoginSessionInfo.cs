using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User login dto.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class UserLoginSessionInfo
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
        /// Gets or sets user id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int UserId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets host id.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int HostId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets login time.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public DateTime LoginTime
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets logged in by user id.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public int? LoggedInById
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets logout time.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public DateTime? LogoutTime
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets logged out by user id.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public int? LoggedOutById
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets moved host id.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public int? MoveHostId
        {
            get; set;
        }

        #endregion
    }

    /// <summary>
    /// User login extended dto.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class UserLoginSessionInfoExtended : UserLoginSessionInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public string User
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets hostname.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string Hostname
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets logged in by user name.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public string LoggedInByUser
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets logged out by user name.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public string LoggedOutByUser
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets moved host name.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public string MoveHost
        {
            get; set;
        }

        #endregion
    }
}
