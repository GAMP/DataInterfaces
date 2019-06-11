using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region VerificationResultBase
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    [ProtoInclude(500, typeof(EmailVerificationStartResult))]
    [ProtoInclude(501, typeof(MobilePhoneVerificationStartResult))]
    [ProtoInclude(502, typeof(AccountCreationByMobilePhoneResult))]
    [ProtoInclude(503, typeof(AccountCreationByEmailResult))]
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
        [ProtoIgnore()]
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
    public class EmailVerificationStartResult : VerificationResultBase<VerificationStartResultCode>
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

    #region MobilePhoneVerificationStartResult
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class MobilePhoneVerificationStartResult : VerificationResultBase<VerificationStartResultCode>
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

    #region AccountCreationByMobilePhoneResult
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class AccountCreationByMobilePhoneResult : VerificationResultBase<VerificationStartResultCode>
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets mobile phone.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public string MobilePhone
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region AccountCreationByEmailResult
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class AccountCreationByEmailResult : VerificationResultBase<VerificationStartResultCode>
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets email address.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public string EmailAddress
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region AccountCreationByTokenCompleteResult
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class AccountCreationByTokenCompleteResult : VerificationResultBase<SharedLib.AccountCreationByTokenCompleteResultCode>
    {
        #region PROPERTIES

        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(1)]
        public int? CreatedUserId
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region AccountCreationCompleteResult
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class AccountCreationCompleteResult
    {
        #region PROPERTIES

        [ProtoMember(1)]
        public SharedLib.AccountCreationCompleteResultCode Result
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(2)]
        public int? UserId
        {
            get; set;
        }

        #endregion
    } 
    #endregion
}
