using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Account creation by mobile phone result model.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class AccountCreationByMobilePhoneResult : VerificationResultBase<VerificationStartResultCode>
    {
        #region PROPERTIES

        /// <summary>
        /// Mobile phone used.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public string MobilePhone
        {
            get; set;
        }

        #endregion
    }
}
