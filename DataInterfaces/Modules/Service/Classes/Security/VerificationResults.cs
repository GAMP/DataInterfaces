using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region TokeVerificationResultBase
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    [ProtoInclude(500,typeof(EmailVerificationStartResult))]
    [ProtoInclude(501, typeof(MobilePhoneVerificationResult))]
    public abstract class VerificationResultBase<T>
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets verification result.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public T Result
        {
            get; set;
        }

        /// <summary>
        /// Gets token confirmation code.
        /// </summary>
        [ProtoMember(2)]
        [DataMember(EmitDefaultValue = false)]
        public string ConfirmationCode
        {
            get; set;
        }

        /// <summary>
        /// Gets token value.
        /// </summary>
        [ProtoMember(3)]
        [DataMember(EmitDefaultValue = false)]
        public string Token
        {
            get; set;
        }

        /// <summary>
        /// Gets token id.
        /// </summary>
        [ProtoMember(4)]
        [DataMember(EmitDefaultValue = false)]
        public int? TokenId
        {
            get; set;
        }

        /// <summary>
        /// Gets result string.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string ResultString
        {
            get { return Result.ToString(); }
        }

        #endregion
    }
    #endregion

    #region EmailVerificationStartResult
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class EmailVerificationStartResult : VerificationResultBase<VerificationStartResult>
    {
        #region PROPERTIES

        [ProtoMember(1)]
        [DataMember(EmitDefaultValue = false)]
        public string Email
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region MobilePhoneVerificationResult
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class MobilePhoneVerificationResult : VerificationResultBase<VerificationStartResult>
    {
        #region PROPERTIES

        [ProtoMember(1)]
        [DataMember(EmitDefaultValue = false)]
        public string MobilePhone
        {
            get; set;
        }

        #endregion
    } 
    #endregion
}
