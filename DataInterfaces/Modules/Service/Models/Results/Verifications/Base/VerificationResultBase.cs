using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Base class for verfication results.
    /// </summary>
    /// <typeparam name="T">Result type.</typeparam>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    [ProtoInclude(500, typeof(EmailVerificationStartResult))]
    [ProtoInclude(501, typeof(MobilePhoneVerificationStartResult))]
    [ProtoInclude(502, typeof(AccountCreationByMobilePhoneResult))]
    [ProtoInclude(503, typeof(AccountCreationByEmailResult))]
    public abstract class VerificationResultBase<T> where T : Enum
    {
        #region PROPERTIES

        /// <summary>
        /// Verification result code.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public T Result
        {
            get; set;
        }

        /// <summary>
        /// Confirmation code.
        /// </summary>
        [ProtoMember(2)]
        [DataMember(EmitDefaultValue = false)]
        public string ConfirmationCode
        {
            get; set;
        }

        /// <summary>
        /// Token value.
        /// </summary>
        [ProtoMember(3)]
        [DataMember(EmitDefaultValue = false)]
        public string Token
        {
            get; set;
        }

        /// <summary>
        /// Token id.
        /// </summary>
        [ProtoMember(4)]
        [DataMember(EmitDefaultValue = false)]
        public int? TokenId
        {
            get; set;
        }

        /// <summary>
        /// Result string.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [ProtoIgnore()]
        public string ResultString
        {
            get { return Result?.ToString(); }
        }

        #endregion
    }
}
