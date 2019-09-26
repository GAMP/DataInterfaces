using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User verification state info model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class UserVerificationStateInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Indicates if verification was previously completed.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public bool IsVerified
        {
            get; set;
        }

        /// <summary>
        /// Indicates if verification is currently pending.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public bool IsVerificationPending
        {
            get; set;
        }

        /// <summary>
        /// Indicates if verification was initiated but expired.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public bool IsVerificationExpired
        {
            get; set;
        }

        /// <summary>
        /// Indicates if value is assigned to a user.
        /// </summary>
        [IgnoreDataMember()]
        [ProtoIgnore()]
        public bool IsAssigned
        {
            get { return AssignedUserId != null; }
        }

        /// <summary>
        /// User id that the value is currently assigned to.
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
