using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class UserInfoVerificationStateInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets if verification was previously completed.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public bool IsVerified
        {
            get; set;
        }

        /// <summary>
        /// Gets if verification is currently pending.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public bool IsVerificationPending
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if verification was initiated but expired.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public bool IsVerificationExpired
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if value is assigned to a user.
        /// </summary>
        [IgnoreDataMember()]
        [ProtoIgnore()]
        public bool IsAssigned
        {
            get { return AssignedUserId != null; }
        }

        /// <summary>
        /// Gets the user id that the value is currently assigned to.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int? AssignedUserId
        {
            get;set;
        }

        #endregion

    }
}
